using Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Operation.Return_ChangeAdd
{
    public enum ApplicationTypeEnum
    {
        Return,
        CahngeAdd
    }
    public enum AppStatusEnum
    {
        Auditing,
        Reviewed,
        Rejected,
        Canceled
    }
    public enum PrintStatus
    {
        Printed,
        Unprint
    }
    public class Return_ChangeAdd_App
    {
        [Key]
        public string Id { get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }
        public string Reason { get; set; }
        public AppStatusEnum AppStatus { get; set; }=AppStatusEnum.Auditing;
        public DateTime ApplyingTime { get; set; }
        public DateTime ReviewedTime { get;  set; }
        public string RegisterId { get; set; }
        public string AuditorId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public PrintStatus PrintStatus { get; set; } = PrintStatus.Unprint;
    }
}
