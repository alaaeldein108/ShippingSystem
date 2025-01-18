using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.CustomerService.Abnormal
{
    public class AbnormalSubReason : BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(200)]
        public string Type { get; set; }
        public AbnormalMainReason MainReason { get; set; }
        [ForeignKey("MainReason")]
        public int MainReasonId { get; set; }
        public StatusEnum Status { get; set; }

    }
}
