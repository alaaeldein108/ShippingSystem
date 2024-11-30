using Repositories.Interfaces.Addresses;
using Repositories.Interfaces.CustomerService;
using Repositories.Interfaces.Finance;
using Repositories.Interfaces.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        #region AddressRepository
        public IAreaRepository AreaRepository { get; set; }
        public ICityRepository CityRepository { get; set; }
        public IProvinceRepository ProvinceRepository { get; set; }
        public IRecieverAddressBookRepository RecieverAddressBookRepository { get; set; }
        public ISenderAddressBookRepository SenderAddressBookRepository { get; set; }
        #endregion

        #region CustomerServiceRepository
        public IAbnormalImagesRepository AbnormalImagesRepository { get; set; }
        public IAbnormalMainReasonRepository AbnormalMainReasonRepository { get; set; }
        public IAbnormalReplyImageRepository AbnormalReplyImageRepository { get; set; }
        public IAbnormalReplyRepository AbnormalReplyRepository { get; set; }
        public IAbnormalRepository AbnormalRepository { get; set; }
        public IAbnormalSubReasonRepository AbnormalSubReasonRepository { get; set; }
        public ITicketAttachmentRepository TicketAttachmentRepository { get; set; }
        public ITicketMainQuestionRepository TicketMainQuestionRepository { get; set; }
        public ITicketReplyAttachmentRepository TicketReplyAttachmentRepository { get; set; }
        public ITicketReplyRepository TicketReplyRepository { get; set; }
        public ITicketRepository TicketRepository { get; set; }
        public ITicketSubQuestionRepository TicketSubQuestionRepository { get; set; }
        #endregion

        #region FinanceRepository
        public ICash_FODCollectionRepository Cash_FODCollectionRepository { get; set; }
        public ICODCollectionRepository CODCollectionRepository { get; set; }
        public IFormulaRepository FormulaRepository { get; set; }
        public IQuotationRepository QuotationRepository { get; set; }
        public IZoneRepository ZoneRepository { get; set; }
        #endregion

        #region OperationRepository
        public IBranchLevelRepository BranchLevelRepository { get; set; }
        public IClientRepository ClientRepository { get; set; }
        public ICOD_FODApplicationRepository COD_FODApplicationRepository { get; set; }
        public IFirstSegmentRepository FirstSegmentRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IOrderScanRepository OrderScanRepository { get; set; }
        public IProductTypeRepository ProductTypeRepository { get; set; }
        public IReturnChangeAddApplicationRepository ReturnChangeAddApplicationRepository { get; set; }
        public IReturnChangeAddWaybillPrintRepository ReturnChangeAddWaybillPrintRepository { get; set; }
        public IScanRepository ScanRepository { get; set; }
        public ISecondSegmentRepository SecondSegmentRepository { get; set; }
        public IWaybillReprintRepository WaybillReprintRepository { get; set; }

        #endregion

        public Task<int> CompleteAsync();

    }
}
