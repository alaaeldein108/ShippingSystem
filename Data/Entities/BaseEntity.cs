using Data.Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class BaseEntity
    {
        public AppUser Creator { get; set; }
        [ForeignKey("Creator")]
        public Guid CreatorId { get; set; }
        public AppUser Updator { get; set; }
        [ForeignKey("Updator")]
        public Guid? UpdatorId { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime? ModificationTime { get; set; }
    }
}
