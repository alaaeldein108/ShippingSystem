using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.IdentityEntities
{
    public class AppRole : IdentityRole<Guid>
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModificationTime { get; set; } = DateTime.Now;
        public AppUser Creator { get; set; }
        [ForeignKey("Creator")]
        public Guid? CreatorId { get; set; }
        public AppUser Updator { get; set; }
        [ForeignKey("updator")]
        public Guid? UpdatorId { get; set; }
    }
}
