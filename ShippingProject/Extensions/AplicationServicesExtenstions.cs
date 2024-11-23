using DinkToPdf.Contracts;
using DinkToPdf;
using System.Reflection.Emit;
using Repositories.Interfaces.Addresses;
using Repositories.Repositories.Addresses;
using Repositories.Interfaces.CustomerService;
using Repositories.Repositories.CustomerService;
using Repositories.Interfaces.Finance;
using Services.TokenService;
using Repositories.Repositories.Finance;
using Repositories.Interfaces.Operation;
using Repositories.Repositories.Operation;
using Repositories.Interfaces;
using Repositories.Repositories;

namespace ShippingProject.Extensions
{
    public static class AplicationServicesExtenstions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRecieverAddressBookRepository, RecieverAddressBookRepository>();
            services.AddScoped<ISenderAddressBookRepository, SenderAddressBookRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IAbnormalMainReasonRepository, AbnormalMainReasonRepository>();
            services.AddScoped<IAbnormalReplyRepository, AbnormalReplyRepository>();
            services.AddScoped<IAbnormalRepository, AbnormalRepository>();
            services.AddScoped<IAbnormalSubReasonRepository, AbnormalSubReasonRepository>();
            services.AddScoped<ITicketMainQuestionRepository, TicketMainQuestionRepository>();
            services.AddScoped<ITicketReplyRepository, TicketReplyRepository>();
            services.AddScoped<ITicketSubQuestionRepository, TicketSubQuestionRepository>();

            services.AddScoped<ICash_FODCollectionRepository, Cash_FODCollectionRepository>();
            services.AddScoped<ICODCollectionRepository, CODCollectionRepository>();
            services.AddScoped<IFormulaRepository, FormulaRepository>();
            services.AddScoped<IQuotationRepository, QuotationRepository>();
            services.AddScoped<IZoneRepository, ZoneRepository>();

            services.AddScoped<IBranchLevelRepository, BranchLevelRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICOD_FODApplicationRepository, COD_FODApplicationRepository>();
            services.AddScoped<IFirstSegmentRepository, FirstSegmentRepository > ();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderScanRepository, OrderScanRepository>();
            services.AddScoped<IReturnChangeAddApplicationRepository, ReturnChangeAddApplicationRepository>();
            services.AddScoped<IReturnChangeAddWaybillPrintRepository, ReturnChangeAddWaybillPrintRepository>();
            services.AddScoped<IScanRepository, ScanRepository>();
            services.AddScoped<ISecondSegmentRepository, SecondSegmentRepository>();
            services.AddScoped<IWaybillReprintRepository, WaybillReprintRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITokenService, TokenService>();
            /*services.AddAutoMapper(typeof(ProductProfile));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IProductBrandService, ProductBrandService>();
            services.AddScoped<IDeliveryMethodService, DeliveryMethodService>();
            services.AddAutoMapper(typeof(ProductTypeProfile));
            services.AddAutoMapper(typeof(ProductBrandProfile));
            services.AddAutoMapper(typeof(DeliveryMethodProfile));
            services.AddSingleton<IUrlGenerator>(new UrlGenerator("https://Ecommerce.com"));
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ICasheService, CasheService>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddAutoMapper(typeof(OrderProfile));
            services.AddAutoMapper(typeof(InvoiceProfile));
            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddScoped<IPdfService, PdfService>();*/
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            return services;
        }
    }

}
