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
using System.Globalization;

namespace Metrocare.Data
{
    public class UsuarioRep : IGenericRepository<UsuarioDto>, IDisposable
    {
        #region "Métodos de acesso a dados"

        public UsuarioRep() { }
                                                                            
        public List<UsuarioDto> GetByFilter(object filters)
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
      
        public UsuarioDto GetItem(object filters)
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

        public bool Add(UsuarioDto model)
        {
            try
            {
                using (var db = new Factory().Connection)
                {
                    
                    var ComandoSql = new StringBuilder();
                    ComandoSql.AppendLine("sp_adiciona_usuario");
                    var rowsAffected = db.Execute(ComandoSql.ToString(), new
                    {
                       v_id_usuario     = model.id_usuario    ,
                       v_nome           = model.nome          ,
                       v_cpf            = model.cpf           ,
                       v_rg             = model.rg            ,
                       v_logradouro     = model.logradouro    ,
                       v_complemento    = model.complemento   ,
                       v_numero         = model.numero        ,
                       v_cep            = model.cep           ,
                       v_bairro         = model.bairro        ,
                       v_cidade         = model.cidade        ,
                       v_uf             = model.uf            ,
                       v_email          = model.email         ,
                       v_telefone       = model.telefone      ,
                       v_celular        = model.celular       ,
                       v_contato        = model.contato       ,
                       v_dt_cadastro    = model.dt_cadastro   ,
                       v_dt_nascimento  = model.dt_nascimento ,
                       v_longitude      = model.longitude     ,
                       v_latitude       = model.latitude      ,
                       v_ibge           = model.ibge          ,
                       v_senha          = model.senha         ,
                       v_status         = model.status       
                    }, commandType: CommandType.StoredProcedure);

                    if (rowsAffected > 0) { return (true); } else { return (false); }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(UsuarioDto model)
        {
            throw new NotImplementedException();
        }

        internal string TreatmentFilter(object filters)
        {
            var obj = (UsuarioFilter)filters;

            var filter = (obj.id_usuario.GreaterZero() ? String.Format(" AND id_usuario = @id_usuario ") : String.Empty);
            filter += (!obj.nome.IsEmptyOrNull() ? String.Format(" AND nome = @nome ") : String.Empty);
            filter += (!obj.cpf.IsEmptyOrNull() ? String.Format(" AND cpf = @cpf ") : String.Empty);
            filter += (!obj.logradouro.IsEmptyOrNull() ? String.Format(" AND logradouro = @logradouro ") : String.Empty);
            filter += (!obj.complemento.IsEmptyOrNull() ? String.Format(" AND complemento = @complemento ") : String.Empty);
            filter += (obj.numero.GreaterZero() ? String.Format(" AND numero = @numero ") : String.Empty);
            filter += (obj.cep.GreaterZero() ? String.Format(" AND cep = @cep ") : String.Empty);
            filter += (!obj.bairro.IsEmptyOrNull() ? String.Format(" AND bairro = @bairro ") : String.Empty);
            filter += (!obj.cidade.IsEmptyOrNull() ? String.Format(" AND cidade = @cidade ") : String.Empty);
            filter += (!obj.uf.IsEmptyOrNull() ? String.Format(" AND uf = @uf ") : String.Empty);
            filter += (!obj.email.IsEmptyOrNull() ? String.Format(" AND email = @email ") : String.Empty);
            filter += (!obj.telefone.IsEmptyOrNull() ? String.Format(" AND telefone = @telefone ") : String.Empty);
            filter += (!obj.celular.IsEmptyOrNull() ? String.Format(" AND celular = @celular ") : String.Empty);
            filter += (!obj.contato.IsEmptyOrNull() ? String.Format(" AND contato = @contato ") : String.Empty);
            filter += (!obj.dt_cadastro.IsDateNull() ? String.Format(" AND dt_cadastro = @dt_cadastro ") : String.Empty);
            filter += (!obj.dt_nascimento.IsDateNull() ? String.Format(" AND dt_nascimento = @dt_nascimento ") : String.Empty);
            filter += (obj.longitude.GreaterZero() ? String.Format(" AND longitude = @longitude ") : String.Empty);
            filter += (obj.latitude.GreaterZero() ? String.Format(" AND latitude = @latitude ") : String.Empty);
            filter += (obj.ibge.GreaterZero() ? String.Format(" AND ibge = @ibge ") : String.Empty);
            filter += (!obj.senha.IsEmptyOrNull() ? String.Format(" AND senha = @senha ") : String.Empty);
            filter += (!obj.status.IsEmptyOrNull() ? String.Format(" AND status= @status ") : String.Empty);

            return (filter);
        }

        internal IEnumerable<UsuarioDto> GetCollection(object filters)
        {
            var obj = (UsuarioFilter)filters;
            var filter = TreatmentFilter(obj);

            using (var db = new Factory().Connection)
            {
                db.Open();

                var ComandoSql = new StringBuilder();
                ComandoSql.AppendLine("SELECT id_usuario     ");
                ComandoSql.AppendLine("	    , nome           ");
                ComandoSql.AppendLine("	    , cpf            ");                    
                ComandoSql.AppendLine("	    , rg             ");
                ComandoSql.AppendLine("	    , logradouro     ");
                ComandoSql.AppendLine("	    , complemento    ");
                ComandoSql.AppendLine("	    , numero         ");
                ComandoSql.AppendLine("	    , cep            ");
                ComandoSql.AppendLine("	    , bairro         ");
                ComandoSql.AppendLine("	    , cidade         ");
                ComandoSql.AppendLine("	    , uf             ");
                ComandoSql.AppendLine("	    , email          ");
                ComandoSql.AppendLine("	    , telefone       ");
                ComandoSql.AppendLine("	    , celular        ");
                ComandoSql.AppendLine("	    , contato        ");
                ComandoSql.AppendLine("	    , dt_cadastro    ");
                ComandoSql.AppendLine("	    , dt_nascimento  ");
                ComandoSql.AppendLine("	    , longitude      ");
                ComandoSql.AppendLine("	    , latitude       ");
                ComandoSql.AppendLine("	    , ibge           ");
                ComandoSql.AppendLine("	    , senha          ");
                ComandoSql.AppendLine("	    , status         ");
                ComandoSql.AppendLine("  FROM usuario        ");
                ComandoSql.AppendLine(" WHERE 1 = 1 " + filter);

                var result = db.Query<UsuarioDto>(ComandoSql.ToString(),
                new
                {
                    id_usuario = obj.id_usuario,
                    nome = obj.nome,
                    cpf = obj.cpf,
                    logradouro = obj.logradouro,
                    complemento = obj.complemento,
                    numero = obj.numero,
                    cep = obj.cep,
                    bairro = obj.bairro,
                    cidade = obj.cidade,
                    uf = obj.uf,
                    email = obj.email,
                    telefone = obj.telefone,
                    celular = obj.celular,
                    contato = obj.contato,
                    dt_cadastro = obj.dt_cadastro,
                    dt_nascimento = obj.dt_nascimento,
                    longitude = obj.longitude,
                    latitude = obj.latitude,
                    ibge = obj.ibge,
                    senha = obj.senha,
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

        ~UsuarioRep()
        {
            Dispose(false);
        }

        #endregion     
    }
}
