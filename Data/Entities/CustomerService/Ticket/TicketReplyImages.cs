using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.CustomerService.Ticket
{
    public class TicketReplyImages
    {
        public TicketReply TicketReply { get; set; }
        [ForeignKey("TicketReply")]
        public string TicketReplyId { get; set; }
        public string PictureUrl { get; set; }
    }
}
