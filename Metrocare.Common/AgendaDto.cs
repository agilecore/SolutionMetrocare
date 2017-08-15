using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    public partial class AgendaDto
    {
        public AgendaDto()
        {
            this.id_agenda = 0;
            this.credenciado = null;
            this.dt_agenda = DateTime.Now;
        }  
        public Int32 id_agenda { get; set; }
        public CredenciadoDto credenciado { get; set; }
        public DateTime? dt_agenda { get; set; }
    }
}
