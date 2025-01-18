using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.CustomerService.Abnormal
{
    public class AbnormalReplyImages
    {
        public AbnormalReply Reply { get; set; }
        [ForeignKey("Reply")]
        public Guid ReplyId { get; set; }
        [MaxLength(200)]
        public string PictureUrl { get; set; }
    }
}
