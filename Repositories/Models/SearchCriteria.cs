using Data.Entities.CustomerService.Enums;
using Data.Entities.Enums;
using Data.Entities.Finance;
using Data.Entities.Operation;
using Data.Entities.Operation.COD_FOD_Adjustment;
using Data.Entities.Operation.Return_ChangeAdd;

namespace Repositories.Models
{
    public class SearchCriteria
    {
        public string? ClientId { get; set; }
        public string? ReceiverName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SecondPhoneNumber { get; set; }
        public string? AreaId { get; set; }
        public string? CityId { get; set; }
        public string? ProvinceId { get; set; }
        public string? SenderName { get; set; }
        public StatusEnum? Status { get; set; }
        public List<string>? WaybillNumber { get; set; }
        public int? AbnormalMainReasonId { get; set; }
        public string? AbnormalMainReasonCode { get; set; }
        public string? AbnormalMainReasonType { get; set; }
        public int? AbnormalSubReasonId { get; set; }
        public string? AbnormalSubReasonCode { get; set; }
        public string? AbnormalSubReasonType { get; set; }
        public DateTime? RegisterTimeFrom { get; set; }
        public DateTime? RegisterTimeTo { get; set; }
        public int? TicketMainQuestionId { get; set; }
        public string? TicketMainQuestionCode { get; set; }
        public string? TicketMainQuestionType { get; set; }
        public int? TicketSubQuestionId { get; set; }
        public string? TicketSubQuestionCode { get; set; }
        public string? TicketSubQuestionType { get; set; }
        public TicketStatusEnum? TicketStatus { get; set; }
        public string? CallerNumber { get; set; }
        public int? RegisterBranchId { get; set; }
        public int? AuditBranchId { get; set; }
        public int? PickupBranchId { get; set; }
        public string? RegisterCode { get; set; }
        public DateTime? OrderPickupDateFrom { get; set; }
        public DateTime? OrderPickupDateTo { get; set; }
        public string? PickupCourierCode { get; set; }
        public CollectionEnum? CollectionStatus { get; set; }
        public int? SignBranchId { get; set; }
        public string? SigningCourierCode { get; set; }
        public DateTime? OrderSignDateFrom { get; set; }
        public DateTime? OrderSignDateTo { get; set; }
        public int? AffiliatedBranchId { get; set; }
        public int? AffiliatedAgencyId { get; set; }
        public LevelTypeEnum? LevelBranchType { get; set; }
        public DateTime? ValidityTime { get; set; }
        public AuditingEnum? QuotationAudit { get; set; }
        public int? ProductTypeId { get; set; }
        public ScanTypeEnum? ScanTypeName { get; set; }
        public DateTime? WaybillPrintingTimeFrom { get; set; }
        public DateTime? WaybillPrintingTimeTo { get; set; }
        public string? ZoneName { get; set; }
        public ZoneTypeEnum? ZoneType { get; set; }
        public string? ContactPhone { get; set; }
        public CustomerTypeEnum? CustomerType { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedTimeFrom { get; set; }
        public DateTime? CreatedTimeTo { get; set; }
        public ConfirmStatusEnum? ConfirmStatus { get; set; }
        public int? Code { get; set; }
        public string? Name { get; set; }
        public SettlmentMethodEnum? SettlmentMethod { get; set; }
        public VoidedStatusEnum? Voided { get; set; }
        public SignStatusEnum? IsSigned { get; set; }
        public int? OFDTimesFrom { get; set; }
        public int? OFDTimesTo { get; set; }
        public List<Guid>? OrderNumber { get; set; }
        public List<string>? ClientOrderNumber { get; set; }
        public DateTime? EntryDateFrom { get; set; }
        public DateTime? EntryDateTo { get; set; }
        public OrderSourceEnum? OrderSource { get; set; }
        public ClientOrderStatusEnum? OrderStatus { get; set; }
        public string? AuditorCode { get; set; }
        public ApplicationTypeEnum? ApplicationType { get; set; }
        public AppStatusEnum? AppStatus { get; set; }
        public DateTime? PrintingScanTimeFrom { get; set; }
        public DateTime? PrintingScanTimeTo { get; set; }
        public DateTime? ReviewedTimeFrom { get; set; }
        public DateTime? ReviewedTimeTo { get; set; }
        public PrintStatusEnum? PrintStatus { get; set; }
        public string? Sort { get; set; }
        public int PageIndex { get; set; } = 1;
        private const int MAXPAGESIZE = 50;
        private int _pageSize = 10;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MAXPAGESIZE) ? MAXPAGESIZE : value; }
        }
    }
}
