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
    public class CredenciadoRep : IGenericRepository<CredenciadoDto>, IDisposable
    {
        #region "Métodos de acesso a dados"

        public CredenciadoRep() { }

        public List<CredenciadoDto> GetAll()
        {
            throw new NotImplementedException();
        }
                                
        public List<CredenciadoDto> GetByFilter(object filters)
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

        public CredenciadoDto GetItem(object filters)
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

        public bool Add(CredenciadoDto model)
        {
            try
            {
                using (var db = new Factory().Connection)
                {
                    var ComandoSql = new StringBuilder();
                    ComandoSql.AppendLine("sp_adiciona_credenciado");
                    var rowsAffected = db.Execute(ComandoSql.ToString(), new
                    {
                        v_id_credenciado             = model.id_credenciado            ,
                        v_id_concelho_profissional   = model.id_concelho_profissional  ,
                        v_nome                       = model.nome                      ,
                        v_nro_concelho               = model.nro_concelho              ,
                        v_uf_concelho                = model.uf_concelho               ,
                        v_cpf                        = model.cpf                       ,
                        v_cnpj                       = model.cnpj                      ,
                        v_email                      = model.email                     ,
                        v_telefone                   = model.telefone                  ,
                        v_celular                    = model.celular                   ,
                        v_contato                    = model.contato                   ,
                        v_dt_cadastro                = model.dt_cadastro               ,
                        v_dt_nascimento              = model.dt_nascimento             ,
                        v_longitude                  = model.longitude                 ,
                        v_latitude                   = model.latitude                  ,
                        v_ibge                       = model.ibge                      
                    }, commandType: CommandType.StoredProcedure);

                    if (rowsAffected > 0) { return (true); } else { return (false); }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(CredenciadoDto model)
        {
            throw new NotImplementedException();
        }

        internal String TreatmentFilter(object filters)
        {
            var obj = (CredenciadoFilter)filters;

            var filter = (obj.id_concelho_profissional.GreaterZero() ? String.Format(" AND id_concelho_profissional = @id_concelho_profissional ") : String.Empty);
            filter += (!obj.nome.IsEmptyOrNull() ? String.Format(" AND nome = @nome ") : String.Empty);
            filter += (obj.nro_concelho.GreaterZero() ? String.Format(" AND nro_concelho = @nro_concelho ") : String.Empty);
            filter += (!obj.uf_concelho.IsEmptyOrNull() ? String.Format(" AND uf_concelho = @uf_concelho ") : String.Empty);
            filter += (!obj.cpf.IsEmptyOrNull() ? String.Format(" AND cpf = @cpf ") : String.Empty);
            filter += (!obj.cnpj.IsEmptyOrNull() ? String.Format(" AND cnpj = @cnpj ") : String.Empty);
            filter += (!obj.email.IsEmptyOrNull() ? String.Format(" AND email = @email ") : String.Empty);
            filter += (!obj.telefone.IsEmptyOrNull() ? String.Format(" AND telefone = @telefone ") : String.Empty);
            filter += (!obj.celular.IsEmptyOrNull() ? String.Format(" AND celular = @celular ") : String.Empty);
            filter += (!obj.contato.IsEmptyOrNull() ? String.Format(" AND contato = @contato ") : String.Empty);
            filter += (!obj.dt_cadastro.IsDateNull() ? String.Format(" AND dt_cadastro = @dt_cadastro ") : String.Empty);
            filter += (!obj.dt_nascimento.IsDateNull() ? String.Format(" AND dt_nascimento = @dt_nascimento ") : String.Empty);
            filter += (obj.longitude.GreaterZero() ? String.Format(" AND longitude = @longitude ") : String.Empty);
            filter += (obj.latitude.GreaterZero() ? String.Format(" AND latitude = @latitude ") : String.Empty);
            filter += (obj.ibge.GreaterZero() ? String.Format(" AND ibge = @ibge ") : String.Empty);
            filter += " LIMIT 10000 ";

            return (filter);
        }

        internal IEnumerable<CredenciadoDto> GetCollection(object filters)
        {
            var obj = (CredenciadoFilter)filters;
            var filter = TreatmentFilter(obj);

            using (var db = new Factory().Connection)
            {
                db.Open();

                var ComandoSql = new StringBuilder();
                ComandoSql.AppendLine("SELECT id_credenciado           ");
                ComandoSql.AppendLine("     , id_concelho_profissional ");
                ComandoSql.AppendLine("     , nome                     ");
                ComandoSql.AppendLine("     , nro_concelho             ");
                ComandoSql.AppendLine("     , uf_concelho              ");
                ComandoSql.AppendLine("     , cpf                      ");
                ComandoSql.AppendLine("     , cnpj                     ");
                ComandoSql.AppendLine("     , email                    ");
                ComandoSql.AppendLine("     , telefone                 ");
                ComandoSql.AppendLine("     , celular                  ");
                ComandoSql.AppendLine("     , contato                  ");
                ComandoSql.AppendLine("     , dt_cadastro              ");
                ComandoSql.AppendLine("     , dt_nascimento            ");
                ComandoSql.AppendLine("     , longitude                ");
                ComandoSql.AppendLine("     , latitude                 ");
                ComandoSql.AppendLine("     , ibge                     ");
                ComandoSql.AppendLine("  FROM credenciado              ");
                ComandoSql.AppendLine(" WHERE 1 = 1 " + filter);

                var result = db.Query<CredenciadoDto>(ComandoSql.ToString(),
                new
                {
                    id_credenciado             = obj.id_credenciado              ,  
                    id_concelho_profissional   = obj.id_concelho_profissional    ,
                    nome                       = obj.nome                        ,
                    nro_concelho               = obj.nro_concelho                ,
                    uf_concelho                = obj.uf_concelho                 ,
                    cpf                        = obj.cpf                         ,
                    cnpj                       = obj.cnpj                        ,
                    email                      = obj.email                       ,
                    telefone                   = obj.telefone                    ,
                    celular                    = obj.celular                     ,
                    contato                    = obj.contato                     ,
                    dt_cadastro                = obj.dt_cadastro                 ,
                    dt_nascimento              = obj.dt_nascimento               ,
                    longitude                  = obj.longitude                   ,
                    latitude                   = obj.latitude                    ,
                    ibge                       = obj.ibge 
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

        ~CredenciadoRep()
        {
            Dispose(false);
        }

        #endregion     
    }
}
