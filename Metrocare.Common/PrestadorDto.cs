using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    public partial class PrestadorDto
    {
        public PrestadorDto()
        {
            this.id_prestador = 0;
            this.nome = String.Empty;
            this.cpf = String.Empty;
            this.cnpj = String.Empty;
            this.email = String.Empty;
            this.logradouro = String.Empty;
            this.complemento = String.Empty;
            this.numero = 0;
            this.cep = 0;
            this.bairro = String.Empty;
            this.cidade = String.Empty;
            this.uf = String.Empty;
            this.telefone = String.Empty;
            this.celular = String.Empty;
            this.contato = String.Empty;
            this.dt_cadastro = DateTime.Now;
            this.longitude = 0;
            this.latitude = 0;
            this.ibge = 0;
        }

        [Key]
        public Int32 id_prestador { get; set; }

        [Required(ErrorMessage = "Informe o campo nome.")]
        [StringLength(255, ErrorMessage = "O tamanho máximo são 255 caracteres.")]
        public String nome { get; set; }

        [Required(ErrorMessage = "Informe o campo cpf.")]
        public String cpf { get; set; }
         
        public String cnpj { get; set; }

        [Required(ErrorMessage = "Informe o campo email.")]
        [MinLength(5, ErrorMessage = "O tamanho mínimo do nome são 5 caracteres.")]
        [StringLength(30, ErrorMessage = "O tamanho máximo são 30 caracteres.")]           
        public String email { get; set; }

        [Required(ErrorMessage = "Informe o campo logradouro.")]
        [StringLength(255, ErrorMessage = "O tamanho máximo são 255 caracteres.")] 
        public String logradouro { get; set; }

        [Required(ErrorMessage = "Informe o campo complemento.")]
        [StringLength(255, ErrorMessage = "O tamanho máximo são 255 caracteres.")] 
        public String complemento { get; set; }

        [Required(ErrorMessage = "Informe o campo número.")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true, NullDisplayText = "Informe o campo númeroo")]
        public Int32 numero { get; set; }

        [Required(ErrorMessage = "Informe o campo número.")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true, NullDisplayText = "Informe o campo númeroo")]
        public Int32 cep { get; set; }

        [Required(ErrorMessage = "Informe o campo bairro.")]
        [StringLength(255, ErrorMessage = "O tamanho máximo são 255 caracteres.")] 
        public String bairro { get; set; }

        [Required(ErrorMessage = "Informe o campo cidade.")]
        [StringLength(255, ErrorMessage = "O tamanho máximo são 255 caracteres.")]         
        public String cidade { get; set; }

        [Required(ErrorMessage = "Informe o campo uf.")]       
        public String uf { get; set; }

        [Required(ErrorMessage = "Informe o campo telefone.")]
        [StringLength(15, ErrorMessage = "O tamanho máximo são 15 caracteres.")]          
        public String telefone { get; set; }

        [Required(ErrorMessage = "Informe o campo celular.")]
        [StringLength(15, ErrorMessage = "O tamanho máximo são 15 caracteres.")]           
        public String celular { get; set; }

        [Required(ErrorMessage = "Informe o campo contato.")]
        [StringLength(255, ErrorMessage = "O tamanho máximo são 255 caracteres.")]  
        public String contato { get; set; }

        public DateTime? dt_cadastro { get; set; }
        
        public Int32 longitude { get; set; }
        
        public Int32 latitude { get; set; }
        
        public Int32 ibge { get; set; }
    }

}

