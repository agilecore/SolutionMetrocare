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
    public class PrestadorRep : IGenericRepository<PrestadorDto>, IDisposable
    {
        #region "Métodos de acesso a dados"

        public PrestadorRep() { }

        public List<PrestadorDto> GetByFilter(object filters)
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

        public PrestadorDto GetItem(object filters)
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

        public bool Add(PrestadorDto model)
        {
            try
            {
                using (var db = new Factory().Connection)
                {
                    var ComandoSql = new StringBuilder();
                    ComandoSql.AppendLine("sp_adiciona_prestador"); 

                    db.Execute(ComandoSql.ToString(), new
                    {
                        v_id_prestador = model.id_prestador,
                        v_nome = model.nome,
                        v_cpf = model.cpf,
                        v_cnpj = model.cnpj,
                        v_email = model.email,
                        v_logradouro = model.logradouro,
                        v_complemento = model.complemento,
                        v_numero = model.numero,
                        v_cep = model.cep,
                        v_bairro = model.bairro,
                        v_cidade = model.cidade,
                        v_uf = model.uf,
                        v_telefone = model.telefone,
                        v_celular = model.celular,
                        v_contato = model.contato,
                        v_dt_cadastro = model.dt_cadastro,
                        v_longitude = model.longitude,
                        v_latitude = model.latitude,
                        v_ibge = model.ibge
                    },  commandType: CommandType.StoredProcedure);



                    return (true);
                }
            }
            catch (Exception ex)
            {
                return (false);
            }  
        }

        public bool Update(PrestadorDto model)
        {
            throw new NotImplementedException();
        }

        internal string TreatmentFilter(object filters)
        {
            var obj = (PrestadorFilter)filters;

            var filter = (obj.id_prestador.GreaterZero() ? String.Format(" AND id_prestador = @id_prestador ") : String.Empty);
            filter += (!obj.nome.IsEmptyOrNull() ? String.Format(" AND nome = @nome ") : String.Empty);
            filter += (!obj.cpf.IsEmptyOrNull() ? String.Format(" AND cpf = @cpf ") : String.Empty);
            filter += (!obj.cnpj.IsEmptyOrNull() ? String.Format(" AND cnpj = @cnpj ") : String.Empty);
            filter += (!obj.email.IsEmptyOrNull() ? String.Format(" AND email = @email ") : String.Empty);
            filter += (!obj.logradouro.IsEmptyOrNull() ? String.Format(" AND logradouro = @logradouro ") : String.Empty);
            filter += (!obj.complemento.IsEmptyOrNull() ? String.Format(" AND complemento = @complemento ") : String.Empty);
            filter += (obj.numero.GreaterZero() ? String.Format(" AND numero = @numero ") : String.Empty);
            filter += (obj.cep.GreaterZero() ? String.Format(" AND cep = @cep ") : String.Empty);
            filter += (!obj.bairro.IsEmptyOrNull() ? String.Format(" AND bairro = @bairro ") : String.Empty);
            filter += (!obj.cidade.IsEmptyOrNull() ? String.Format(" AND cidade = @cidade ") : String.Empty);
            filter += (!obj.uf.IsEmptyOrNull() ? String.Format(" AND uf = @uf ") : String.Empty);
            filter += (!obj.telefone.IsEmptyOrNull() ? String.Format(" AND telefone = @telefone ") : String.Empty);
            filter += (!obj.celular.IsEmptyOrNull() ? String.Format(" AND celular = @celular ") : String.Empty);
            filter += (!obj.contato.IsEmptyOrNull() ? String.Format(" AND contato = @contato ") : String.Empty);
            filter += (!obj.dt_cadastro.IsDateNull() ? String.Format(" AND dt_cadastro = @dt_cadastro ") : String.Empty);
            filter += (obj.longitude.GreaterZero() ? String.Format(" AND longitude = @longitude ") : String.Empty);
            filter += (obj.latitude.GreaterZero() ? String.Format(" AND latitude = @latitude ") : String.Empty);
            filter += (obj.ibge.GreaterZero() ? String.Format(" AND ibge = @ibge ") : String.Empty);
            filter += " LIMIT 10000 ";

            return (filter);
        }

        internal IEnumerable<PrestadorDto> GetCollection(object filters)
        {
            var obj = (PrestadorFilter)filters;
            var filter = TreatmentFilter(obj);

            using (var db = new Factory().Connection)
            {
                db.Open();

                var ComandoSql = new StringBuilder();
                ComandoSql.AppendLine("SELECT id_prestador ");
                ComandoSql.AppendLine("     , nome         ");
                ComandoSql.AppendLine("     , cpf          ");
                ComandoSql.AppendLine("     , cnpj         ");
                ComandoSql.AppendLine("     , email        ");
                ComandoSql.AppendLine("     , logradouro   ");
                ComandoSql.AppendLine("     , complemento  ");
                ComandoSql.AppendLine("     , numero       ");
                ComandoSql.AppendLine("     , cep          ");
                ComandoSql.AppendLine("     , bairro       ");
                ComandoSql.AppendLine("     , cidade       ");
                ComandoSql.AppendLine("     , uf           ");
                ComandoSql.AppendLine("     , telefone     ");
                ComandoSql.AppendLine("     , celular      ");
                ComandoSql.AppendLine("     , contato      ");
                ComandoSql.AppendLine("     , dt_cadastro  ");
                ComandoSql.AppendLine("     , longitude    ");
                ComandoSql.AppendLine("     , latitude     ");
                ComandoSql.AppendLine("     , ibge         ");
                ComandoSql.AppendLine("  FROM prestador    ");
                ComandoSql.AppendLine(" WHERE 1 = 1 " + filter);

                var result = db.Query<PrestadorDto>(ComandoSql.ToString(),
                new
                {
                    id_prestador = obj.id_prestador,
                    nome = obj.nome,
                    cpf = obj.cpf,
                    cnpj = obj.cnpj,
                    email = obj.email,
                    logradouro = obj.logradouro,
                    complemento = obj.complemento,
                    numero = obj.numero,
                    cep = obj.cep,
                    bairro = obj.bairro,
                    cidade = obj.cidade,
                    uf = obj.uf,
                    telefone = obj.telefone,
                    celular = obj.celular,
                    contato = obj.contato,
                    dt_cadastro = obj.dt_cadastro,
                    longitude = obj.longitude,
                    latitude = obj.latitude,
                    ibge = obj.ibge
                });

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

        ~PrestadorRep()
        {
            Dispose(false);
        }

        #endregion
    }
}
