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
    public class BeneficiarioRep : IGenericRepository<BeneficiarioDto>, IDisposable
    {
        #region "Métodos de acesso a dados"

        public BeneficiarioRep() { }

        public List<BeneficiarioDto> GetByFilter(object filters)
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

        public BeneficiarioDto GetItem(object filters)
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

        public bool Add(BeneficiarioDto model)
        {
            try
            {
                using (var db = new Factory().Connection)
                {
                    var ComandoSql = new StringBuilder();
                    ComandoSql.AppendLine("sp_adiciona_beneficiario");

                    var rowsAffected = db.Execute(ComandoSql.ToString(), new
                    {
                        v_id_usuario = model.id_usuario,
                        v_id_carteira = model.id_carteira,
                        v_id_beneficiario = model.id_beneficiario,
                        v_nome = model.nome,
                        v_cpf = model.cpf,
                        v_rg = model.rg,
                        v_logradouro = model.logradouro,
                        v_complemento = model.complemento,
                        v_numero = model.numero,
                        v_cep = model.cep,
                        v_bairro = model.bairro,
                        v_cidade = model.cidade,
                        v_telefone = model.telefone,
                        v_celular = model.celular,
                        v_uf = model.uf,
                        v_email = model.email,
                        v_dt_cadastro = model.dt_cadastro,
                        v_dt_nascimento = model.dt_nascimento,
                        v_longitude = model.longitude,
                        v_latitude = model.latitude,
                        v_ibge = model.ibge,
                    }, commandType: CommandType.StoredProcedure);

                    if (rowsAffected > 0) { return (true); } else { return (false); }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(BeneficiarioDto model)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<BeneficiarioDto> GetCollection(object filters)
        {
            var obj = (BeneficiarioFilter)filters;
            var filter = TreatmentFilter(obj);

            using (var db = new Factory().Connection)
            {
                db.Open();

                var ComandoSql = new StringBuilder();
                ComandoSql.AppendLine("SELECT id_beneficiario ");
                ComandoSql.AppendLine("	    , id_carteira     ");
                ComandoSql.AppendLine("	    , id_usuario      ");
                ComandoSql.AppendLine("	    , nome            ");
                ComandoSql.AppendLine("	    , cpf             ");
                ComandoSql.AppendLine("	    , rg              ");
                ComandoSql.AppendLine("	    , logradouro      ");
                ComandoSql.AppendLine("	    , complemento     ");
                ComandoSql.AppendLine("	    , numero          ");
                ComandoSql.AppendLine("	    , cep             ");
                ComandoSql.AppendLine("	    , bairro          ");
                ComandoSql.AppendLine("	    , cidade          ");
                ComandoSql.AppendLine("	    , uf              ");
                ComandoSql.AppendLine("	    , email           ");
                ComandoSql.AppendLine("	    , dt_cadastro     ");
                ComandoSql.AppendLine("	    , dt_nascimento   ");
                ComandoSql.AppendLine("	    , celular         ");
                ComandoSql.AppendLine("	    , telefone        ");
                ComandoSql.AppendLine("	    , latitude        ");
                ComandoSql.AppendLine("	    , longitude       ");
                ComandoSql.AppendLine("	    , ibge            ");
                ComandoSql.AppendLine("  FROM beneficiario    ");
                ComandoSql.AppendLine(" WHERE 1 = 1 " + filter );

                var result = db.Query<BeneficiarioDto>(ComandoSql.ToString(),
                new
                {
                    v_id_beneficiario = obj.id_beneficiario,
                    v_id_carteira = obj.id_carteira,
                    v_id_usuario = obj.id_usuario,
                    v_nome = obj.nome,
                    v_cpf = obj.cpf,
                    v_rg = obj.rg,
                    v_logradouro = obj.logradouro,
                    v_complemento = obj.complemento,
                    v_numero = obj.numero,
                    v_cep = obj.cep,
                    v_bairro = obj.bairro,
                    v_cidade = obj.cidade,
                    v_uf = obj.uf,
                    v_email = obj.email,
                    v_dt_cadastro = obj.dt_cadastro,
                    v_dt_nascimento = obj.dt_nascimento,
                    v_celular = obj.celular,
                    v_telefone = obj.telefone,
                    v_latitude = obj.latitude,
                    v_longitude = obj.longitude, 
                    v_ibge = obj.ibge
                }).ToList();

                db.Close();
                return (result);
            }
        }

        internal string TreatmentFilter(object filters)
        {
            var obj = (BeneficiarioFilter)filters;

            var filter = (obj.id_beneficiario.GreaterZero() ? String.Format(" AND id_beneficiario = @id_beneficiario ") : String.Empty);
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
            filter += (!obj.dt_nascimento.IsDateNull() ? String.Format(" AND dt_nascimento = @dt_nascimento ") : String.Empty);
            filter += (!obj.telefone.IsEmptyOrNull() ? String.Format(" AND telefone = @telefone ") : String.Empty);
            filter += (!obj.celular.IsEmptyOrNull() ? String.Format(" AND celular = @celular ") : String.Empty);
            filter += (obj.latitude.GreaterZero() ? String.Format(" AND latitude = @latitude ") : String.Empty);
            filter += (obj.longitude.GreaterZero() ? String.Format(" AND longitude = @longitude ") : String.Empty);
            filter += (obj.ibge.GreaterZero() ? String.Format(" AND ibge = @ibge ") : String.Empty); 

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

        ~BeneficiarioRep()
        {
            Dispose(false);
        }

        #endregion     
    }
}
