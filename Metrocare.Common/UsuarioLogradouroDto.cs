using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    public partial class UsuarioLogradouroDto : Base
    {
        public UsuarioLogradouroDto()
        {
            this.IdUsuario = 0;
            this.Logradouro = String.Empty;
            this.Numero = String.Empty;
            this.Cep = 0;
            this.Bairro = String.Empty;
            this.Cidade = String.Empty;
            this.Estado = EEstado.None;
            this.Status = String.Empty;
        }
        public Int32 IdUsuario { get; set; }
        public ETipoLogradouro TipoLogradouro { get; set; }
        public String Logradouro { get; set; }
        public String Numero { get; set; }
        public Int32 Cep { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public EEstado Estado { get; set; }
        public String Status { get; set; }
    }
}
