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
    public class CredenciadoEnderecoDto : Base
    {
        public System.Int32 ID_CREDENCIADO { get; set; }
        public System.String LOGRADOURO { get; set; }
        public System.String COMPLEMENTO { get; set; }
        public System.Int32 NUMERO { get; set; }
        public System.Int32 CEP { get; set; }
        public System.String BAIRRO { get; set; }
        public System.String CIDADE { get; set; }
        public System.String UF { get; set; }
        public System.String PRINCIPAL { get; set; }
    }
}

