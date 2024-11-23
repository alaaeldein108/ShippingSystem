using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.CustomerService.Abnormal
{
    public class AbnormalReplyImages
    {
        public AbnormalReply Reply { get; set; }
        [ForeignKey("Reply")]
        public string ReplyNumber { get; set; }
        public string PictureUrl { get; set; }
    }
}
