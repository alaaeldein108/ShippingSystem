using DinkToPdf;
using DinkToPdf.Contracts;
using Repositories.Interfaces;
using Repositories.Interfaces.Addresses;
using Repositories.Interfaces.Auditor;
using Repositories.Interfaces.CustomerService;
using Repositories.Interfaces.Finance;
using Repositories.Interfaces.Operation;
using Repositories.Repositories;
using Repositories.Repositories.Addresses;
using Repositories.Repositories.Auditor;
using Repositories.Repositories.CustomerService;
using Repositories.Repositories.Finance;
using Repositories.Repositories.Operation;
using Services.AddressServices.ReceiverAddressBookService;
using Services.AddressServices.SenderAddressBookService;
using Services.CustomerServiceServices.AbnormalServices.AbnormalMainReasonService;
using Services.CustomerServiceServices.AbnormalServices.AbnormalReplyService;
using Services.CustomerServiceServices.AbnormalServices.AbnormalService;
using Services.CustomerServiceServices.AbnormalServices.AbnormalSubReasonService;
using Services.CustomerServiceServices.TicketServices.TicketMainQuestionService;
using Services.CustomerServiceServices.TicketServices.TicketReplyService;
using Services.CustomerServiceServices.TicketServices.TicketService;
using Services.CustomerServiceServices.TicketServices.TicketSubQuestionService;
using Services.FileService;
using Services.FinanceServices.CashFODCollectionService;
using Services.FinanceServices.CODCollectionService;
using Services.FinanceServices.QuotationService;
using Services.FinanceServices.ZoneService;
using Services.Mapper.AddressMapping;
using Services.Mapper.CustomerServiceMapping.AbnormalProfiles;
using Services.Mapper.CustomerServiceMapping.TicketProfiles;
using Services.Mapper.FinanceMapping;
using Services.Mapper.OperationMapping;
using Services.Mapper.OperationMapping.ReturnChangeAddAppProfiles;
using Services.Mapper.OperationMapping.SortingProfiles;
using Services.OperationServices.BranchLevelService;
using Services.OperationServices.ClientService;
using Services.OperationServices.COD_FOD_ApplicationService;
using Services.OperationServices.OrderService;
using Services.OperationServices.ProductTypeService;
using Services.OperationServices.Return_ChangeAddServices.ReturnChangeAddAppService;
using Services.OperationServices.Return_ChangeAddServices.ReturnChangeAddWaybillPrintService;
using Services.OperationServices.ScanService;
using Services.OperationServices.SortingServices.FirstSegmentService;
using Services.OperationServices.SortingServices.SecondSegmentService;
using Services.OperationServices.WaybillReprintService;
using Services.TokenService;

namespace ShippingProject.Extensions
{
    public static class AplicationServicesExtenstions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            #region AddressServices
            services.AddScoped<IRecieverAddressBookRepository, RecieverAddressBookRepository>();
            services.AddScoped<IReceiverAddressBookService, ReceiverAddressBookService>();
            services.AddAutoMapper(typeof(ReceiverAddressBookProfile));

            services.AddScoped<ISenderAddressBookRepository, SenderAddressBookRepository>();
            services.AddScoped<ISenderAddressBookService, SenderAddressBookService>();
            services.AddAutoMapper(typeof(SenderAddressBookProfile));

            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            #endregion

            #region AbnormalServices
            services.AddScoped<IAbnormalImagesRepository, AbnormalImagesRepository>();

            services.AddScoped<IAbnormalMainReasonRepository, AbnormalMainReasonRepository>();
            services.AddScoped<IAbnormalMainReasonService, AbnormalMainReasonService>();
            services.AddAutoMapper(typeof(AbnormalMainReasonProfile));

            services.AddScoped<IAbnormalReplyImageRepository, AbnormalReplyImageRepository>();

            services.AddScoped<IAbnormalReplyRepository, AbnormalReplyRepository>();
            services.AddScoped<IAbnormalReplyService, AbnormalReplyService>();
            services.AddAutoMapper(typeof(AbnormalReplyProfile));

            services.AddScoped<IAbnormalRepository, AbnormalRepository>();
            services.AddScoped<IAbnormalService, AbnormalService>();
            services.AddAutoMapper(typeof(AbnormalProfile));

            services.AddScoped<IAbnormalSubReasonRepository, AbnormalSubReasonRepository>();
            services.AddScoped<IAbnormalSubReasonService, AbnormalSubReasonService>();
            services.AddAutoMapper(typeof(AbnormalSubReasonProfile));
            #endregion

            #region TicketServices
            services.AddScoped<ITicketAttachmentRepository, TicketAttachmentRepository>();

            services.AddScoped<ITicketMainQuestionRepository, TicketMainQuestionRepository>();
            services.AddScoped<ITicketMainQuestionService, TicketMainQuestionService>();
            services.AddAutoMapper(typeof(TicketMainQuestionProfile));

            services.AddScoped<ITicketReplyAttachmentRepository, TicketReplyAttachmentRepository>();

            services.AddScoped<ITicketReplyRepository, TicketReplyRepository>();
            services.AddScoped<ITicketReplyService, TicketReplyService>();
            services.AddAutoMapper(typeof(TicketReplyProfile));

            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddAutoMapper(typeof(TicketProfile));

            services.AddScoped<ITicketSubQuestionRepository, TicketSubQuestionRepository>();
            services.AddScoped<ITicketSubQuestionService, TicketSubQuestionService>();
            services.AddAutoMapper(typeof(TicketSubQuestionProfile));
            #endregion

            #region FinanceServices
            services.AddScoped<ICashFODCollectionRepository, CashFODCollectionRepository>();
            services.AddScoped<ICashFODCollectionService, CashFODCollectionService>();
            services.AddAutoMapper(typeof(CashFODCollectionProfile));

            services.AddScoped<ICODCollectionRepository, CODCollectionRepository>();
            services.AddScoped<ICODCollectionService, CODCollectionService>();
            services.AddAutoMapper(typeof(CODCollectionProfile));

            services.AddScoped<IFormulaRepository, FormulaRepository>();

            services.AddScoped<IQuotationRepository, QuotationRepository>();
            services.AddScoped<IQuotationService, QuotationService>();
            services.AddAutoMapper(typeof(QuotationProfile));

            services.AddScoped<IZoneRepository, ZoneRepository>();
            services.AddScoped<IZoneService, ZoneService>();
            services.AddAutoMapper(typeof(ZoneProfile));
            #endregion

            #region OperationServices
            services.AddScoped<IBranchLevelRepository, BranchLevelRepository>();
            services.AddScoped<IBranchLevelService, BranchLevelService>();
            services.AddAutoMapper(typeof(BranchLevelProfile));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddAutoMapper(typeof(ClientProfile));

            services.AddScoped<ICODFODRegistrationAppRepository, CODFODRegisterationAppRepository>();
            services.AddScoped<ICODFODApplicationService, CODFODApplicationService>();
            services.AddAutoMapper(typeof(CODFODApplicationProfile));

            services.AddScoped<IFirstSegmentRepository, FirstSegmentRepository>();
            services.AddScoped<IFirstSegmentService, FirstSegmentService>();
            services.AddAutoMapper(typeof(FirstSegmentProfile));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddAutoMapper(typeof(OrderProfile));

            services.AddScoped<IOrderScanRepository, OrderScanRepository>();

            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddAutoMapper(typeof(ProductTypeProfile));

            services.AddScoped<IReturnChangeAddAppRepository, ReturnChangeAddAppRepository>();
            services.AddScoped<IReturnChangeAddAppService, ReturnChangeAddAppService>();
            services.AddAutoMapper(typeof(ReturnChangeAddAppProfile));

            services.AddScoped<IReturnChangeAddWaybillPrintRepository, ReturnChangeAddWaybillPrintRepository>();
            services.AddScoped<IReturnChangeAddWaybillPrintService, ReturnChangeAddWaybillPrintService>();
            services.AddAutoMapper(typeof(ReturnChangeAddWaybillPrintProfile));

            services.AddScoped<IScanRepository, ScanRepository>();
            services.AddScoped<IScanService, ScanService>();
            services.AddAutoMapper(typeof(ScanProfile));

            services.AddScoped<ISecondSegmentRepository, SecondSegmentRepository>();
            services.AddScoped<ISecondSegmentService, SecondSegmentService>();
            services.AddAutoMapper(typeof(SecondSegmentProfile));

            services.AddScoped<IWaybillReprintRepository, WaybillReprintRepository>();
            services.AddScoped<IWaybillReprintService, WaybillReprintService>();
            services.AddAutoMapper(typeof(WaybillReprintProfile));
            #endregion

            #region AuditRepository
            services.AddScoped<IAuditRepository, AuditRepository>();

            #endregion

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ITokenService, TokenService>();
            /*
            services.AddSingleton<IUrlGenerator>(new UrlGenerator("https://Ecommerce.com"));
           
            services.AddAutoMapper(typeof(InvoiceProfile));
            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddScoped<IPdfService, PdfService>();*/
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            return services;
        }
    }

}
