using Data.Entities.Enums;
using Data.Entities.Operation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.IdentityEntities
{
    public enum GenderEnum
    {
        Male = 1,
        Female = 2
    }
    public enum UserTypeEnum
    {
        User = 1,
        Client = 2
    }
    public class AppUser : IdentityUser<Guid>
    {
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(200)]
        public string DisplayName { get; set; }
        public GenderEnum Gender { get; set; }
        public UserTypeEnum UserType { get; set; }
        [MaxLength(50)]
        public string NationalId { get; set; }
        public Position Position { get; set; }
        [ForeignKey("Postion")]
        public int PositionId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModificationTime { get; set; } = DateTime.Now;
        public AppUser Creator { get; set; }

        [ForeignKey("Creator")]
        public Guid? CreatorId { get; set; }
        public AppUser Updator { get; set; }
        [ForeignKey("Updator")]
        public Guid? UpdatorId { get; set; }
        public StatusEnum? Status { get; set; }
        public BranchLevel Branch { get; set; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public ICollection<CourierOrderScheduling>? CourierOrders { get; set; } = new List<CourierOrderScheduling>();


    }
}
