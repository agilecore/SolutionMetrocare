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
    public class LoginRep : IGenericRepository<LoginDto>, IDisposable
    {
        #region "Métodos de acesso a dados"

        public LoginRep() {  }
                                
        public List<LoginDto> GetByFilter(object filters)
        {
            throw new NotImplementedException();
        }

        public LoginDto GetItem(object filters)
        {
            try
            {
                var obj = (LoginFilter)filters;
                var filter = TreatmentFilter(filters); 

                using (var db = new Factory().Connection)
                {
                    db.Open();

                    var ComandoSql = new StringBuilder();
                    ComandoSql.Append("SELECT id_usuario     ");
                    ComandoSql.Append("	    , nome 		     ");
                    ComandoSql.Append("	    , cpf 			 ");
                    ComandoSql.Append("	    , logradouro 	 ");
                    ComandoSql.Append("	    , complemento 	 ");
                    ComandoSql.Append("	    , numero 		 ");
                    ComandoSql.Append("	    , cep 			 ");
                    ComandoSql.Append("	    , bairro 		 ");
                    ComandoSql.Append("	    , cidade 		 ");
                    ComandoSql.Append("	    , uf 			 ");
                    ComandoSql.Append("	    , email 		 ");
                    ComandoSql.Append("	    , telefone 	     ");
                    ComandoSql.Append("	    , celular 		 ");
                    ComandoSql.Append("	    , contato 		 ");
                    ComandoSql.Append("	    , dt_cadastro 	 ");
                    ComandoSql.Append("	    , dt_nascimento  ");
                    ComandoSql.Append("	    , longitude 	 ");
                    ComandoSql.Append("	    , latitude 	     ");
                    ComandoSql.Append("	    , ibge 		     ");
                    ComandoSql.Append("	    , senha 		 ");
                    ComandoSql.Append("	    , status 		 ");
                    ComandoSql.Append("  FROM usuario        ");
                    ComandoSql.Append(" WHERE 1 = 1 " + filter); 

                    var result = db.Query<LoginDto>(ComandoSql.ToString(),
                                               new { id_usuario = obj.id_usuario  
                                                   ,      email = obj.email       
                                                   ,      senha = obj.senha       
                                                   ,     status = obj.status 
                                                   }).SingleOrDefault();

                    db.Close();
                    return (result);
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);  
            }
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        } 

        public bool Add(LoginDto model)
        {
            throw new NotImplementedException();
        }

        public bool Update(LoginDto model)
        {
            throw new NotImplementedException();
        }

        internal string TreatmentFilter(object filters)
        {
            var obj = (LoginFilter)filters;

            var filter = (obj.Id.GreaterZero()) ? String.Format(" AND id_usuario = @id_usuario ", obj.Id.ToString()) : String.Empty;
            filter += (!obj.email.IsEmptyOrNull()) ? String.Format(" AND email = @email ", obj.email.ToString()) : String.Empty;
            filter += (!obj.senha.IsEmptyOrNull()) ? String.Format(" AND senha = @senha ", obj.senha.ToString()) : String.Empty;
            filter += (!obj.status.IsEmptyOrNull()) ? String.Format(" AND status = @status ", obj.status.ToString()) : String.Empty;

            return (filter);
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

        ~LoginRep()
        {
            Dispose(false);
        }

        #endregion       
    }
}
