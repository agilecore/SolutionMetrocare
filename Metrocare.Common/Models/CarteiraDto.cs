using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    /// <summary>
    /// Nao alterar essa classe pois ela é o objeto identico a tabela do banco de dados.
    /// </summary>
    public class CarteiraDto : Base
    {
        public System.Int32 ID_PLANO { get; set; }
        public System.Int32 ID_USUARIO { get; set; }
        public Nullable<System.Int32> ID_PLANO_INATIVACAO { get; set; }
        public System.Int32 ID_BENEF_DEPEND { get; set; }
        public System.DateTime DT_ATIVACAO { get; set; }
        public System.DateTime DT_INATIVACAO { get; set; }
        public System.String MARCA_OPTICA { get; set; }
        public System.String STATUS { get; set; }
    }
}

