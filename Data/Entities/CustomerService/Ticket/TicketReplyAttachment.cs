using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.CustomerService.Ticket
{
    public class TicketReplyAttachment
    {
        public TicketReply TicketReply { get; set; }
        [ForeignKey("TicketReply")]
        public Guid TicketReplyId { get; set; }
        [MaxLength(200)]
        public string PictureUrl { get; set; }
    }
}
