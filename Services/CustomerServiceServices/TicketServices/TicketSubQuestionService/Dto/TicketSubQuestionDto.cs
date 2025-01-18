using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Services.CustomerServiceServices.TicketServices.TicketSubQuestionService.Dto
{
    public class TicketSubQuestionDto
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public StatusEnum? Status { get; set; }
        [Required]
        public int MainQuestionId { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModificationTime { get; set; }
    }
}
