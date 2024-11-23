
using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Finance
{
    public class ClientQuotation
    {
        public Client Client { get; set; }
        [ForeignKey("Client")]
        public string ClientCode { get; set; }
        public Quotation Quotation { get; set; }
        [ForeignKey("Quotation")]
        public int QuotationId { get; set; }
    }
}
