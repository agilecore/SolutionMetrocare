using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    public partial class ExceptionDto : Base
    {
        public ExceptionDto()
        {
            this.id_error = 0;
            this.message = String.Empty;
            this.dt_error = DateTime.Now;
            this.controller = String.Empty;
            this.action = String.Empty;
            this.username = String.Empty;
        }
        public Int32 id_error { get; set; }
        public String message { get; set; }
        public DateTime dt_error { get; set; }
        public String controller { get; set; }
        public String action { get; set; }
        public String username { get; set; }
    }
}
