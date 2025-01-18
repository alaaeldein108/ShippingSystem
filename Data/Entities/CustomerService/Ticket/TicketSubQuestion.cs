using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.CustomerService.Ticket
{
    public class TicketSubQuestion : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(200)]
        public string Type { get; set; }
        public TicketMainQuestion MainQuestion { get; set; }
        [ForeignKey("MainQuestion")]
        public int MainQuestionId { get; set; }
        public StatusEnum Status { get; set; }

    }
}
