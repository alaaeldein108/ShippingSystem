using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Services.CustomerServiceServices.AbnormalServices.AbnormalSubReasonService.Dto
{
    public class AbnormalSubReasonDto
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public StatusEnum? Status { get; set; }
        [Required]
        public int MainReasonId { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModificationTime { get; set; }
    }
}
