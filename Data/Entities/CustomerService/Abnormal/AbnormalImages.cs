using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.CustomerService.Abnormal
{
    public class AbnormalImages
    {
        public Abnormal Abnormal { get; set; }
        [ForeignKey("Abnormal")]
        public Guid AbnormalNumber { get; set; }
        [MaxLength(500)]
        public string PictureUrl { get; set; }
    }
}
