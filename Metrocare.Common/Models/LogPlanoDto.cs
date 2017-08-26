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
    public class LogPlanoDto : Base
    {
        public System.Int32 ID_ALTERACAO { get; set; }
        public System.Int32 ID_USUARIO { get; set; }
        public System.DateTime DT_ALTERACAO { get; set; }
    }
}

