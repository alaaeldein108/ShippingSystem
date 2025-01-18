using Data.Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Operation.Return_ChangeAdd
{
    public enum ApplicationTypeEnum
    {
        Return = 1,
        CahngeAdd = 2
    }
    public enum AppStatusEnum
    {
        Auditing = 1,
        Reviewed = 2,
        Rejected = 3,
        Canceled = 4
    }

    public class ReturnChangeAddApp
    {
        [Key]
        public Guid Id { get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }
        [MaxLength(500)]
        public string Reason { get; set; }
        public AppStatusEnum AppStatus { get; set; } = AppStatusEnum.Auditing;
        public DateTime ApplyingTime { get; set; }
        public DateTime ReviewedTime { get; set; }
        public AppUser Register { get; set; }
        [ForeignKey("Register")]
        public Guid RegisterId { get; set; }
        public AppUser Auditor { get; set; }
        [ForeignKey("Auditor")]
        public Guid AuditorId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public Guid OrderNumber { get; set; }
    }
}
