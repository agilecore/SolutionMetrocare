using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    public partial class LogFilter : Base
    {
        public LogFilter()
        {
            this.id_log     = 0;
            this.id_usuario = 0;
            this.dt_log     = null;
            this.nome       = String.Empty;
            this.email      = String.Empty;
        }
        public Int32     id_log     { get; set; }
        public Int32     id_usuario { get; set; }
        public DateTime? dt_log     { get; set; }
        public String    nome       { get; set; }
        public String    email      { get; set; }
    }
}
