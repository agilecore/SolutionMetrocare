using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq.Expressions;
using Dapper;
using Metrocare.Data;
using Metrocare.Common;
using Metrocare.Data.Interfaces;
using Metrocare.Data.Connections;
using System.Data.Common;

namespace Metrocare.Data
{
    public class LogRep : IGenericRepository<LogDto>, IDisposable
    {
        #region "Métodos de acesso a dados"

        public LogRep() { }
                                
        public List<LogDto> GetByFilter(object filters)
        {
            try
            {
                var result = this.GetCollection(filters).ToList();
                return (result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LogDto GetItem(object filters)
        {
            try
            {
                var result = this.GetCollection(filters).FirstOrDefault();
                return (result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                using (var db = new Factory().Connection)
                {
                    db.Open();

                    var rowsAffected = db.Execute(@"DELETE FROM log_acesso WHERE id_log = @id_log", new { id_log = Id }); 
                    if (rowsAffected > 0) { return (true); }

                    db.Close();
                    return (false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public bool Add(LogDto model)
        {
            try
            {
                using (var db = new Factory().Connection)
                {
                    db.Open();
                    var ComandoSql = new StringBuilder();

                    ComandoSql.AppendLine("INSERT INTO log_acesso "); 
                    ComandoSql.AppendLine("(                      ");
                    ComandoSql.AppendLine("    id_usuario,        ");
                    ComandoSql.AppendLine("    dt_log             ");
                    ComandoSql.AppendLine(")                      ");
                    ComandoSql.AppendLine("VALUES                 ");
                    ComandoSql.AppendLine("(                      ");
                    ComandoSql.AppendLine("    @id_usuario,       ");
                    ComandoSql.AppendLine("    @dt_log            ");
                    ComandoSql.AppendLine(")                      "); 

                    var rowsAffected = db.Execute(ComandoSql.ToString(), new { id_usuario = model.id_usuario, dt_log = DateTime.Now });
                    if (rowsAffected > 0) { return (true); }

                    db.Close();
                    return (false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(LogDto model)
        {
            throw new NotImplementedException();
        }

        internal string TreatmentFilter(LogFilter filters)
        {
            var filter = (filters.id_log.GreaterZero()) ? String.Format(" AND a.id_log = @id_log ", filters.id_log.ToString()) : String.Empty;
            filter += (filters.id_usuario.GreaterZero()) ? String.Format(" AND a.id_usuario = @id_usuario ", filters.id_usuario.ToString()) : String.Empty;
            filter += (!filters.nome.IsEmptyOrNull()) ? String.Format(" AND b.nome LIKE @nome ", filters.nome.ToString()) : String.Empty;
            filter += (!filters.email.IsEmptyOrNull()) ? String.Format(" AND b.email LIKE @email ", filters.email.ToString()) : String.Empty;
            filter += (!filters.dt_log.IsDateNull()) ? String.Format(" AND a.dt_log = @dt_log ", filters.dt_log) : String.Empty;

            return (filter);
        }

        internal IEnumerable<LogDto> GetCollection(object filters)
        {
            var obj = (LogFilter)filters;
            var filter = TreatmentFilter(obj);

            using (var db = new Factory().Connection)
            {
                db.Open();

                var ComandoSql = new StringBuilder();
                ComandoSql.AppendLine("SELECT a.id_usuario ");
                ComandoSql.AppendLine("	    , b.nome       ");
                ComandoSql.AppendLine("	    , b.email      ");
                ComandoSql.AppendLine("	    , a.dt_log     ");
                ComandoSql.AppendLine("  FROM log_acesso a ");  
                ComandoSql.AppendLine("     , usuario    b ");
                ComandoSql.AppendLine(" WHERE 1 = 1        ");
                ComandoSql.AppendLine("   AND a.id_usuario = b.id_usuario " + filter);   

                var result = db.Query<LogDto>(ComandoSql.ToString(),
                new
                {
                    id_usuario = obj.id_usuario ,
                    dt_log     = obj.dt_log     ,
                    nome       = obj.nome       ,
                    email      = obj.email      ,
                }).ToList();

                db.Close();
                return (result);
            }
        }
        
        #endregion

        #region "Método Dispose"

        private bool _disposed = false;

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

        ~LogRep()
        {
            Dispose(false);
        }

        #endregion       
    }
}
