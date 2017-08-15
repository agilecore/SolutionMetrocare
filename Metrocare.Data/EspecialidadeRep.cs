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
    public class EspecialidadeRep : IGenericRepository<EspecialidadeDto>, IDisposable
    {
        #region "Métodos de acesso a dados"

        public EspecialidadeRep() { }
                             
        public List<EspecialidadeDto> GetByFilter(object filters)
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

        public EspecialidadeDto GetItem(object filters)
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
            throw new NotImplementedException();
        }

        public bool Add(EspecialidadeDto model)
        {
            try
            {
                using (var db = new Factory().Connection)
                {
                    var ComandoSql = new StringBuilder();
                    ComandoSql.AppendLine("sp_adiciona_especialidade");
                    var rowsAffected = db.Execute(ComandoSql.ToString(), new
                    {
                        v_id_prestador = model.id_especialidade,
                        v_nome = model.nome,
                        v_status = model.status
                    }, commandType: CommandType.StoredProcedure);

                    if (rowsAffected > 0) { return (true); } else { return (false); }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(EspecialidadeDto model)
        {
            throw new NotImplementedException();
        }

        internal string TreatmentFilter(object filters)
        {
            var obj = (EspecialidadeFilter)filters;

            var filter = (obj.id_especialidade.GreaterZero() ? String.Format(" AND id_especialidade = @id_especialidade ") : String.Empty);
            filter += (!obj.nome.IsEmptyOrNull() ? String.Format(" AND nome = @nome ") : String.Empty);
            filter += (!obj.status.IsEmptyOrNull() ? String.Format(" AND status = @status ") : String.Empty);

            return (filter);
        }

        internal IEnumerable<EspecialidadeDto> GetCollection(object filters)
        {
            var obj = (EspecialidadeFilter)filters;
            var filter = TreatmentFilter(obj);

            using (var db = new Factory().Connection)
            {
                db.Open();

                var ComandoSql = new StringBuilder();
                ComandoSql.AppendLine("SELECT id_especialidade ");
                ComandoSql.AppendLine("	    , nome             ");
                ComandoSql.AppendLine("	    , status           ");
                ComandoSql.AppendLine("  FROM especialidade    ");
                ComandoSql.AppendLine(" WHERE 1 = 1 " + filter  );

                var result = db.Query<EspecialidadeDto>(ComandoSql.ToString(),
                new
                {
                    id_usuario = obj.id_especialidade,
                    nome = obj.nome,
                    status = obj.status
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

        ~EspecialidadeRep()
        {
            Dispose(false);
        }

        #endregion     
    }
}
