using Data.Entities.CustomerService.Abnormal;
using Data.Entities.Enums;

namespace Services.CustomerServiceServices.AbnormalServices.AbnormalService.Dto
{
    public class GetAbnormalDto
    {
        public string WaybillNumber { get; set; }
        public string AbnormalMainReasonType { get; set; }
        public string AbnormalSubReasonType { get; set; }
        public string RegisterName { get; set; }
        public string RegisterBranchName { get; set; }
        public string RegisterationCentre { get; set; }
        public DateTime RegisterTime { get; set; }
        public RegistrationSourceEnum RegistrationSource { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public DateTime PickupTime { get; set; }
        public string RecievingBranchName { get; set; }
        public string RecievingCentreName { get; set; }
        public string ProblemDescription { get; set; }
        public string DeliveryBranchName { get; set; }
        public SignStatusEnum IsSigned { get; set; }
        public string SignTime { get; set; }
        public List<string> AbnormalImages { get; set; }
        public List<AbnormalReply> AbnormalReplies { get; set; }


    }
}
