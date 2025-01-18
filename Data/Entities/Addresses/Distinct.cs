using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Addresses
{
    public class Distinct
    {
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
