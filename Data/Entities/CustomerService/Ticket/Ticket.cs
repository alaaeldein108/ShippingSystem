using Data.Entities.Addresses;
using Data.Entities.CustomerService.Abnormal;
using Data.Entities.CustomerService.Enums;
using Data.Entities.Finance;
using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.CustomerService.Ticket
{
    public class Ticket
    {
        [Key]
        public string Number { get; set; }
        public string Caller { get; set; }
        public string CallerNumber { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public string OrderNumber { get; set; }
        public TicketSubQuestion SubQuestion { get; set; }
        [ForeignKey("SubQuestion")]
        public int SubQuestionId { get; set; }
        public string ProblemDescription { get; set; }
        public string? AttachmentUrl { get; set; }
        public TicketStatusEnum TicketStatus { get; set; } = TicketStatusEnum.Pending;
        public string RegisterId { get; set; } 
        public DateTime RegisterTime { get; set; }
        public ICollection<TicketReply> TicketReplies { get; set; } = new List<TicketReply>();

    }
}
