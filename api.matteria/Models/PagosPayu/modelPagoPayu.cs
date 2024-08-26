using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.PagosPayu
{
    public class modelPagoPayu
    {

        public int Id { get; set; }
        public int? CompraId { get; set; }
        public string OrderId { get; set; }
        public string TransactionId { get; set; }
        public decimal? Amount { get; set; }
        public string AuthorizationCode { get; set; }
        public string PendingReason { get; set; }
        public string ResponseCode { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string State { get; set; }
        

    }
}
