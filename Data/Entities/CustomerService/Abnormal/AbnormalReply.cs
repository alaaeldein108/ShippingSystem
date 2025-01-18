using Data.Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.CustomerService.Abnormal
{
    public class AbnormalReply
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(500)]
        public string ReplyText { get; set; }
        public Abnormal Abnormal { get; set; }
        [ForeignKey("Abnormal")]
        public Guid AbnormalNumber { get; set; }
        public AppUser Replier { get; set; }
        [ForeignKey("Replier")]
        public Guid ReplierId { get; set; }
        public DateTime ReplyTime { get; set; }
        public ICollection<AbnormalReplyImages>? ReplyImages { get; set; } = new List<AbnormalReplyImages>();

    }
}
