using Data.Entities.CustomerService.Enums;
using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.CustomerService.Abnormal
{
    public class Abnormal
    {
        [Key]
        public string Number { get; set; }
        public AbnormalSubReason AbnormalSubReason { get; set; }
        [ForeignKey("AbnormalSubReason")]
        public int AbnormalSubReasonId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public string OrderNumber { get; set; }
        public string ProblemDescription { get; set; }
        public TicketStatusEnum AbnormalStatus { get; set; } = TicketStatusEnum.Pending;
        public string RegisterId { get; set; }
        public BranchLevel RegisterBr { get; set; }
        [ForeignKey("RegisterBr")]
        public string RegisterBrId { get; set; }
        public DateTime RegisterTime { get; set; }
        public ICollection<AbnormalImages> Abnormal_Images { get; set; } = new List<AbnormalImages>();
        public ICollection<AbnormalReply> AbnormalReplies { get; set; } = new List<AbnormalReply>();

    }
}
