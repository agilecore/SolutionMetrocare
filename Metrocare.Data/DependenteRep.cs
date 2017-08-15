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
    public class DependenteRep : IGenericRepository<DependenteDto>, IDisposable
    {
        #region "Métodos de acesso a dados"

        public DependenteRep() { }

        public List<DependenteDto> GetByFilter(object filters)
        {
            try
            {
                var result = this.GetCollection(filters);
                return (result.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DependenteDto GetItem(object filters)
        {
            try
            {
                var result = this.GetCollection(filters);
                return (result.FirstOrDefault());
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

        public bool Add(DependenteDto model)
        {
            try
            {
                using (var db = new Factory().Connection)
                {
                    var ComandoSql = new StringBuilder();
                    ComandoSql.AppendLine("sp_adiciona_dependente");
                    var rowsAffected = db.Execute(ComandoSql.ToString(), new
                    {
                       v_id_dependente   = model.id_dependente   ,
                       v_id_beneficiario = model.id_beneficiario ,
                       v_id_parentesco   = model.id_parentesco   ,
                       v_id_carteira     = model.id_carteira     ,
                       v_id_usuario      = model.id_usuario      ,
                       v_nome            = model.nome            ,
                       v_cpf             = model.cpf             ,
                       v_rg              = model.rg              ,
                       v_logradouro      = model.logradouro      ,
                       v_complemento     = model.complemento     ,
                       v_numero          = model.numero          ,
                       v_cep             = model.cep             ,
                       v_bairro          = model.bairro          ,
                       v_cidade          = model.cidade          ,
                       v_uf              = model.uf              ,
                       v_email           = model.email           ,
                       v_dt_cadastro     = model.dt_cadastro   
                    }, commandType: CommandType.StoredProcedure);

                    if (rowsAffected > 0) { return (true); } else { return (false); }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(DependenteDto model)
        {
            throw new NotImplementedException();
        }

        internal string TreatmentFilter(object filters)
        {
            var obj = (DependenteFilter)filters;

            var filter = (obj.id_dependente.GreaterZero() ? String.Format(" AND id_dependente = @id_dependente ") : String.Empty);
            filter += (obj.id_beneficiario.GreaterZero() ? String.Format(" AND id_beneficiario = @id_beneficiario ") : String.Empty);
            filter += (obj.id_parentesco.GreaterZero() ? String.Format(" AND id_parentesco = @id_parentesco ") : String.Empty);
            filter += (obj.id_carteira.GreaterZero() ? String.Format(" AND id_carteira = @id_carteira ") : String.Empty);
            filter += (obj.id_usuario.GreaterZero() ? String.Format(" AND id_usuario = @id_usuario ") : String.Empty);
            filter += (!obj.nome.IsEmptyOrNull() ? String.Format(" AND nome = @nome ") : String.Empty);
            filter += (!obj.cpf.IsEmptyOrNull() ? String.Format(" AND cpf = @cpf ") : String.Empty);
            filter += (!obj.rg.IsEmptyOrNull() ? String.Format(" AND rg = @rg ") : String.Empty);
            filter += (!obj.logradouro.IsEmptyOrNull() ? String.Format(" AND logradouro = @logradouro ") : String.Empty);
            filter += (!obj.complemento.IsEmptyOrNull() ? String.Format(" AND complemento = @complemento ") : String.Empty);
            filter += (obj.numero.GreaterZero() ? String.Format(" AND numero = @numero ") : String.Empty);
            filter += (obj.cep.GreaterZero() ? String.Format(" AND cep = @cep ") : String.Empty);
            filter += (!obj.bairro.IsEmptyOrNull() ? String.Format(" AND bairro = @bairro ") : String.Empty);
            filter += (!obj.cidade.IsEmptyOrNull() ? String.Format(" AND cidade = @cidade ") : String.Empty);
            filter += (!obj.uf.IsEmptyOrNull() ? String.Format(" AND uf = @uf ") : String.Empty);
            filter += (!obj.email.IsEmptyOrNull() ? String.Format(" AND email = @email ") : String.Empty);
            filter += (!obj.dt_cadastro.IsDateNull() ? String.Format(" AND dt_cadastro = @dt_cadastro ") : String.Empty);

            return (filter);
        }

        internal IEnumerable<DependenteDto> GetCollection(object filters)
        {
            var obj = (DependenteFilter)filters;
            var filter = TreatmentFilter(obj);

            using (var db = new Factory().Connection)
            {
                db.Open();

                var ComandoSql = new StringBuilder();
                ComandoSql.AppendLine("SELECT id_dependente    ");
                ComandoSql.AppendLine("	    , id_beneficiario  ");
                ComandoSql.AppendLine("	    , id_parentesco    ");
                ComandoSql.AppendLine("	    , id_carteira      ");
                ComandoSql.AppendLine("	    , id_usuario       ");
                ComandoSql.AppendLine("	    , nome             ");
                ComandoSql.AppendLine("	    , cpf              ");
                ComandoSql.AppendLine("	    , rg               ");
                ComandoSql.AppendLine("	    , logradouro       ");
                ComandoSql.AppendLine("	    , complemento      ");
                ComandoSql.AppendLine("	    , numero           ");
                ComandoSql.AppendLine("	    , cep              ");
                ComandoSql.AppendLine("	    , bairro           ");
                ComandoSql.AppendLine("	    , cidade           ");
                ComandoSql.AppendLine("	    , uf               ");
                ComandoSql.AppendLine("	    , email            ");
                ComandoSql.AppendLine("	    , dt_cadastro      ");
                ComandoSql.AppendLine("  FROM dependente       ");
                ComandoSql.AppendLine(" WHERE 1 = 1 " + filter  );

                var result = db.Query<DependenteDto>(ComandoSql.ToString(),
                new
                {
                   id_dependente   = obj.id_dependente   ,  
                   id_beneficiario = obj.id_beneficiario , 
                   id_parentesco   = obj.id_parentesco   , 
                   id_carteira     = obj.id_carteira     , 
                   id_usuario      = obj.id_usuario      , 
                   nome            = obj.nome            , 
                   cpf             = obj.cpf             , 
                   rg              = obj.rg              , 
                   logradouro      = obj.logradouro      , 
                   complemento     = obj.complemento     , 
                   numero          = obj.numero          , 
                   cep             = obj.cep             , 
                   bairro          = obj.bairro          , 
                   cidade          = obj.cidade          , 
                   uf              = obj.uf              , 
                   email           = obj.email           , 
                   dt_cadastro     = obj.dt_cadastro    
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

        ~DependenteRep()
        {
            Dispose(false);
        }

        #endregion     
    }
}
