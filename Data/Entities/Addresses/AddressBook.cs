using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Addresses
{
    public class AddressBook
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string? SecondPhone { get; set; }
        public Area Area { get; set; }
        [MaxLength(50)]
        [ForeignKey("Area")]
        public string AreaId { get; set; }
        [MaxLength(200)]
        public string Street { get; set; }
        public bool IsDefault { get; set; }


    }

}
