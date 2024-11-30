using Data.Entities.Addresses;
using Data.Entities.CustomerService.Abnormal;
using Data.Entities.CustomerService.Ticket;
using Data.Entities.Finance;
using Data.Entities.IdentityEntities;
using Data.Entities.Operation;
using Data.Entities.Operation.COD_FOD_Adjustment;
using Data.Entities.Operation.Return_ChangeAdd;
using Data.Entities.Operation.Sorting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
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
            builder.Entity<AppUser>().ToTable("Users", "Security").Property(e => e.Id).HasColumnName("UserId");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security").HasKey(s => new { s.RoleId, s.UserId });
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Security").HasKey(t => new { t.LoginProvider, t.UserId, t.Name, t.Value });
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Security").HasKey(r => r.Id);
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Security").HasKey(r => r.Id);
            builder.Entity<AppRole>().ToTable("Roles", "Security").Property(e => e.Id).HasColumnName("RoleId"); ;
            builder.Ignore<IdentityUserLogin<string>>();
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
        public DbSet<Cash_FODCollection> Cash_FODCollections { get; set; }
        public DbSet<COD_Collection> COD_Collections { get; set; }
        public DbSet<Formula> Formulas { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<ClientQuotation> ClientQuotations { get; set; }
        public DbSet<Quotation_Zone> Quotation_Zones { get; set; }
        public DbSet<Zone> Zones { get; set; }

        #endregion

        #region User
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }

        #endregion

        #region Operation
        public DbSet<COD_FOD_Application> COD_FOD_Applications { get; set; }
        public DbSet<Return_ChangeAdd_App> Return_ChangeAdd_Apps { get; set; }
        public DbSet<Return_ChangeAddWaybillPrint> Return_ChangeAddWaybillPrints { get; set; }
        public DbSet<FirstSegment> FirstSegments { get; set; }
        public DbSet<SecondSegment> SecondSegments { get; set; }
        public DbSet<BranchLevel> BranchLevels { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Scan> Order_Scans { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Scan> Scans { get; set; }
        public DbSet<WaybillReprint> WaybillReprints { get; set; }
        
        #endregion
        

    }
}
