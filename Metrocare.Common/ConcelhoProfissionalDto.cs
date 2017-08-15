using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    [Serializable]
    public partial class ConcelhoProfissionalDto : Base
    {
        public ConcelhoProfissionalDto()
        {
            this.id_concelho_profissional  = 0;      
            this.nome       = String.Empty;
            this.descricao = String.Empty;      
        }

        public Int32 id_concelho_profissional { get; set; }
        public String nome { get; set; }
        public String descricao { get; set; }
    }
}
