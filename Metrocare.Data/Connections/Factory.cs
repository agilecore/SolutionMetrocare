using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using Metrocare.Data.Interfaces;

namespace Metrocare.Data.Connections
{
    public class Factory : IConnectionFactory, IDisposable
    {
        private readonly string _connectionectionStringOleDb     = ConfigurationManager.ConnectionStrings["DTOleDb"].ConnectionString;
        private readonly string _connectionectionStringSqlServer = ConfigurationManager.ConnectionStrings["DTSqlServer"].ConnectionString;
        private readonly string _connectionectionStringOracle    = ConfigurationManager.ConnectionStrings["DTOracle"].ConnectionString;
        private readonly string _connectionectionStringMySql     = ConfigurationManager.ConnectionStrings["DTMySql"].ConnectionString;
        private bool            _disposed                        = false;
        public DbConnection     Connection { get; set; }
        public ConnectionState  ConnectionState { get; set; }

        #region "Metodos de Conexões"

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="BancoDeDados">Enum do tipo de banco de dados.</param>
        public Factory()
        {
            Initial(EBancoDeDados.MySql);
        }

        /// <summary>
        /// Inicializa o assembly do tipo do banco de dados.
        /// </summary>
        /// <param name="BancoDeDados">Enum do tipo de banco de dados.</param>
        private void Initial(EBancoDeDados BancoDeDados)
        {
            try
            {
                if (BancoDeDados == EBancoDeDados.OleDb)
                {
                    var factory = DbProviderFactories.GetFactory("System.Data.OleDb");
                    var connection = factory.CreateConnection();
                    
                    connection.ConnectionString = this._connectionectionStringOleDb;
                    //connection.Open();

                    this.Connection = connection;
                    ConnectionState = connection.State;
                }
                else if (BancoDeDados == EBancoDeDados.SqlServer)
                {
                    var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                    var connection = factory.CreateConnection();

                    connection.ConnectionString = this._connectionectionStringSqlServer;
                    //connection.Open();

                    this.Connection = connection;
                    ConnectionState = connection.State;
                }
                else if (BancoDeDados == EBancoDeDados.Oracle)
                {
                    var factory = DbProviderFactories.GetFactory("System.Data.OracleClient");
                    var connection = factory.CreateConnection();

                    connection.ConnectionString = this._connectionectionStringOracle;
                    //connection.Open();

                    this.Connection = connection;
                    ConnectionState = connection.State;
                }
                else if (BancoDeDados == EBancoDeDados.MySql)
                {
                    var factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
                    var connection = factory.CreateConnection();

                    connection.ConnectionString = this._connectionectionStringMySql;
                    //connection.Open();

                    this.Connection = connection;
                    ConnectionState = connection.State;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region "Método Dispose"

        // Implementação pública do pattern Dispos.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Implementação protegida do pattern Dispose.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) { return; }

            if (disposing)
            {
                // Libere quaisquer outros objetos gerenciados aqui. 
            }

            // Libere quaisquer objetos não gerenciados aqui.
            _disposed = true;
        }

        ~Factory()
        {
            Dispose(false);
        }

        #endregion
    }
}
