using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    /// <summary>
    /// Nao alterar essa classe pois ela é o objeto identico a tabela do banco de dados.
    /// </summary>
    public class CredenciadoDto : Base
    {
        public System.Int32 ID_CONCELHO_PROFISSIONAL { get; set; }
        public System.String NOME { get; set; }
        public System.Int32 NRO_CONCELHO { get; set; }
        public System.String UF_CONCELHO { get; set; }
        public System.String CPF { get; set; }
        public System.String CNPJ { get; set; }
        public System.String EMAIL { get; set; }
        public System.String TELEFONE { get; set; }
        public System.String CELULAR { get; set; }
        public System.String CONTATO { get; set; }
        public System.DateTime DT_CADASTRO { get; set; }
        public System.DateTime DT_NASCIMENTO { get; set; }
        public System.Int32 LONGITUDE { get; set; }
        public System.Int32 LATITUDE { get; set; }
        public Nullable<System.Int32> IBGE { get; set; }
    }
}

