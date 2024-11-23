using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.CustomerService.Abnormal
{
    public class AbnormalImages
    {
        public Abnormal Abnormal { get; set; }
        [ForeignKey("Abnormal")]
        public string AbnormalNumber { get; set; }
        public string PictureUrl { get; set; }
    }
}
