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
    public class TabelaProcedDto : Base
    {
        public System.Int32 ID_PLANO_TABELA { get; set; }
        public System.String ID_PROCEDIMENTO { get; set; }
        public System.String NOME { get; set; }
        public Nullable<System.Int32> NRO_AUXILIARES { get; set; }
        public Nullable<System.Decimal> VALOR_PORTE { get; set; }
        public Nullable<System.Decimal> VALOR_CUSTO_OPERACIONAL { get; set; }
        public Nullable<System.Decimal> VALOR_PORTE_ANESTESICO { get; set; }
        public Nullable<System.Decimal> VALOR_FILME { get; set; }
        public Nullable<System.Decimal> VALOR_TOTAL { get; set; }
    }
}

