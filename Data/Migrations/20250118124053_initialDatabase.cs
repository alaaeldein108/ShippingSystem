using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProvinceId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbnormalImages",
                columns: table => new
                {
                    AbnormalNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbnormalImages", x => new { x.AbnormalNumber, x.PictureUrl });
                });

            migrationBuilder.CreateTable(
                name: "AbnormalMainReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbnormalMainReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbnormalReplies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AbnormalNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbnormalReplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbnormalReplyImages",
                columns: table => new
                {
                    ReplyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbnormalReplyImages", x => new { x.ReplyId, x.PictureUrl });
                    table.ForeignKey(
                        name: "FK_AbnormalReplyImages_AbnormalReplies_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "AbnormalReplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abnormals",
                columns: table => new
                {
                    Number = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbnormalSubReasonId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AbnormalStatus = table.Column<int>(type: "int", nullable: false),
                    RegistrationSource = table.Column<int>(type: "int", nullable: false),
                    RegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abnormals", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "AbnormalSubReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MainReasonId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbnormalSubReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbnormalSubReasons_AbnormalMainReasons_MainReasonId",
                        column: x => x.MainReasonId,
                        principalTable: "AbnormalMainReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AreaId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OpenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LevelType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AffiliatedAgencyId = table.Column<int>(type: "int", nullable: false),
                    AffiliatedHQId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PrincipalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wallet = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Center = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchLevels_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchLevels_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchLevels_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchLevels_BranchLevels_AffiliatedAgencyId",
                        column: x => x.AffiliatedAgencyId,
                        principalTable: "BranchLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchLevels_BranchLevels_AffiliatedHQId",
                        column: x => x.AffiliatedHQId,
                        principalTable: "BranchLevels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LevelType = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FirstSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstSegmentCode = table.Column<int>(type: "int", nullable: false),
                    FirstSegmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FinalOrganizationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FinalOrganizationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AreaId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirstSegments_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FirstSegments_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FirstSegments_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaybillNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    LogObjectProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogObjectProperties_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypes_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTypes_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Scans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScanTypeName = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scans_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Scans_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketMainQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketMainQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketMainQuestions_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketMainQuestions_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxNumber = table.Column<int>(type: "int", nullable: true),
                    CRNumber = table.Column<int>(type: "int", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    CustomerBRId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ContractStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaxCODAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BankAccountName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WalletCash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SalesPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChargeableWeight = table.Column<int>(type: "int", nullable: false),
                    ContractUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientCode);
                    table.ForeignKey(
                        name: "FK_Clients_Areas_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_BranchLevels_CustomerBRId",
                        column: x => x.CustomerBRId,
                        principalTable: "BranchLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ZoneType = table.Column<int>(type: "int", nullable: false),
                    AffailiatedBranchId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    QuotationType = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zones_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zones_BranchLevels_AffailiatedBranchId",
                        column: x => x.AffailiatedBranchId,
                        principalTable: "BranchLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Positions_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecondSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    FirstSegmentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondSegments_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecondSegments_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SecondSegments_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SecondSegments_BranchLevels_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BranchLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecondSegments_FirstSegments_FirstSegmentId",
                        column: x => x.FirstSegmentId,
                        principalTable: "FirstSegments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketSubQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MainQuestionId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSubQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketSubQuestions_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketSubQuestions_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TicketSubQuestions_TicketMainQuestions_MainQuestionId",
                        column: x => x.MainQuestionId,
                        principalTable: "TicketMainQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WaybillNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConnectedWaybill = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SenderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SenderPhone1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SenderPhone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SenderAddressId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SenderStreet = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RecieverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RecieverPhone1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecieverPhone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RecieverAddressId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RecieverStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemWeight = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    OrderSource = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    PickupCourierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SigningCourierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SigningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    COD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CODFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Insured = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsuranceValueFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChangeAddFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerPickupNo = table.Column<int>(type: "int", nullable: true),
                    CustomerPickupInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ClientCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClientOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[DeliveryFees] + [AdditionalFees] + [ChangeAddFees]"),
                    FOD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FODFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSigned = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VolumeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "(([Length] * [Width] * [Height]) / 5000)", stored: true),
                    PickupWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InboundWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HubWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InternalWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Voided = table.Column<int>(type: "int", nullable: false),
                    TripleNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OFDTimes = table.Column<int>(type: "int", nullable: true),
                    SettlmentMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_Orders_Areas_RecieverAddressId",
                        column: x => x.RecieverAddressId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Areas_SenderAddressId",
                        column: x => x.SenderAddressId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_PickupCourierId",
                        column: x => x.PickupCourierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_SigningCourierId",
                        column: x => x.SigningCourierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "Clients",
                        principalColumn: "ClientCode");
                    table.ForeignKey(
                        name: "FK_Orders_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FinanceCentre = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Auditing = table.Column<int>(type: "int", nullable: false),
                    ActivationStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivationEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuotationType = table.Column<int>(type: "int", nullable: false),
                    LowestServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HighestServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotations_AspNetUsers_UpdatorId",
                        column: x => x.UpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quotations_Clients_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "Clients",
                        principalColumn: "ClientCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quotations_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiverAddressBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AreaId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiverAddressBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiverAddressBooks_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiverAddressBooks_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SenderAddressBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AreaId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderAddressBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SenderAddressBooks_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SenderAddressBooks_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZoneCities",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneCities", x => new { x.CityId, x.ZoneId });
                    table.ForeignKey(
                        name: "FK_ZoneCities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZoneCities_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashFODCollections",
                columns: table => new
                {
                    BillNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CashFODCollectionStatus = table.Column<int>(type: "int", nullable: false),
                    Payment_CollectionType = table.Column<int>(type: "int", nullable: false),
                    CollectionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CollectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFODCollections", x => x.BillNumber);
                    table.ForeignKey(
                        name: "FK_CashFODCollections_AspNetUsers_CollectorId",
                        column: x => x.CollectorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashFODCollections_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CODCollections",
                columns: table => new
                {
                    BillNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CODCollectionStatus = table.Column<int>(type: "int", nullable: false),
                    CollectionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CollectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CODCollections", x => x.BillNumber);
                    table.ForeignKey(
                        name: "FK_CODCollections_AspNetUsers_CollectorId",
                        column: x => x.CollectorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CODCollections_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CODFODAdjustmentApps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdjustmentType = table.Column<int>(type: "int", nullable: false),
                    FODBeforeAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CODBeforeAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdjustmentDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfirmStatus = table.Column<int>(type: "int", nullable: false),
                    ConfirmationDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CODFODAdjustmentApps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CODFODAdjustmentApps_AspNetUsers_AuditorId",
                        column: x => x.AuditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CODFODAdjustmentApps_AspNetUsers_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CODFODAdjustmentApps_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourierOrderScheduling",
                columns: table => new
                {
                    CourierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourierType = table.Column<int>(type: "int", nullable: false),
                    AssignerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierOrderScheduling", x => new { x.OrderNumber, x.CourierId });
                    table.ForeignKey(
                        name: "FK_CourierOrderScheduling_AspNetUsers_AssignerId",
                        column: x => x.AssignerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourierOrderScheduling_AspNetUsers_CourierId",
                        column: x => x.CourierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourierOrderScheduling_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Scans",
                columns: table => new
                {
                    OrderNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScanId = table.Column<int>(type: "int", nullable: false),
                    ScanTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScannerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NextBranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Scans", x => new { x.OrderNumber, x.ScanId });
                    table.ForeignKey(
                        name: "FK_Order_Scans_AspNetUsers_ScannerId",
                        column: x => x.ScannerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Scans_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Scans_Scans_ScanId",
                        column: x => x.ScanId,
                        principalTable: "Scans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnChangeAddApps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationType = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AppStatus = table.Column<int>(type: "int", nullable: false),
                    ApplyingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnChangeAddApps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnChangeAddApps_AspNetUsers_AuditorId",
                        column: x => x.AuditorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReturnChangeAddApps_AspNetUsers_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReturnChangeAddApps_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Number = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Caller = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CallerNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubQuestionId = table.Column<int>(type: "int", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TicketStatus = table.Column<int>(type: "int", nullable: false),
                    RegisterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_ClosedPersonId",
                        column: x => x.ClosedPersonId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_RegisterId",
                        column: x => x.RegisterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketSubQuestions_SubQuestionId",
                        column: x => x.SubQuestionId,
                        principalTable: "TicketSubQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaybillReprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrintingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrinterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfPrinted = table.Column<int>(type: "int", nullable: false),
                    PrintStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaybillReprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaybillReprints_AspNetUsers_PrinterId",
                        column: x => x.PrinterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaybillReprints_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuotationZones",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    QuotationId = table.Column<int>(type: "int", nullable: false),
                    TierName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationZones", x => new { x.ZoneId, x.QuotationId });
                    table.ForeignKey(
                        name: "FK_QuotationZones_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationZones_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnChangeAddWaybillPrints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrintingScanTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnChangeAddAppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrintStatus = table.Column<int>(type: "int", nullable: false),
                    PrinterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfPrinted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnChangeAddWaybillPrints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnChangeAddWaybillPrints_AspNetUsers_PrinterId",
                        column: x => x.PrinterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnChangeAddWaybillPrints_ReturnChangeAddApps_ReturnChangeAddAppId",
                        column: x => x.ReturnChangeAddAppId,
                        principalTable: "ReturnChangeAddApps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketAttachements",
                columns: table => new
                {
                    TicketNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttachmentURL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAttachements", x => new { x.TicketNumber, x.AttachmentURL });
                    table.ForeignKey(
                        name: "FK_TicketAttachements_Tickets_TicketNumber",
                        column: x => x.TicketNumber,
                        principalTable: "Tickets",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketReplies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TicketNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketReplies_AspNetUsers_ReplierId",
                        column: x => x.ReplierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketReplies_Tickets_TicketNumber",
                        column: x => x.TicketNumber,
                        principalTable: "Tickets",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightingRoundMode = table.Column<int>(type: "int", nullable: false),
                    FormulaEquation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    QuotationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formulas_QuotationZones_ZoneId_QuotationId",
                        columns: x => new { x.ZoneId, x.QuotationId },
                        principalTable: "QuotationZones",
                        principalColumns: new[] { "ZoneId", "QuotationId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketReplyAttachments",
                columns: table => new
                {
                    TicketReplyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReplyAttachments", x => new { x.TicketReplyId, x.PictureUrl });
                    table.ForeignKey(
                        name: "FK_TicketReplyAttachments_TicketReplies_TicketReplyId",
                        column: x => x.TicketReplyId,
                        principalTable: "TicketReplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbnormalMainReasons_CreatorId",
                table: "AbnormalMainReasons",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AbnormalMainReasons_UpdatorId",
                table: "AbnormalMainReasons",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AbnormalReplies_AbnormalNumber",
                table: "AbnormalReplies",
                column: "AbnormalNumber");

            migrationBuilder.CreateIndex(
                name: "IX_AbnormalReplies_ReplierId",
                table: "AbnormalReplies",
                column: "ReplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Abnormals_AbnormalSubReasonId",
                table: "Abnormals",
                column: "AbnormalSubReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Abnormals_ClosedPersonId",
                table: "Abnormals",
                column: "ClosedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Abnormals_OrderNumber",
                table: "Abnormals",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Abnormals_RegisterId",
                table: "Abnormals",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbnormalSubReasons_CreatorId",
                table: "AbnormalSubReasons",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AbnormalSubReasons_MainReasonId",
                table: "AbnormalSubReasons",
                column: "MainReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_AbnormalSubReasons_UpdatorId",
                table: "AbnormalSubReasons",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_CreatorId",
                table: "AspNetRoles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UpdatorId",
                table: "AspNetRoles",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BranchId",
                table: "AspNetUsers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreatorId",
                table: "AspNetUsers",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PositionId",
                table: "AspNetUsers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UpdatorId",
                table: "AspNetUsers",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_AffiliatedAgencyId",
                table: "BranchLevels",
                column: "AffiliatedAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_AffiliatedHQId",
                table: "BranchLevels",
                column: "AffiliatedHQId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_AreaId",
                table: "BranchLevels",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_CreatorId",
                table: "BranchLevels",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_UpdatorId",
                table: "BranchLevels",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFODCollections_CollectorId",
                table: "CashFODCollections",
                column: "CollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CashFODCollections_OrderId",
                table: "CashFODCollections",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatorId",
                table: "Clients",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CustomerBRId",
                table: "Clients",
                column: "CustomerBRId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SalesPersonId",
                table: "Clients",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UpdatorId",
                table: "Clients",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CODCollections_CollectorId",
                table: "CODCollections",
                column: "CollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_CODCollections_OrderId",
                table: "CODCollections",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CODFODAdjustmentApps_AuditorId",
                table: "CODFODAdjustmentApps",
                column: "AuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_CODFODAdjustmentApps_OrderNumber",
                table: "CODFODAdjustmentApps",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CODFODAdjustmentApps_RegisterId",
                table: "CODFODAdjustmentApps",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierOrderScheduling_AssignerId",
                table: "CourierOrderScheduling",
                column: "AssignerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierOrderScheduling_CourierId",
                table: "CourierOrderScheduling",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatorId",
                table: "Departments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UpdatorId",
                table: "Departments",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstSegments_AreaId",
                table: "FirstSegments",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstSegments_CreatorId",
                table: "FirstSegments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstSegments_UpdatorId",
                table: "FirstSegments",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Formulas_ZoneId_QuotationId",
                table: "Formulas",
                columns: new[] { "ZoneId", "QuotationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_ScanId",
                table: "Order_Scans",
                column: "ScanId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_ScannerId",
                table: "Order_Scans",
                column: "ScannerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientCode",
                table: "Orders",
                column: "ClientCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickupCourierId",
                table: "Orders",
                column: "PickupCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductTypeId",
                table: "Orders",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RecieverAddressId",
                table: "Orders",
                column: "RecieverAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SenderAddressId",
                table: "Orders",
                column: "SenderAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SigningCourierId",
                table: "Orders",
                column: "SigningCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WaybillNumber",
                table: "Orders",
                column: "WaybillNumber",
                unique: true,
                filter: "[WaybillNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CreatorId",
                table: "Positions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_UpdatorId",
                table: "Positions",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_CreatorId",
                table: "ProductTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_UpdatorId",
                table: "ProductTypes",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ClientCode",
                table: "Quotations",
                column: "ClientCode");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CreatorId",
                table: "Quotations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ProductTypeId",
                table: "Quotations",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_UpdatorId",
                table: "Quotations",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationZones_QuotationId",
                table: "QuotationZones",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverAddressBooks_AreaId",
                table: "ReceiverAddressBooks",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverAddressBooks_ClientId",
                table: "ReceiverAddressBooks",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnChangeAddApps_AuditorId",
                table: "ReturnChangeAddApps",
                column: "AuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnChangeAddApps_OrderNumber",
                table: "ReturnChangeAddApps",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnChangeAddApps_RegisterId",
                table: "ReturnChangeAddApps",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnChangeAddWaybillPrints_PrinterId",
                table: "ReturnChangeAddWaybillPrints",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnChangeAddWaybillPrints_ReturnChangeAddAppId",
                table: "ReturnChangeAddWaybillPrints",
                column: "ReturnChangeAddAppId");

            migrationBuilder.CreateIndex(
                name: "IX_Scans_CreatorId",
                table: "Scans",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Scans_UpdatorId",
                table: "Scans",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_AreaId",
                table: "SecondSegments",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_BranchId",
                table: "SecondSegments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_CreatorId",
                table: "SecondSegments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_FirstSegmentId",
                table: "SecondSegments",
                column: "FirstSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_UpdatorId",
                table: "SecondSegments",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderAddressBooks_AreaId",
                table: "SenderAddressBooks",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderAddressBooks_ClientId",
                table: "SenderAddressBooks",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMainQuestions_CreatorId",
                table: "TicketMainQuestions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMainQuestions_UpdatorId",
                table: "TicketMainQuestions",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketReplies_ReplierId",
                table: "TicketReplies",
                column: "ReplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketReplies_TicketNumber",
                table: "TicketReplies",
                column: "TicketNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ClosedPersonId",
                table: "Tickets",
                column: "ClosedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OrderNumber",
                table: "Tickets",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RegisterId",
                table: "Tickets",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SubQuestionId",
                table: "Tickets",
                column: "SubQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSubQuestions_CreatorId",
                table: "TicketSubQuestions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSubQuestions_MainQuestionId",
                table: "TicketSubQuestions",
                column: "MainQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSubQuestions_UpdatorId",
                table: "TicketSubQuestions",
                column: "UpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WaybillReprints_OrderNumber",
                table: "WaybillReprints",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_WaybillReprints_PrinterId",
                table: "WaybillReprints",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneCities_ZoneId",
                table: "ZoneCities",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_AffailiatedBranchId",
                table: "Zones",
                column: "AffailiatedBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_CreatorId",
                table: "Zones",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_UpdatorId",
                table: "Zones",
                column: "UpdatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbnormalImages_Abnormals_AbnormalNumber",
                table: "AbnormalImages",
                column: "AbnormalNumber",
                principalTable: "Abnormals",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbnormalMainReasons_AspNetUsers_CreatorId",
                table: "AbnormalMainReasons",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AbnormalMainReasons_AspNetUsers_UpdatorId",
                table: "AbnormalMainReasons",
                column: "UpdatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AbnormalReplies_Abnormals_AbnormalNumber",
                table: "AbnormalReplies",
                column: "AbnormalNumber",
                principalTable: "Abnormals",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbnormalReplies_AspNetUsers_ReplierId",
                table: "AbnormalReplies",
                column: "ReplierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Abnormals_AbnormalSubReasons_AbnormalSubReasonId",
                table: "Abnormals",
                column: "AbnormalSubReasonId",
                principalTable: "AbnormalSubReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Abnormals_AspNetUsers_ClosedPersonId",
                table: "Abnormals",
                column: "ClosedPersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Abnormals_AspNetUsers_RegisterId",
                table: "Abnormals",
                column: "RegisterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Abnormals_Orders_OrderNumber",
                table: "Abnormals",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbnormalSubReasons_AspNetUsers_CreatorId",
                table: "AbnormalSubReasons",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AbnormalSubReasons_AspNetUsers_UpdatorId",
                table: "AbnormalSubReasons",
                column: "UpdatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_CreatorId",
                table: "AspNetRoles",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UpdatorId",
                table: "AspNetRoles",
                column: "UpdatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BranchLevels_BranchId",
                table: "AspNetUsers",
                column: "BranchId",
                principalTable: "BranchLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Positions_PositionId",
                table: "AspNetUsers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchLevels_AspNetUsers_CreatorId",
                table: "BranchLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchLevels_AspNetUsers_UpdatorId",
                table: "BranchLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_CreatorId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_UpdatorId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_AspNetUsers_CreatorId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_AspNetUsers_UpdatorId",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "AbnormalImages");

            migrationBuilder.DropTable(
                name: "AbnormalReplyImages");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CashFODCollections");

            migrationBuilder.DropTable(
                name: "CODCollections");

            migrationBuilder.DropTable(
                name: "CODFODAdjustmentApps");

            migrationBuilder.DropTable(
                name: "CourierOrderScheduling");

            migrationBuilder.DropTable(
                name: "Formulas");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Order_Scans");

            migrationBuilder.DropTable(
                name: "ReceiverAddressBooks");

            migrationBuilder.DropTable(
                name: "ReturnChangeAddWaybillPrints");

            migrationBuilder.DropTable(
                name: "SecondSegments");

            migrationBuilder.DropTable(
                name: "SenderAddressBooks");

            migrationBuilder.DropTable(
                name: "TicketAttachements");

            migrationBuilder.DropTable(
                name: "TicketReplyAttachments");

            migrationBuilder.DropTable(
                name: "WaybillReprints");

            migrationBuilder.DropTable(
                name: "ZoneCities");

            migrationBuilder.DropTable(
                name: "AbnormalReplies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "QuotationZones");

            migrationBuilder.DropTable(
                name: "Scans");

            migrationBuilder.DropTable(
                name: "ReturnChangeAddApps");

            migrationBuilder.DropTable(
                name: "FirstSegments");

            migrationBuilder.DropTable(
                name: "TicketReplies");

            migrationBuilder.DropTable(
                name: "Abnormals");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AbnormalSubReasons");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "TicketSubQuestions");

            migrationBuilder.DropTable(
                name: "AbnormalMainReasons");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "TicketMainQuestions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BranchLevels");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
