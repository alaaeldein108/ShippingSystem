using Data.Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Helper
{
    public enum ActionEnum
    {
        Add = 1,
        Update = 2,
        Delete = 3,
        View = 4
    }
    public class LogData
    {
        [Key]
        public long Id { get; set; }
        public string WaybillNumber { get; set; }
        public Guid? EntityId { get; set; }
        public DateTime Date { get; set; }
        public AppUser User { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public string TableName { get; set; }
        public ActionEnum Action { get; set; }
        public string LogObjectProperties { get; set; }
        public string LogObjectProperties_Ar { get; set; }
    }
}
