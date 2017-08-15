using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    public partial class PageLogin
    {
        public PageLogin() 
        {
            this.Login   = new LoginFilter();
            this.Usuario = new UsuarioDto();
            this.Email   = String.Empty;
        }
        public LoginFilter Login   { get; set; }
        public UsuarioDto  Usuario { get; set; }
        public String      Email   { get; set; }
    }
}
