using Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Operation
{
    public class Order_Scan
    {
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public string OrderNumber { get; set; }
        public Scan Scan { get; set; }
        [ForeignKey("Scan")]
        public int ScanCode { get; set; }
        public DateTime? ScanTime { get; set; }
        public DateTime? UploadTime { get; set; }
        public BranchLevel BranchScan { get; set; }
        [ForeignKey("BranchScan")]
        public string? BranchScanId { get; set; }
        public string? ScannerId { get; set; }
        public string? PickupCourierId { get; set; }
        public string? DeliveryCourierId { get; set; }
        public BranchLevel NextBranch { get; set; }
        [ForeignKey("NextBranch")]
        public string? NextBranchId { get; set; }
    }
}
