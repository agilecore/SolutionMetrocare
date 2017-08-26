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
    public class AgendaDto : Base
    {
        public System.Int32 ID_CREDENCIADO { get; set; }
        public System.Int32 ID_PRESTADOR { get; set; }
        public System.Int32 ID_DIA { get; set; }
        public System.Int32 ID_PERIODO { get; set; }
    }
}

