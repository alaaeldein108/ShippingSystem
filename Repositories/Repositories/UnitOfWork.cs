using Data.Context;
using Repositories.Interfaces;
using Repositories.Interfaces.Addresses;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.CustomerService;
using Repositories.Interfaces.Finance;
using Repositories.Interfaces.Operation;
using Repositories.Repositories.Addresses;
using Repositories.Repositories.CustomerService;
using Repositories.Repositories.Finance;
using Repositories.Repositories.Operation;

namespace Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private readonly IAuditRepository auditRepository;

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
        public ICashFODCollectionRepository Cash_FODCollectionRepository { get; set; }
        public ICODCollectionRepository CODCollectionRepository { get; set; }
        public IFormulaRepository FormulaRepository { get; set; }
        public IQuotationRepository QuotationRepository { get; set; }
        public IZoneRepository ZoneRepository { get; set; }
        #endregion

        #region OperationRepository
        public IBranchLevelRepository BranchLevelRepository { get; set; }
        public IClientRepository ClientRepository { get; set; }
        public ICODFODRegistrationAppRepository COD_FODApplicationRepository { get; set; }
        public IFirstSegmentRepository FirstSegmentRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IOrderScanRepository OrderScanRepository { get; set; }
        public IProductTypeRepository ProductTypeRepository { get; set; }
        public IReturnChangeAddAppRepository ReturnChangeAddApplicationRepository { get; set; }
        public IReturnChangeAddWaybillPrintRepository ReturnChangeAddWaybillPrintRepository { get; set; }
        public IScanRepository ScanRepository { get; set; }
        public ISecondSegmentRepository SecondSegmentRepository { get; set; }
        public IWaybillReprintRepository WaybillReprintRepository { get; set; }
        #endregion

        public UnitOfWork(AppDbContext context, IAuditRepository auditRepository)
        {
            this.context = context;
            this.auditRepository = auditRepository;
            AreaRepository = new AreaRepository(context);
            CityRepository = new CityRepository(context);
            ProvinceRepository = new ProvinceRepository(context);
            RecieverAddressBookRepository = new RecieverAddressBookRepository(context);
            SenderAddressBookRepository = new SenderAddressBookRepository(context);

            AbnormalImagesRepository = new AbnormalImagesRepository(context, auditRepository);
            AbnormalMainReasonRepository = new AbnormalMainReasonRepository(context);
            AbnormalReplyImageRepository = new AbnormalReplyImageRepository(context, auditRepository);
            AbnormalReplyRepository = new AbnormalReplyRepository(context, auditRepository);
            AbnormalRepository = new AbnormalRepository(context, auditRepository);
            AbnormalSubReasonRepository = new AbnormalSubReasonRepository(context);
            TicketAttachmentRepository = new TicketAttachmentRepository(context, auditRepository);
            TicketMainQuestionRepository = new TicketMainQuestionRepository(context);
            TicketReplyAttachmentRepository = new TicketReplyAttachmentRepository(context, auditRepository);
            TicketReplyRepository = new TicketReplyRepository(context, auditRepository);
            TicketRepository = new TicketRepository(context, auditRepository);
            TicketSubQuestionRepository = new TicketSubQuestionRepository(context);

            Cash_FODCollectionRepository = new CashFODCollectionRepository(context, auditRepository);
            CODCollectionRepository = new CODCollectionRepository(context, auditRepository);
            FormulaRepository = new FormulaRepository(context);
            QuotationRepository = new QuotationRepository(context);
            ZoneRepository = new ZoneRepository(context);

            BranchLevelRepository = new BranchLevelRepository(context);
            ClientRepository = new ClientRepository(context);
            COD_FODApplicationRepository = new CODFODRegisterationAppRepository(context, auditRepository);
            FirstSegmentRepository = new FirstSegmentRepository(context);
            OrderRepository = new OrderRepository(context, auditRepository);
            OrderScanRepository = new OrderScanRepository(context, auditRepository);
            ProductTypeRepository = new ProductTypeRepository(context);
            ReturnChangeAddApplicationRepository = new ReturnChangeAddAppRepository(context, auditRepository);
            ReturnChangeAddWaybillPrintRepository = new ReturnChangeAddWaybillPrintRepository(context);
            ScanRepository = new ScanRepository(context);
            SecondSegmentRepository = new SecondSegmentRepository(context);
            WaybillReprintRepository = new WaybillReprintRepository(context);
        }


        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
