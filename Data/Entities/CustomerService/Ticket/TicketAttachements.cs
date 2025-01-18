using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.CustomerService.Ticket
{
    public class TicketAttachements
    {
        public Ticket Ticket { get; set; }
        [ForeignKey("Ticket")]
        public Guid TicketNumber { get; set; }
        [MaxLength(200)]
        public string AttachmentURL { get; set; }
    }
}
