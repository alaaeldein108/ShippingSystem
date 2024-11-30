using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.CustomerService.Ticket
{
    public class TicketAttachements
    {
        public Ticket Ticket { get; set; }
        [ForeignKey("Ticket")]
        public string TicketNumber { get; set; }
        public string AttachmentURL { get; set; }
    }
}
