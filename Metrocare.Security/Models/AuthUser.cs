using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Security.Models
{
    public class AuthUser
    {
        public Int32 IdAcesso { get; set; }
        public Int32 IdUser { get; set; }
        public String Login { get; set; }
        public String Email { get; set; }
    }
}
