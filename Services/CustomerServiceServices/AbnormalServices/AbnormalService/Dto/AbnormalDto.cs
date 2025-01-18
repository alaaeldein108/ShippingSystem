using Data.Entities.CustomerService.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Services.CustomerServiceServices.AbnormalServices.AbnormalService.Dto
{
    public class AbnormalDto
    {
        public Guid? Number { get; set; }
        public int AbnormalSubReasonId { get; set; }
        public Guid OrderNumber { get; set; }
        [MaxLength(500)]
        public string ProblemDescription { get; set; }
        public AbnormalStatusEnum AbnormalStatus { get; set; } = AbnormalStatusEnum.Pending;
        public Guid RegisterId { get; set; }
        public DateTime RegisterTime { get; set; }
        public Guid? ClosedPersonId { get; set; }
        public DateTime? ClosedTime { get; set; }
        public List<IFormFile> AbnormalImages { get; set; } = new List<IFormFile>();
        public ICollection<Guid>? AbnormalReplies { get; set; } = new List<Guid>();
    }
}
