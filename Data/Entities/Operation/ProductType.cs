using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Operation
{
    public class ProductType : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public StatusEnum Status { get; set; }

    }
}
