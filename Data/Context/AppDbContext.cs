using Data.Entities.Addresses;
using Data.Entities.CustomerService.Abnormal;
using Data.Entities.CustomerService.Ticket;
using Data.Entities.Finance;
using Data.Entities.Helper;
using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using Data.Entities.Operation.COD_FOD_Adjustment;
using Data.Entities.Operation.Return_ChangeAdd;
using Data.Entities.Operation.Sorting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

        }
        #region Custmer Service
        //Abnormal
        public DbSet<Abnormal> Abnormals { get; set; }
        public DbSet<AbnormalImages> AbnormalImages { get; set; }
        public DbSet<AbnormalMainReason> AbnormalMainReasons { get; set; }
        public DbSet<AbnormalSubReason> AbnormalSubReasons { get; set; }
        public DbSet<AbnormalReply> AbnormalReplies { get; set; }
        public DbSet<AbnormalReplyImages> AbnormalReplyImages { get; set; }
        //Ticket
        public DbSet<TicketMainQuestion> TicketMainQuestions { get; set; }
        public DbSet<TicketSubQuestion> TicketSubQuestions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketReply> TicketReplies { get; set; }
        public DbSet<TicketAttachements> TicketAttachements { get; set; }
        public DbSet<TicketReplyAttachment> TicketReplyAttachments { get; set; }

        #endregion

        #region Addresses
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<SenderAddressBook> SenderAddressBooks { get; set; }
        public DbSet<ReceiverAddressBook> ReceiverAddressBooks { get; set; }
        #endregion

        #region Finance
        public DbSet<CashFODCollection> CashFODCollections { get; set; }
        public DbSet<CODCollection> CODCollections { get; set; }
        public DbSet<Formula> Formulas { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationZone> QuotationZones { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<ZoneCity> ZoneCities { get; set; }

        #endregion

        #region User
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }

        #endregion

        #region Operation
        public DbSet<CODFODAdjustmentApp> CODFODAdjustmentApps { get; set; }
        public DbSet<ReturnChangeAddApp> ReturnChangeAddApps { get; set; }
        public DbSet<ReturnChangeAddWaybillPrint> ReturnChangeAddWaybillPrints { get; set; }
        public DbSet<FirstSegment> FirstSegments { get; set; }
        public DbSet<SecondSegment> SecondSegments { get; set; }
        public DbSet<BranchLevel> BranchLevels { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderScan> Order_Scans { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Scan> Scans { get; set; }
        public DbSet<WaybillReprint> WaybillReprints { get; set; }

        #endregion
        public DbSet<LogData> Logs { get; set; }


    }
}
