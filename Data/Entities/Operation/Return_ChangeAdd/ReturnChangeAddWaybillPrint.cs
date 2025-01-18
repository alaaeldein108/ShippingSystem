using Data.Entities.IdentityEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Operation.Return_ChangeAdd
{
    public enum PrintStatusEnum
    {
        Unprint = 1,
        Printed = 2
    }
    public class ReturnChangeAddWaybillPrint
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime PrintingScanTime { get; set; }
        public ReturnChangeAddApp ReturnChangeAddApp { get; set; }
        [ForeignKey("ReturnChangeAddApp")]
        public Guid ReturnChangeAddAppId { get; set; }
        public PrintStatusEnum PrintStatus { get; set; } = PrintStatusEnum.Unprint;
        public AppUser Printer { get; set; }
        [ForeignKey("Printer")]
        public Guid? PrinterId { get; set; }
        public int NumberOfPrinted { get; set; }

    }
}
