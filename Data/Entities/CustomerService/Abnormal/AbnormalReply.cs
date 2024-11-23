using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.CustomerService.Abnormal
{
    public class AbnormalReply
    {
        [Key]
        public string Id { get; set; }
        public string ReplyText { get; set; }
        public Abnormal Abnormal { get; set; }
        [ForeignKey("Abnormal")]
        public string AbnormalNumber { get; set; }
        public DateTime ReplyTime { get; set; }
        public ICollection<AbnormalReplyImages>? Reply_Images { get; set; } = new List<AbnormalReplyImages>();

    }
}
