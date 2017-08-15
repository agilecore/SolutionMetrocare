using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    public partial class MenuFilter : Base
    {
        public MenuFilter()
        {
            this.Url = String.Empty;
            this.Descricao = String.Empty;
            this.Status = String.Empty;
        }
        public String Url { get; set; }
        public String Descricao { get; set; }
        public String Status { get; set; }
    }
}
