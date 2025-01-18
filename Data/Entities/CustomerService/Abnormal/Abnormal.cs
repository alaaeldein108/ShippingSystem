using Data.Entities.CustomerService.Enums;
using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.CustomerService.Abnormal
{
    public enum RegistrationSourceEnum
    {
        System = 1,
        OperationApp = 2,
        CourierApp = 3
    }
    public class Abnormal
    {
        [Key]
        public Guid Number { get; set; }
        public AbnormalSubReason AbnormalSubReason { get; set; }
        [ForeignKey("AbnormalSubReason")]
        public int AbnormalSubReasonId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public Guid OrderNumber { get; set; }
        [MaxLength(500)]
        public string ProblemDescription { get; set; }
        public AbnormalStatusEnum AbnormalStatus { get; set; } = AbnormalStatusEnum.Pending;
        public RegistrationSourceEnum RegistrationSource { get; set; }
        public AppUser Register { get; set; }
        [ForeignKey("Register")]
        public Guid RegisterId { get; set; }
        public DateTime RegisterTime { get; set; }
        public AppUser ClosedPerson { get; set; }
        [ForeignKey("ClosedPerson")]
        public Guid? ClosedPersonId { get; set; }
        public DateTime? ClosedTime { get; set; }
        public ICollection<AbnormalImages> AbnormalImages { get; set; } = new List<AbnormalImages>();
        public ICollection<AbnormalReply>? AbnormalReplies { get; set; } = new List<AbnormalReply>();

    }
}
