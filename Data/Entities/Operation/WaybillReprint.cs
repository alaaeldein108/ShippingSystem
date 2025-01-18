using Data.Entities.IdentityEntities;
using Data.Entities.Operation.Return_ChangeAdd;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Operation
{
    public class WaybillReprint
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime PrintingTime { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Order")]
        public Guid OrderNumber { get; set; }
        public AppUser Printer { get; set; }
        [ForeignKey("Printer")]
        public Guid PrinterId { get; set; }
        public int NumberOfPrinted { get; set; }
        public PrintStatusEnum PrintStatus { get; set; } = PrintStatusEnum.Unprint;

    }
}
