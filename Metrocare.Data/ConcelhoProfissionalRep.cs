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
    public class ConcelhoProfissionalRep : IGenericRepository<ConcelhoProfissionalDto>, IDisposable
    {
        #region "Métodos de acesso a dados"

        public ConcelhoProfissionalRep() { }
                        
        public List<ConcelhoProfissionalDto> GetByFilter(object filters)
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

        public ConcelhoProfissionalDto GetItem(object filters)
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

        public bool Add(ConcelhoProfissionalDto model)
        {
            try
            {
                using (var db = new Factory().Connection)
                {
                    var ComandoSql = new StringBuilder();
                    ComandoSql.AppendLine("sp_adiciona_concelho_profissional");
                    var rowsAffected = db.Execute(ComandoSql.ToString(), new
                    {
                       v_id_concelho_profissional = model.id_concelho_profissional,
                       v_nome = model.nome,
                       v_descricao = model.descricao  
                    }, commandType: CommandType.StoredProcedure);

                    if (rowsAffected > 0) { return (true); } else { return (false); }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ConcelhoProfissionalDto model)
        {
            throw new NotImplementedException();
        }

        internal string TreatmentFilter(object filters)
        {
            var obj = (ConcelhoProfissionalFilter)filters;

            var filter = (obj.id_concelho_profissional.GreaterZero() ? String.Format(" AND id_concelho_profissional = @id_concelho_profissional ") : String.Empty);
            filter += (!obj.nome.IsEmptyOrNull() ? String.Format(" AND nome = @nome ") : String.Empty);
            filter += (!obj.descricao.IsEmptyOrNull() ? String.Format(" AND descricao = @descricao ") : String.Empty);

            return (filter);
        }
       
        internal IEnumerable<ConcelhoProfissionalDto> GetCollection(object filters)
        {
            var obj = (ConcelhoProfissionalFilter)filters;
            var filter = TreatmentFilter(obj);

            using (var db = new Factory().Connection)
            {
                db.Open();

                var ComandoSql = new StringBuilder();
                ComandoSql.AppendLine("SELECT id_concelho_profissional ");
                ComandoSql.AppendLine("	    , nome                     ");
                ComandoSql.AppendLine("	    , descricao                ");
                ComandoSql.AppendLine("  FROM concelho_profissional    ");
                ComandoSql.AppendLine(" WHERE 1 = 1 " + filter          );

                var result = db.Query<ConcelhoProfissionalDto>(ComandoSql.ToString(),
                new
                {
                    id_concelho_profissional = obj.id_concelho_profissional,
                    nome = obj.nome,
                    descricao = obj.descricao
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

        ~ConcelhoProfissionalRep()
        {
            Dispose(false);
        }

        #endregion     
    }
}
