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
    public class FirstSegment
    {
        [Key]
        public int Id { get; set; }
        public int FirstSegmentCode { get; set; }
        public string FirstSegmentName { get; set; }
        public string FinalOrganizationNumber { get; set; }
        public string FinalOrganizationName { get; set; }
        public Area Area { get; set; }
        [ForeignKey("Area")]
        public string AreaId { get; set; }
        public StatusEnum Status { get; set; }
    }
}
