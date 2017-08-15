using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    [Serializable]
    public partial class LogDto : Base
    {
        public LogDto()
        {
            this.id_usuario = 0;
            this.dt_log     = DateTime.Now;
            this.nome       = String.Empty;
            this.email      = String.Empty;
            this.username   = String.Empty;
        }
        public Int32    id_usuario { get; set; }
        public DateTime dt_log     { get; set; }
        public String   nome       { get; set; }
        public String   email      { get; set; }
        public String   username   { get; set; }
    }
}
