using Data.Entities.IdentityEntities;
using Data.Entities.Operation.Return_ChangeAdd;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Operation
{
    public class WaybillReprint
    {
        [Key]
        public string Id { get; set; }
        public DateTime PrintingTime { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public string OrderNumber { get; set; }
        public BranchLevel PrintBranch { get; set; }
        [ForeignKey("PrintBranch")]
        public string PrintBranchId { get; set; }
        public string PrinterId { get; set; }
        public int NumberOfPrinted { get; set; }
    }
}
