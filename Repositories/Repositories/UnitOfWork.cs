using Data.Context;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Interfaces.Addresses;
using Repositories.Interfaces.CustomerService;
using Repositories.Interfaces.Finance;
using Repositories.Interfaces.Operation;
using Repositories.Repositories.Addresses;
using Repositories.Repositories.CustomerService;
using Repositories.Repositories.Finance;
using Repositories.Repositories.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

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

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            AreaRepository=new AreaRepository(context);
            CityRepository=new CityRepository(context);
            ProvinceRepository=new ProvinceRepository(context);
            RecieverAddressBookRepository=new RecieverAddressBookRepository(context);
            SenderAddressBookRepository=new SenderAddressBookRepository(context);

            AbnormalImagesRepository=new AbnormalImagesRepository(context);
            AbnormalMainReasonRepository=new AbnormalMainReasonRepository(context);
            AbnormalReplyImageRepository=new AbnormalReplyImageRepository(context);
            AbnormalReplyRepository=new AbnormalReplyRepository(context);
            AbnormalRepository=new AbnormalRepository(context);
            AbnormalSubReasonRepository=new AbnormalSubReasonRepository(context);
            TicketAttachmentRepository=new TicketAttachmentRepository(context);
            TicketMainQuestionRepository=new TicketMainQuestionRepository(context);
            TicketReplyAttachmentRepository=new TicketReplyAttachmentRepository(context);
            TicketReplyRepository=new TicketReplyRepository(context);
            TicketRepository=new TicketRepository(context);
            TicketSubQuestionRepository=new TicketSubQuestionRepository(context);

            Cash_FODCollectionRepository = new Cash_FODCollectionRepository(context);
            CODCollectionRepository=new CODCollectionRepository(context);
            FormulaRepository=new FormulaRepository(context);
            QuotationRepository=new QuotationRepository(context);
            ZoneRepository=new ZoneRepository(context);

            BranchLevelRepository=new BranchLevelRepository(context);
            ClientRepository=new ClientRepository(context);
            COD_FODApplicationRepository=new COD_FODApplicationRepository(context);
            FirstSegmentRepository=new FirstSegmentRepository(context);
            OrderRepository=new OrderRepository(context);
            OrderScanRepository=new OrderScanRepository(context);
            ProductTypeRepository=new ProductTypeRepository(context);
            ReturnChangeAddApplicationRepository=new ReturnChangeAddApplicationRepository(context);
            ReturnChangeAddWaybillPrintRepository=new ReturnChangeAddWaybillPrintRepository(context);
            ScanRepository=new ScanRepository(context);
            SecondSegmentRepository=new SecondSegmentRepository(context);
            WaybillReprintRepository=new WaybillReprintRepository(context);
        }
        public async Task<int> CompleteAsync()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
    }
}
