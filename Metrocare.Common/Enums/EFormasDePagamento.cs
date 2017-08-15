using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    /// <summary>
    /// Enumerador das diferentes formas de pagamentos existentes no mercado.
    /// </summary>
    public enum EFormasDePagamento
    {
        [Description("Pagamento de Cartao de Crédito")]
        CartaoDeCredito,        
        [Description("Pagamento a Vista no Boleto")]
        Boleto,
        [Description("Pagamento a Vista On-line")]
        InternetBanking,
        [Description("Pagamento a Prazo")]
        Prazo,
        [Description("Pagamento por PayPal")]
        PayPal,                   
        [Description("Pagamento via PagSeguro")]
        PagSeguro,                
        [Description("Pagamento de Outras Formas")]
        Outros                   
    }
}
