using Data.Entities.Addresses;
using Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Operation.Sorting
{
    public class SecondSegment
    {
        [Key]
        public string Id { get; set; }
        public Area Area { get; set; }
        [ForeignKey("Area")]
        public string AreaId { get; set; }
        public BranchLevel Branch { get; set; }
        [ForeignKey("Branch")]
        public string BranchCode { get; set; }
        public FirstSegment FirstSegment { get; set; }
        [ForeignKey("FirstSegment")]
        public int FirstSegmentId { get; set; }
        public StatusEnum Status { get; set; }
        
    }
}
