using Data.Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.CustomerService.Ticket
{
    public class TicketReply
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(500)]
        public string ReplyText { get; set; }
        public Ticket Ticket { get; set; }
        [ForeignKey("Ticket")]
        public Guid TicketNumber { get; set; }
        public AppUser Replier { get; set; }
        [ForeignKey("Replier")]
        public Guid ReplierId { get; set; }
        public DateTime ReplyTime { get; set; }
        public ICollection<TicketReplyAttachment>? ReplyImages { get; set; } = new List<TicketReplyAttachment>();
    }
}
