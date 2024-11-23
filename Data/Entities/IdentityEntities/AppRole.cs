using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.IdentityEntities
{
    public class AppRole:IdentityRole
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModificationTime { get; set; } = DateTime.Now;
        public AppUser CreationUsers { get; set; }

        [ForeignKey("CreationUsers")]
        public string? CreatorId { get; set; }
        public AppUser ModificationUsers { get; set; }
        [ForeignKey("ModificationUsers")]
        public string? ModifiedBy { get; set; }
    }
}
