using Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.CustomerService.Ticket
{
    public class TicketSubQuestion
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public TicketMainQuestion MainQuestion { get; set; }
        [ForeignKey("MainQuestion")]
        public int MainQuestionId { get; set; }
        public StatusEnum Status { get; set; }

    }
}
