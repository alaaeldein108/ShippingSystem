using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Services.FinanceServices.ZoneService.Dto
{
    public class ZoneDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int AffailiatedBranchId { get; set; }
        public ZoneTypeEnum ZoneType { get; set; }
        public StatusEnum? Status { get; set; }
        public QuotationTypeEnum QuotationType { get; set; }
        public List<string> Cities { get; set; } = new List<string>();
        public Guid? CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModificationTime { get; set; }
    }
}
