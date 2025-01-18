using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities.IdentityEntities
{
    public class Department : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public LevelTypeEnum LevelType { get; set; }
    }
}
