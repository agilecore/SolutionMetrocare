using System;
using System.IO;
using System.Configuration;
using System.Configuration.Provider;
using System.Collections.Generic;
using System.Collections.Specialized;  
using System.Diagnostics; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;
using System.Data;
using MySql.Data.MySqlClient;

namespace Metrocare.Security
{
    public sealed class MySqlSessionStateStore : SessionStateStoreProviderBase
    {
        private string connectionString;
        private const string eventLog         = "Application";
        private const string eventSource      = "MySqlSessionStateStore";
        private const string exceptionMessage = "Ocorreu uma exception. Por favor contate o administrador.";
        private string pApplicationName;
        private SessionStateSection pConfig;
        private ConnectionStringSettings pConnectionStringSettings;
        private bool pWriteExceptionsToEventLog;

        /// <summary>
        /// Gets or sets a value indicating whether [write exceptions to event log].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [write exceptions to event log]; otherwise, <c>false</c>.
        /// </value>
        public bool WriteExceptionsToEventLog
        {
            get { return pWriteExceptionsToEventLog; }
            set { pWriteExceptionsToEventLog = value; }
        }

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <value>The name of the application.</value>
        public string ApplicationName
        {
            get { return pApplicationName; }
        }


        /// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The name of the provider is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// The name of the provider has a length of zero.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">
        /// An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"/> on a provider after the provider has already been initialized.
        /// </exception>
        public override void Initialize(string name, NameValueCollection config)
        {
            //
            // Initialize values from web.config.
            //
            if (config == null)
                throw new ArgumentNullException("config");

            if (string.IsNullOrEmpty(name))
                name = "MySqlSessionStateStore";

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "MySql Session State Store provider");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);


            //
            // Initialize the ApplicationName property.
            //

            pApplicationName =
              System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;


            //
            // Get <sessionState> configuration element.
            //

            var cfg = WebConfigurationManager.OpenWebConfiguration(ApplicationName);
            pConfig = (SessionStateSection)cfg.GetSection("system.web/sessionState");


            //
            // Initialize connection string.
            //

            pConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

            if (pConnectionStringSettings == null ||
                pConnectionStringSettings.ConnectionString.Trim() == "")
            {
                throw new ProviderException("Connection string cannot be blank.");
            }

            connectionString = pConnectionStringSettings.ConnectionString;


            //
            // Initialize WriteExceptionsToEventLog
            //

            pWriteExceptionsToEventLog = false;

            if (config["writeExceptionsToEventLog"] != null)
            {
                if (config["writeExceptionsToEventLog"].ToUpper() == "TRUE")
                    pWriteExceptionsToEventLog = true;
            }
        }


        /// <summary>
        /// Releases all resources used by the <see cref="T:System.Web.SessionState.SessionStateStoreProviderBase"/> implementation.
        /// </summary>
        public override void Dispose()
        {
        }

        /// <summary>
        /// Sets a reference to the <see cref="T:System.Web.SessionState.SessionStateItemExpireCallback"/> delegate for the Session_OnEnd event defined in the Global.asax file.
        /// </summary>
        /// <param name="expireCallback">The <see cref="T:System.Web.SessionState.SessionStateItemExpireCallback"/>  delegate for the Session_OnEnd event defined in the Global.asax file.</param>
        /// <returns>
        /// true if the session-state store provider supports calling the Session_OnEnd event; otherwise, false.
        /// </returns>
        public override bool SetItemExpireCallback(SessionStateItemExpireCallback expireCallback)
        {
            return false;
        }


        /// <summary>
        /// Updates the session-item information in the session-state data store with values from the current request, and clears the lock on the data.
        /// </summary>
        /// <param name="context">The <see cref="T:System.Web.HttpContext"/> for the current request.</param>
        /// <param name="id">The session identifier for the current request.</param>
        /// <param name="item">The <see cref="T:System.Web.SessionState.SessionStateStoreData"/> object that contains the current session values to be stored.</param>
        /// <param name="lockId">The lock identifier for the current request.</param>
        /// <param name="newItem">true to identify the session item as a new item; false to identify the session item as an existing item.</param>
        public override void SetAndReleaseItemExclusive(HttpContext context,
                                                        string id,
                                                        SessionStateStoreData item,
                                                        object lockId,
                                                        bool newItem)
        {
            // Serialize the SessionStateItemCollection as a string.
            string sessItems = Serialize((SessionStateItemCollection)item.Items);

            var conn = new MySqlConnection(connectionString);
            MySqlCommand cmd;
            MySqlCommand deleteCmd = null;

            if (newItem)
            {
                // MySqlCommand to clear an existing expired session if it exists.
                deleteCmd = new MySqlCommand("DELETE FROM sessions " +
                                             "WHERE SessionId = ?SessionId AND ApplicationName = ?ApplicationName AND Expires < ?Expires",
                                             conn);
                deleteCmd.Parameters.Add("?SessionId", MySqlDbType.VarChar, 80).Value = id;
                deleteCmd.Parameters.Add
                  ("?ApplicationName", MySqlDbType.VarChar, 255).Value = ApplicationName;
                deleteCmd.Parameters.Add
                  ("?Expires", MySqlDbType.DateTime).Value = DateTime.Now;

                // MySqlCommand to insert the new session item.
                cmd = new MySqlCommand("INSERT INTO sessions " +
                                       " (SessionId, ApplicationName, Created, Expires, " +
                                       "  LockDate, LockId, Timeout, Locked, SessionItems, Flags) " +
                                       " Values(?SessionId, ?ApplicationName, ?Created, ?Expires, " +
                                       "  ?LockDate, ?LockId, ?Timeout, ?Locked, ?SessionItems, ?Flags)", conn);
                cmd.Parameters.Add("?SessionId", MySqlDbType.VarChar, 80).Value = id;
                cmd.Parameters.Add
                  ("?ApplicationName", MySqlDbType.VarChar, 255).Value = ApplicationName;
                cmd.Parameters.Add
                  ("?Created", MySqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add
                  ("?Expires", MySqlDbType.DateTime).Value = DateTime.Now.AddMinutes(item.Timeout);
                cmd.Parameters.Add
                  ("?LockDate", MySqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("?LockId", MySqlDbType.Int32).Value = 0;
                cmd.Parameters.Add
                  ("?Timeout", MySqlDbType.Int32).Value = item.Timeout;
                cmd.Parameters.Add("?Locked", MySqlDbType.Int32).Value = 0;
                cmd.Parameters.Add
                  ("?SessionItems", MySqlDbType.VarChar, sessItems.Length).Value = sessItems;
                cmd.Parameters.Add("?Flags", MySqlDbType.Int32).Value = 0;
            }
            else
            {
                // MySqlCommand to update the existing session item.
                cmd = new MySqlCommand(
                  "UPDATE sessions SET Expires = ?Expires, SessionItems = ?SessionItems, Locked = ?Locked " +
                  " WHERE SessionId = ?SessionId AND ApplicationName = ?ApplicationName AND LockId = ?LockId", conn);
                cmd.Parameters.Add("?Expires", MySqlDbType.DateTime).Value =
                  DateTime.Now.AddMinutes(item.Timeout);
                cmd.Parameters.Add("?SessionItems",
                                   MySqlDbType.Text, sessItems.Length).Value = sessItems;
                cmd.Parameters.Add("?Locked", MySqlDbType.Int32).Value = 0;
                cmd.Parameters.Add("?SessionId", MySqlDbType.VarChar, 80).Value = id;
                cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar,
                                   255).Value = ApplicationName;
                cmd.Parameters.Add("?LockId", MySqlDbType.Int32).Value = lockId;
            }

            try
            {
                conn.Open();

                if (deleteCmd != null)
                    deleteCmd.ExecuteNonQuery();

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "SetAndReleaseItemExclusive");
                    throw new ProviderException(exceptionMessage);
                }
                else
                    throw e;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The id.</param>
        /// <param name="locked">if set to <c>true</c> [locked].</param>
        /// <param name="lockAge">The lock age.</param>
        /// <param name="lockId">The lock id.</param>
        /// <param name="actionFlags">The action flags.</param>
        /// <returns></returns>
        public override SessionStateStoreData GetItem(HttpContext context,
                                                      string id,
                                                      out bool locked,
                                                      out TimeSpan lockAge,
                                                      out object lockId,
                                                      out SessionStateActions actionFlags)
        {
            return GetSessionStoreItem(false, context, id, out locked,
                                       out lockAge, out lockId, out actionFlags);
        }


        /// <summary>
        /// Gets the item exclusive.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The id.</param>
        /// <param name="locked">if set to <c>true</c> [locked].</param>
        /// <param name="lockAge">The lock age.</param>
        /// <param name="lockId">The lock id.</param>
        /// <param name="actionFlags">The action flags.</param>
        /// <returns></returns>
        public override SessionStateStoreData GetItemExclusive(HttpContext context,
                                                               string id,
                                                               out bool locked,
                                                               out TimeSpan lockAge,
                                                               out object lockId,
                                                               out SessionStateActions actionFlags)
        {
            return GetSessionStoreItem(true, context, id, out locked,
                                       out lockAge, out lockId, out actionFlags);
        }


        //
        // GetSessionStoreItem is called by both the GetItem and 
        // GetItemExclusive methods. GetSessionStoreItem retrieves the 
        // session data from the data source. If the lockRecord parameter
        // is true (in the case of GetItemExclusive), then GetSessionStoreItem
        // locks the record and sets a new LockId and LockDate.
        //

        private SessionStateStoreData GetSessionStoreItem(bool lockRecord,
                                                          HttpContext context,
                                                          string id,
                                                          out bool locked,
                                                          out TimeSpan lockAge,
                                                          out object lockId,
                                                          out SessionStateActions actionFlags)
        {
            // Initial values for return value and out parameters.
            SessionStateStoreData item = null;
            lockAge = TimeSpan.Zero;
            lockId = null;
            locked = false;
            actionFlags = 0;

            // MySql database connection.
            var conn = new MySqlConnection(connectionString);
            // MySqlCommand for database commands.
            MySqlCommand cmd = null;
            // DataReader to read database record.
            MySqlDataReader reader = null;
            // Datetime to check if current session item is expired.
            // String to hold serialized SessionStateItemCollection.
            var serializedItems = "";
            // True if a record is found in the database.
            var foundRecord = false;
            // True if the returned session item is expired and needs to be deleted.
            var deleteData = false;
            // Timeout value from the data store.
            var timeout = 0;

            try
            {
                conn.Open();

                // lockRecord is true when called from GetItemExclusive and
                // false when called from GetItem.
                // Obtain a lock if possible. Ignore the record if it is expired.
                if (lockRecord)
                {
                    cmd = new MySqlCommand(
                      "UPDATE sessions SET" +
                      " Locked = ?Locked1, LockDate = ?LockDate " +
                      " WHERE SessionId = ?SessionId AND ApplicationName = ?ApplicationName AND Locked = ?Locked2 AND Expires > ?Expires",
                      conn);
                    cmd.Parameters.Add("?Locked1", MySqlDbType.Int32).Value = 1;
                    cmd.Parameters.Add("?LockDate", MySqlDbType.DateTime).Value
                      = DateTime.Now;
                    cmd.Parameters.Add("?SessionId", MySqlDbType.VarChar, 80).Value = id;
                    cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar,
                                       255).Value = ApplicationName;
                    cmd.Parameters.Add("?Locked2", MySqlDbType.Int32).Value = 0;
                    cmd.Parameters.Add
                      ("?Expires", MySqlDbType.DateTime).Value = DateTime.Now;

                    if (cmd.ExecuteNonQuery() == 0)
                        // No record was updated because the record was locked or not found.
                        locked = true;
                    else
                        // The record was updated.

                        locked = false;
                }

                // Retrieve the current session item information.
                cmd = new MySqlCommand(
                  "SELECT Expires, SessionItems, LockId, LockDate, Flags, Timeout " +
                  "  FROM sessions " +
                  "  WHERE SessionId = ?SessionId AND ApplicationName = ?ApplicationName", conn);
                cmd.Parameters.Add("?SessionId", MySqlDbType.VarChar, 80).Value = id;
                cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar,
                                   255).Value = ApplicationName;

                // Retrieve session item data from the data source.
                reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                while (reader.Read())
                {
                    var expires = reader.GetDateTime(0);

                    if (expires < DateTime.Now)
                    {
                        // The record was expired. Mark it as not locked.
                        locked = false;
                        // The session was expired. Mark the data for deletion.
                        deleteData = true;
                    }
                    else
                        foundRecord = true;

                    serializedItems = reader.GetString(1);
                    lockId = reader.GetInt32(2);
                    lockAge = DateTime.Now.Subtract(reader.GetDateTime(3));
                    actionFlags = (SessionStateActions)reader.GetInt32(4);
                    timeout = reader.GetInt32(5);
                }
                reader.Close();


                // If the returned session item is expired, 
                // delete the record from the data source.
                if (deleteData)
                {
                    cmd = new MySqlCommand("DELETE FROM sessions " +
                                           "WHERE SessionId = ?SessionId AND ApplicationName = ?ApplicationName", conn);
                    cmd.Parameters.Add("?SessionId", MySqlDbType.VarChar, 80).Value = id;
                    cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar,
                                       255).Value = ApplicationName;

                    cmd.ExecuteNonQuery();
                }

                // The record was not found. Ensure that locked is false.
                if (!foundRecord)
                    locked = false;

                // If the record was found and you obtained a lock, then set 
                // the lockId, clear the actionFlags,
                // and create the SessionStateStoreItem to return.
                if (foundRecord && !locked)
                {
                    lockId = (int)lockId + 1;

                    cmd = new MySqlCommand("UPDATE sessions SET" +
                                           " LockId = ?LockId, Flags = 0 " +
                                           " WHERE SessionId = ?SessionId AND ApplicationName = ?ApplicationName", conn);
                    cmd.Parameters.Add("?LockId", MySqlDbType.Int32).Value = lockId;
                    cmd.Parameters.Add("?SessionId", MySqlDbType.VarChar, 80).Value = id;
                    cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = ApplicationName;

                    cmd.ExecuteNonQuery();

                    // If the actionFlags parameter is not InitializeItem, 
                    // deserialize the stored SessionStateItemCollection.
                    if (actionFlags == SessionStateActions.InitializeItem)
                        item = CreateNewStoreData(context, pConfig.Timeout.Minutes);
                    else
                        item = Deserialize(context, serializedItems, timeout);
                }
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "GetSessionStoreItem");
                    throw new ProviderException(exceptionMessage);
                }
                else
                    throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                conn.Close();
            }

            return item;
        }


        //
        // Serialize is called by the SetAndReleaseItemExclusive method to 
        // convert the SessionStateItemCollection into a Base64 string to    
        // be stored in an Access Memo field.
        //

        /// <summary>
        /// Serialize is called by the SetAndReleaseItemExclusive method to convert 
        /// the SessionStateItemCollection into a Base64 string to be stored in an text field.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        private static string Serialize(SessionStateItemCollection items)
        {
            var ms = new MemoryStream();
            var writer = new BinaryWriter(ms);

            if (items != null)
                items.Serialize(writer);

            writer.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// DeSerialize is called by the GetSessionStoreItem method to 
        /// convert the Base64 string stored in the text field to a 
        /// SessionStateItemCollection.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="serializedItems">The serialized items.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        private static SessionStateStoreData Deserialize(HttpContext context,
                                                  string serializedItems, int timeout)
        {
            var ms =
              new MemoryStream(Convert.FromBase64String(serializedItems));

            var sessionItems =
              new SessionStateItemCollection();

            if (ms.Length > 0)
            {
                var reader = new BinaryReader(ms);
                sessionItems = SessionStateItemCollection.Deserialize(reader);
            }

            return new SessionStateStoreData(sessionItems,
                                             SessionStateUtility.GetSessionStaticObjects(context),
                                             timeout);
        }

        /// <summary>
        /// Releases a lock on an item in the session data store.
        /// </summary>
        /// <param name="context">The <see cref="T:System.Web.HttpContext"/> for the current request.</param>
        /// <param name="id">The session identifier for the current request.</param>
        /// <param name="lockId">The lock identifier for the current request.</param>
        public override void ReleaseItemExclusive(HttpContext context,
                                                  string id,
                                                  object lockId)
        {
            var conn = new MySqlConnection(connectionString);
            var cmd =
              new MySqlCommand("UPDATE sessions SET Locked = 0, Expires = ?Expires " +
                               "WHERE SessionId = ?SessionId AND ApplicationName = ?ApplicationName AND LockId = ?LockId",
                               conn);
            cmd.Parameters.Add("?Expires", MySqlDbType.DateTime).Value =
              DateTime.Now.AddMinutes(pConfig.Timeout.Minutes);
            cmd.Parameters.Add("?SessionId", MySqlDbType.VarChar, 80).Value = id;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar,
                               255).Value = ApplicationName;
            cmd.Parameters.Add("?LockId", MySqlDbType.Int32).Value = lockId;

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ReleaseItemExclusive");
                    throw new ProviderException(exceptionMessage);
                }
                else
                    throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Deletes item data from the session data store.
        /// </summary>
        /// <param name="context">The <see cref="T:System.Web.HttpContext"/> for the current request.</param>
        /// <param name="id">The session identifier for the current request.</param>
        /// <param name="lockId">The lock identifier for the current request.</param>
        /// <param name="item">The <see cref="T:System.Web.SessionState.SessionStateStoreData"/> that represents the item to delete from the data store.</param>
        public override void RemoveItem(HttpContext context,
                                        string id,
                                        object lockId,
                                        SessionStateStoreData item)
        {
            var conn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("DELETE FROM sessions WHERE SessionId = ?SessionId AND ApplicationName = ?ApplicationName AND LockId = ?LockId", conn);
            cmd.Parameters.Add("?SessionId", MySqlDbType.VarChar, 80).Value = id;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar, 255).Value = ApplicationName;
            cmd.Parameters.Add("?LockId", MySqlDbType.Int32).Value = lockId;

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "RemoveItem");
                    throw new ProviderException(exceptionMessage);
                }
                else
                    throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Adds a new session-state item to the data store.
        /// </summary>
        /// <param name="context">The <see cref="T:System.Web.HttpContext"/> for the current request.</param>
        /// <param name="id">The <see cref="P:System.Web.SessionState.HttpSessionState.SessionID"/> for the current request.</param>
        /// <param name="timeout">The session <see cref="P:System.Web.SessionState.HttpSessionState.Timeout"/> for the current request.</param>
        public override void CreateUninitializedItem(HttpContext context,
                                                     string id,
                                                     int timeout)
        {
            var conn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("INSERT INTO sessions " +
                                       " (SessionId, ApplicationName, Created, Expires, " +
                                       "  LockDate, LockId, Timeout, Locked, SessionItems, Flags) " +
                                       " Values(?SessionId, ?ApplicationName, ?Created, ?Expires, " +
                                       "  ?LockDate, ?LockId, ?Timeout, ?Locked, ?SessionItems, ?Flags)", conn);
            cmd.Parameters.Add("?SessionId", MySqlDbType.VarChar, 80).Value = id;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar,
                               255).Value = ApplicationName;
            cmd.Parameters.Add("?Created", MySqlDbType.DateTime).Value
              = DateTime.Now;
            cmd.Parameters.Add("?Expires", MySqlDbType.DateTime).Value
              = DateTime.Now.AddMinutes(timeout);
            cmd.Parameters.Add("?LockDate", MySqlDbType.DateTime).Value
              = DateTime.Now;
            cmd.Parameters.Add("?LockId", MySqlDbType.Int32).Value = 0;
            cmd.Parameters.Add("?Timeout", MySqlDbType.Int32).Value = timeout;
            cmd.Parameters.Add("?Locked", MySqlDbType.Int32).Value = 0;
            cmd.Parameters.Add("?SessionItems", MySqlDbType.VarChar, 0).Value = "";
            cmd.Parameters.Add("?Flags", MySqlDbType.Int32).Value = 1;

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "CreateUninitializedItem");
                    throw new ProviderException(exceptionMessage);
                }
                else
                    throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Creates a new <see cref="T:System.Web.SessionState.SessionStateStoreData"/> object to be used for the current request.
        /// </summary>
        /// <param name="context">The <see cref="T:System.Web.HttpContext"/> for the current request.</param>
        /// <param name="timeout">The session-state <see cref="P:System.Web.SessionState.HttpSessionState.Timeout"/> value for the new <see cref="T:System.Web.SessionState.SessionStateStoreData"/>.</param>
        /// <returns>
        /// A new <see cref="T:System.Web.SessionState.SessionStateStoreData"/> for the current request.
        /// </returns>
        public override SessionStateStoreData CreateNewStoreData(HttpContext context, int timeout)
        {
            return new SessionStateStoreData(new SessionStateItemCollection(),
                                             SessionStateUtility.GetSessionStaticObjects(context),
                                             timeout);
        }

        /// <summary>
        /// Updates the expiration date and time of an item in the session data store.
        /// </summary>
        /// <param name="context">The <see cref="T:System.Web.HttpContext"/> for the current request.</param>
        /// <param name="id">The session identifier for the current request.</param>
        public override void ResetItemTimeout(HttpContext context,
                                              string id)
        {
            var conn = new MySqlConnection(connectionString);
            var cmd =
              new MySqlCommand("UPDATE sessions SET Expires = ?Expires " +
                               "WHERE SessionId = ?SessionId AND ApplicationName = ?ApplicationName", conn);
            cmd.Parameters.Add("?Expires", MySqlDbType.DateTime).Value
              = DateTime.Now.AddMinutes(pConfig.Timeout.Minutes);
            cmd.Parameters.Add("?SessionId", MySqlDbType.VarChar, 80).Value = id;
            cmd.Parameters.Add("?ApplicationName", MySqlDbType.VarChar,
                               255).Value = ApplicationName;

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                if (WriteExceptionsToEventLog)
                {
                    WriteToEventLog(e, "ResetItemTimeout");
                    throw new ProviderException(exceptionMessage);
                }
                else
                    throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Called by the <see cref="T:System.Web.SessionState.SessionStateModule"/> object for per-request initialization.
        /// </summary>
        /// <param name="context">The <see cref="T:System.Web.HttpContext"/> for the current request.</param>
        public override void InitializeRequest(HttpContext context)
        {
        }


        /// <summary>
        /// Called by the <see cref="T:System.Web.SessionState.SessionStateModule"/> object at the end of a request.
        /// </summary>
        /// <param name="context">The <see cref="T:System.Web.HttpContext"/> for the current request.</param>
        public override void EndRequest(HttpContext context)
        {
        }

        /// <summary>
        /// WriteToEventLog
        /// This is a helper function that writes exception detail to the 
        /// event log. Exceptions are written to the event log as a security
        /// measure to ensure private database details are not returned to 
        /// browser. If a method does not return a status or Boolean
        /// indicating the action succeeded or failed, the caller also 
        /// throws a generic exception.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="action">The action.</param>
        private static void WriteToEventLog(Exception e, string action)
        {
            var log = new EventLog { Source = eventSource, Log = eventLog };
            var message = "An exception occurred communicating with the data source.\n\n";
            message += "Action: " + action + "\n\n";
            message += "Exception: " + e;

            log.WriteEntry(message);
        }
    }
}
