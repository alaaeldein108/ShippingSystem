using Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Operation
{
    public enum ScanTypeEnum
    {
        PickupScan = 1,
        EnterBranchScan = 2,
        SendingScan = 3,
        ArrivalScan = 4,
        OutForDeliveryScan = 5,
        SignScan = 6,
        DeletedSignScan = 7,
        AbnormalParcelScan = 8,
        ReturnedParcelScan = 9,
        CanceledReturnedParcelScan = 10,
        ChangeAddressScan = 11,
        CanceledChangeAddressScan = 12,
        ReturnedSignedScan = 13,
        DeletedReturnedSignedScan = 14,
        LeftOverScan = 15,
        VoidedParcelScan = 16
    }
    public class Scan : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public ScanTypeEnum ScanTypeName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Active;
        public ICollection<OrderScan> OrderScans { get; set; } = new List<OrderScan>();

    }
}
