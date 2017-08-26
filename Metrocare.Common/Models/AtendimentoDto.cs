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
    public class AtendimentoDto : Base
    {
        public System.Int32 ID_AGENDA { get; set; }
        public System.DateTime DT_ATENDIMENTO { get; set; }
        public System.String HORA { get; set; }
        public System.String CONFIRMADO { get; set; }
        public System.String ATENDIDO { get; set; }
    }
}

