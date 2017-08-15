using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    /// <summary>
    /// Enumerador de tipo de nota fiscal se de vendas de produtos/mercadorias ou de seviços.
    /// </summary>
    public enum ECategoriaNotaFiscal
    {
        [Description("NF de Produtos/Mercadorias")]
        Produdos,   
        [Description("NF de Servicos")]
        Servicos      
    }


}
