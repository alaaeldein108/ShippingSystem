using Data.Entities.Addresses;
using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Operation.Sorting
{
    public class FirstSegment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int FirstSegmentCode { get; set; }
        [MaxLength(100)]
        public string FirstSegmentName { get; set; }
        [MaxLength(100)]
        public string FinalOrganizationNumber { get; set; }
        [MaxLength(200)]
        public string FinalOrganizationName { get; set; }
        public Area Area { get; set; }
        [MaxLength(50)]
        [ForeignKey("Area")]
        public string AreaId { get; set; }
        public StatusEnum Status { get; set; }
    }
}
