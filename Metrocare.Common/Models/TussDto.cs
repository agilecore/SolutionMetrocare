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
    public class TussDto : Base
    {
        public System.String ID_PROC_AMB90 { get; set; }
        public System.String ID_PROC_AMB92 { get; set; }
        public System.String ID_PROC_AMB96 { get; set; }
        public System.String ID_PROC_CBHPM5 { get; set; }
        public System.String ID_PROC_TUSS { get; set; }
        public System.String NOME { get; set; }
    }
}

