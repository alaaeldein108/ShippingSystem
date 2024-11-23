using Data.Entities.Enums;
using Data.Entities.Operation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.IdentityEntities
{
    public enum Gender
    {
        Male,
        Female
    }
    public class AppUser: IdentityUser
    {
        public string DisplayName { get; set; }
        public Gender Gender { get; set; }
        public string NationalId { get; set; }
        public Position Position { get; set; }
        [ForeignKey("Postion")]
        public string PositionCode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModificationTime { get; set; } = DateTime.Now;
        public AppUser Creator { get; set; }

        [ForeignKey("Creator")]
        public string? CreatorId { get; set; }
        public AppUser Modifier { get; set; }
        [ForeignKey("Modifier")]
        public string? ModifierId { get; set; }
        public StatusEnum? Status { get; set; }
        public BranchLevel Branch { get; set; }
        [ForeignKey("Branch")]
        public string BranchCode { get; set; }


    }
}
