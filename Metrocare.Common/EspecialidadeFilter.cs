using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    public partial class EspecialidadeFilter
    {
        public EspecialidadeFilter()
        {
            this.id_especialidade = 0;
            this.nome = String.Empty;
            this.status = String.Empty;
        }     
        public Int32 id_especialidade {get; set;}
        public String nome { get; set; }
        public String status { get; set; }
    }
}
