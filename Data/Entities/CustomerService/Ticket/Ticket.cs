using Data.Entities.CustomerService.Enums;
using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.CustomerService.Ticket
{
    public class Ticket
    {
        [Key]
        public Guid Number { get; set; }
        [MaxLength(100)]
        public string Caller { get; set; }
        [MaxLength(50)]
        public string CallerNumber { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public Guid OrderNumber { get; set; }
        public TicketSubQuestion SubQuestion { get; set; }
        [ForeignKey("SubQuestion")]
        public int SubQuestionId { get; set; }
        [MaxLength(500)]
        public string ProblemDescription { get; set; }
        [MaxLength(200)]
        public string? AttachmentUrl { get; set; }
        public TicketStatusEnum TicketStatus { get; set; } = TicketStatusEnum.ToBeAssigned;
        public AppUser Register { get; set; }
        [ForeignKey("Register")]
        public Guid RegisterId { get; set; }
        public DateTime RegisterTime { get; set; }
        public AppUser ClosedPerson { get; set; }
        [ForeignKey("ClosedPerson")]
        public Guid? ClosedPersonId { get; set; }
        public DateTime? ClosedTime { get; set; }
        public ICollection<TicketReply> TicketReplies { get; set; } = new List<TicketReply>();

    }
}
