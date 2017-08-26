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
    public class ContratoDto : Base
    {
        public System.Int32 ID_PLANO { get; set; }
        public System.Int32 ID_USUARIO { get; set; }
        public System.String NOME { get; set; }
        public System.String DESCRICAO { get; set; }
        public System.DateTime DT_CADASTRO { get; set; }
        public System.DateTime DT_ATIVACAO { get; set; }
        public System.DateTime DT_DESATIVACAO { get; set; }
        public System.String DOCUMENTO { get; set; }
        public System.String STATUS { get; set; }
    }
}

