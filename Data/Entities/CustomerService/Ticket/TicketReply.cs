using Data.Entities.CustomerService.Abnormal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.CustomerService.Ticket
{
    public class TicketReply
    {
        [Key]
        public string Id { get; set; }
        public string ReplyText { get; set; }
        public Ticket Ticket { get; set; }
        [ForeignKey("Ticket")]
        public string TicketNumber { get; set; }
        public DateTime ReplyTime { get; set; }
        public ICollection<TicketReplyAttachment>? Reply_Images { get; set; } = new List<TicketReplyAttachment>();
    }
}
