using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.paypalPago
{
    public class modelPagoPayPal
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public string PaypalId { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Status { get; set; }
        public string EmailAddress { get; set; }
        public string CurrencyCode { get; set; }
        public string MerchantId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        
    }
}
