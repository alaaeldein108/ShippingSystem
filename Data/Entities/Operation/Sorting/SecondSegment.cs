using Data.Entities.Addresses;
using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Operation.Sorting
{
    public class SecondSegment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Area Area { get; set; }
        [MaxLength(50)]
        [ForeignKey("Area")]
        public string AreaId { get; set; }
        public BranchLevel Branch { get; set; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public FirstSegment FirstSegment { get; set; }
        [ForeignKey("FirstSegment")]
        public int FirstSegmentId { get; set; }
        public StatusEnum Status { get; set; }

    }
}
