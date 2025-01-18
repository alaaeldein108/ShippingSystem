using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities.CustomerService.Ticket
{
    public class TicketMainQuestion : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(200)]
        public string Type { get; set; }
        public StatusEnum Status { get; set; }

    }
}
