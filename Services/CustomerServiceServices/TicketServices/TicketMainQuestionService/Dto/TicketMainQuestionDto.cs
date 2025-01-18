using Data.Entities.Enums;

namespace Services.CustomerServiceServices.TicketServices.TicketMainQuestionService.Dto
{
    public class TicketMainQuestionDto
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public StatusEnum? Status { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModificationTime { get; set; }
    }
}
