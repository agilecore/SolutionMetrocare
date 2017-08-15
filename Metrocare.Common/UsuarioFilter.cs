using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Metrocare.Common
{
    public partial class UsuarioFilter : Base
    {
        public UsuarioFilter()
        {
            this.id_usuario = 0;
            this.nome = String.Empty;
            this.cpf = String.Empty;
            this.rg = String.Empty;
            this.logradouro = String.Empty;
            this.complemento = String.Empty;
            this.numero = 0;
            this.cep = 0;
            this.bairro = String.Empty;
            this.cidade = String.Empty;
            this.uf = String.Empty;
            this.email = String.Empty;
            this.telefone = String.Empty;
            this.celular = String.Empty;
            this.contato = String.Empty;
            this.dt_cadastro = null;
            this.dt_nascimento = null;
            this.longitude = 0;
            this.latitude = 0;
            this.ibge = 0;
            this.senha = String.Empty;
            this.status = String.Empty;
            this.menuCollection = new List<MenuDto>();
            this.logradouroCollection = new List<UsuarioLogradouroDto>();
        }

        public Int32 id_usuario { get; set; }
        public String nome { get; set; }
        public String cpf { get; set; }
        public String rg { get; set; }
        public String logradouro { get; set; }
        public String complemento { get; set; }
        public Int32 numero { get; set; }
        public Int32 cep { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public String uf { get; set; }
        public String email { get; set; }
        public String telefone { get; set; }
        public String celular { get; set; }
        public String contato { get; set; }
        public DateTime? dt_cadastro { get; set; }
        public DateTime? dt_nascimento { get; set; }
        public Int32 longitude { get; set; }
        public Int32 latitude { get; set; }
        public Int32 ibge { get; set; }
        public String senha { get; set; }
        public String status { get; set; }

        //public Int32 id_usuario { get; set; }
        //[Required(ErrorMessage = "O campo Nome deve ser informado!", AllowEmptyStrings = false)]
        //public String nome { get; set; }
        //[Required(ErrorMessage = "O campo Email deve ser informado!", AllowEmptyStrings = false)]
        //public String email { get; set; }
        //[Required(ErrorMessage = "O campo Data de Nascimento deve ser informado!", AllowEmptyStrings = false)]
        //public DateTime? nascimento { get; set; }
        //[Required(ErrorMessage = "O campo Username deve ser informado!", AllowEmptyStrings = false)]
        //public String username { get; set; }
        //[Required(ErrorMessage = "O campo Password deve ser informado!", AllowEmptyStrings = false)]
        //public String password { get; set; }
        //[Required(ErrorMessage = "O campo Endereco deve ser informado!", AllowEmptyStrings = false)]
        //public String endereco { get; set; }
        //[Required(ErrorMessage = "O campo Número deve ser informado!", AllowEmptyStrings = false)]
        //public String numero { get; set; }
        //[Required(ErrorMessage = "O campo Bairro deve ser informado!", AllowEmptyStrings = false)]
        //public String bairro { get; set; }
        //[Required(ErrorMessage = "O campo Cidade deve ser informado!", AllowEmptyStrings = false)]
        //public String cidade { get; set; }
        //[Required(ErrorMessage = "O campo Estado deve ser informado!", AllowEmptyStrings = false)]
        //public String uf { get; set; }
        //[Required(ErrorMessage = "O campo Cep deve ser informado!", AllowEmptyStrings = false)]
        //public String cep { get; set; }
        //[Required(ErrorMessage = "O campo Pais deve ser informado!", AllowEmptyStrings = false)]
        //public String pais { get; set; }
        //[Required(ErrorMessage = "O campo Status deve ser informado!", AllowEmptyStrings = false)]
        //public String status { get; set; }

        public List<MenuDto> menuCollection { get; set; }
        public List<UsuarioLogradouroDto> logradouroCollection { get; set; }
    }
}
