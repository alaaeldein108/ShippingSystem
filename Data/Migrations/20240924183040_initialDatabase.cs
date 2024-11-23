using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "AbnormalMainReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbnormalMainReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketMainQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketMainQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbnormalSubReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainReasonId = table.Column<int>(type: "int", nullable: false)
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
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProvinceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "TicketSubQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSubQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketSubQuestions_TicketMainQuestions_MainQuestionId",
                        column: x => x.MainQuestionId,
                        principalTable: "TicketMainQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    AbnormalNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbnormalImages", x => new { x.AbnormalNumber, x.PictureUrl });
                });

            migrationBuilder.CreateTable(
                name: "AbnormalReplies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReplyText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbnormalNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    ReplyNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbnormalReplyImages", x => new { x.ReplyNumber, x.PictureUrl });
                    table.ForeignKey(
                        name: "FK_AbnormalReplyImages_AbnormalReplies_ReplyNumber",
                        column: x => x.ReplyNumber,
                        principalTable: "AbnormalReplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abnormals",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbnormalSubReasonId = table.Column<int>(type: "int", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbnormalStatus = table.Column<int>(type: "int", nullable: false),
                    RegisterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegisterBrId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abnormals", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Abnormals_AbnormalSubReasons_AbnormalSubReasonId",
                        column: x => x.AbnormalSubReasonId,
                        principalTable: "AbnormalSubReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchLevels",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContactPhone = table.Column<int>(type: "int", nullable: false),
                    OpenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LevelType = table.Column<int>(type: "int", nullable: false),
                    BranchStatus = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuperId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrincipalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Wallet = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchLevels", x => x.Code);
                    table.ForeignKey(
                        name: "FK_BranchLevels_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchLevels_BranchLevels_SuperId",
                        column: x => x.SuperId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cash_FODCollections",
                columns: table => new
                {
                    BillNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cash_FODCollectionStatus = table.Column<int>(type: "int", nullable: false),
                    Payment_CollectionType = table.Column<int>(type: "int", nullable: false),
                    CollectionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CollectorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cash_FODCollections", x => x.BillNumber);
                });

            migrationBuilder.CreateTable(
                name: "Client_Quotations",
                columns: table => new
                {
                    ClientCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuotationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Quotations", x => new { x.ClientCode, x.QuotationId });
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<int>(type: "int", nullable: true),
                    CRNumber = table.Column<int>(type: "int", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerBRId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsEnable = table.Column<int>(type: "int", nullable: false),
                    ContractStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContractEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxCODAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletCash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChargeableWeight = table.Column<int>(type: "int", nullable: false),
                    ContractUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        name: "FK_Clients_BranchLevels_CustomerBRId",
                        column: x => x.CustomerBRId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceiverAddressBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false)
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
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false)
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
                name: "COD_Collections",
                columns: table => new
                {
                    BillNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CODCollectionStatus = table.Column<int>(type: "int", nullable: false),
                    CollectionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CollectorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COD_Collections", x => x.BillNumber);
                });

            migrationBuilder.CreateTable(
                name: "COD_FOD_Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdjustmentType = table.Column<int>(type: "int", nullable: false),
                    FODBeforeAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FODAfterAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CODBeforeAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CODAfterAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdjustmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyingBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegisterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecievingBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConfirmStatus = table.Column<int>(type: "int", nullable: false),
                    ConfirmationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COD_FOD_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COD_FOD_Applications_BranchLevels_ApplyingBranchId",
                        column: x => x.ApplyingBranchId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COD_FOD_Applications_BranchLevels_RecievingBranchId",
                        column: x => x.RecievingBranchId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelType = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "FirstSegments",
                columns: table => new
                {
                    BaggingNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaggingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstSegments", x => x.BaggingNumber);
                    table.ForeignKey(
                        name: "FK_FirstSegments_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
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
                    FormulaEquation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    QuotationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order_COD_FOD_Apps",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_COD_FOD_Apps", x => new { x.OrderNumber, x.ApplicationId });
                    table.ForeignKey(
                        name: "FK_Order_COD_FOD_Apps_COD_FOD_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "COD_FOD_Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Scans",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScanCode = table.Column<int>(type: "int", nullable: false),
                    ScanTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BranchScanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScannerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PickupCourierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeliveryCourierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NextBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PreviousBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Scans", x => new { x.OrderNumber, x.ScanCode });
                    table.ForeignKey(
                        name: "FK_Order_Scans_BranchLevels_BranchScanId",
                        column: x => x.BranchScanId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Scans_BranchLevels_NextBranchId",
                        column: x => x.NextBranchId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Scans_BranchLevels_PreviousBranchId",
                        column: x => x.PreviousBranchId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_Tickets",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Tickets", x => new { x.OrderId, x.TicketId });
                });

            migrationBuilder.CreateTable(
                name: "OrderAbnormals",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbnormalId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAbnormals", x => new { x.OrderId, x.AbnormalId });
                    table.ForeignKey(
                        name: "FK_OrderAbnormals_Abnormals_AbnormalId",
                        column: x => x.AbnormalId,
                        principalTable: "Abnormals",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WaybillNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectedWaybill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderPhone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderPhone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderAddressId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenderStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverPhone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverPhone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecieverAddressId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecieverAreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemWeight = table.Column<int>(type: "int", nullable: false),
                    ProductTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    DeliveryFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    COD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CODFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Insured = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsuranceValueFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChangeAddFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerPickupNo = table.Column<int>(type: "int", nullable: true),
                    CustomerPickupInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupCourierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeliveryCourierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PickupBRId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeliveryBRId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SigningBRId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SigningTime = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateBRId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TripleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_Orders_BranchLevels_DeliveryBRId",
                        column: x => x.DeliveryBRId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_BranchLevels_LastUpdateBRId",
                        column: x => x.LastUpdateBRId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_BranchLevels_PickupBRId",
                        column: x => x.PickupBRId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_BranchLevels_SigningBRId",
                        column: x => x.SigningBRId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientCode",
                        column: x => x.ClientCode,
                        principalTable: "Clients",
                        principalColumn: "ClientCode");
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PositionCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Positions_PositionCode",
                        column: x => x.PositionCode,
                        principalTable: "Positions",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Code);
                    table.ForeignKey(
                        name: "FK_ProductTypes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTypes_Users_ModifiedId",
                        column: x => x.ModifiedId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Return_ChangeAdd_Apps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationType = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppStatus = table.Column<int>(type: "int", nullable: false),
                    ApplyingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplyingBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegisterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecievingBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuditorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrintStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Return_ChangeAdd_Apps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Return_ChangeAdd_Apps_BranchLevels_ApplyingBranchId",
                        column: x => x.ApplyingBranchId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Return_ChangeAdd_Apps_BranchLevels_RecievingBranchId",
                        column: x => x.RecievingBranchId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Return_ChangeAdd_Apps_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Return_ChangeAdd_Apps_Users_AuditorId",
                        column: x => x.AuditorId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Return_ChangeAdd_Apps_Users_RegisterId",
                        column: x => x.RegisterId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Security",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Roles_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Roles_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Scans",
                columns: table => new
                {
                    ScanCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScanTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scans", x => x.ScanCode);
                    table.ForeignKey(
                        name: "FK_Scans_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scans_Users_ModifiedId",
                        column: x => x.ModifiedId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "SecondSegments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SecendSegmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstSegmentCode = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                        name: "FK_SecondSegments_BranchLevels_BranchCode",
                        column: x => x.BranchCode,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecondSegments_FirstSegments_FirstSegmentCode",
                        column: x => x.FirstSegmentCode,
                        principalTable: "FirstSegments",
                        principalColumn: "BaggingNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecondSegments_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecondSegments_Users_ModifiedId",
                        column: x => x.ModifiedId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Caller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverAddressId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecieverAddressId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubQuestionId = table.Column<int>(type: "int", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketStatus = table.Column<int>(type: "int", nullable: false),
                    RegisterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegisterBrId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Tickets_Areas_ReceiverAddressId",
                        column: x => x.ReceiverAddressId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_BranchLevels_RegisterBrId",
                        column: x => x.RegisterBrId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketSubQuestions_SubQuestionId",
                        column: x => x.SubQuestionId,
                        principalTable: "TicketSubQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_RegisterId",
                        column: x => x.RegisterId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.LoginProvider, x.UserId, x.Name, x.Value });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaybillReprints",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrintingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrintBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrinterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfPrinted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaybillReprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaybillReprints_BranchLevels_PrintBranchId",
                        column: x => x.PrintBranchId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaybillReprints_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaybillReprints_Users_PrinterId",
                        column: x => x.PrinterId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneType = table.Column<int>(type: "int", nullable: false),
                    AffailiatedBranchCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OriginsOrDestinations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuotationType = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_BranchLevels_AffailiatedBranchCode",
                        column: x => x.AffailiatedBranchCode,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zones_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zones_Users_ModifiedId",
                        column: x => x.ModifiedId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AffailiatedBranchCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FinanceCentre = table.Column<int>(type: "int", nullable: false),
                    ProductTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnableStatus = table.Column<int>(type: "int", nullable: false),
                    ActivationStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivationEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuotationType = table.Column<int>(type: "int", nullable: false),
                    LowestServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HighestServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_BranchLevels_AffailiatedBranchCode",
                        column: x => x.AffailiatedBranchCode,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotations_ProductTypes_ProductTypeCode",
                        column: x => x.ProductTypeCode,
                        principalTable: "ProductTypes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quotations_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotations_Users_ModifiedId",
                        column: x => x.ModifiedId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Return_ChangeAddWaybillPrints",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrintingScanTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Return_ChangeAdd_AppId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrintBranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrinterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfPrinted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Return_ChangeAddWaybillPrints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Return_ChangeAddWaybillPrints_BranchLevels_PrintBranchId",
                        column: x => x.PrintBranchId,
                        principalTable: "BranchLevels",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Return_ChangeAddWaybillPrints_Return_ChangeAdd_Apps_Return_ChangeAdd_AppId",
                        column: x => x.Return_ChangeAdd_AppId,
                        principalTable: "Return_ChangeAdd_Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Return_ChangeAddWaybillPrints_Users_PrinterId",
                        column: x => x.PrinterId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketReplyImages",
                columns: table => new
                {
                    TicketNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReplyImages", x => new { x.TicketNumber, x.PictureUrl });
                    table.ForeignKey(
                        name: "FK_TicketReplyImages_Tickets_TicketNumber",
                        column: x => x.TicketNumber,
                        principalTable: "Tickets",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quotation_Zones",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    QuotationId = table.Column<int>(type: "int", nullable: false),
                    TierName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotation_Zones", x => new { x.ZoneId, x.QuotationId });
                    table.ForeignKey(
                        name: "FK_Quotation_Zones_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quotation_Zones_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbnormalReplies_AbnormalNumber",
                table: "AbnormalReplies",
                column: "AbnormalNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Abnormals_AbnormalSubReasonId",
                table: "Abnormals",
                column: "AbnormalSubReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Abnormals_RegisterBrId",
                table: "Abnormals",
                column: "RegisterBrId");

            migrationBuilder.CreateIndex(
                name: "IX_Abnormals_RegisterId",
                table: "Abnormals",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbnormalSubReasons_MainReasonId",
                table: "AbnormalSubReasons",
                column: "MainReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_AreaId",
                table: "BranchLevels",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_CreatorId",
                table: "BranchLevels",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_ModifiedId",
                table: "BranchLevels",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_PrincipalId",
                table: "BranchLevels",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_SuperId",
                table: "BranchLevels",
                column: "SuperId");

            migrationBuilder.CreateIndex(
                name: "IX_Cash_FODCollections_CollectorId",
                table: "Cash_FODCollections",
                column: "CollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cash_FODCollections_OrderId",
                table: "Cash_FODCollections",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Quotations_QuotationId",
                table: "Client_Quotations",
                column: "QuotationId");

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
                name: "IX_Clients_ModifiedId",
                table: "Clients",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_QuotationId",
                table: "Clients",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SalesPersonId",
                table: "Clients",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_COD_Collections_CollectorId",
                table: "COD_Collections",
                column: "CollectorId");

            migrationBuilder.CreateIndex(
                name: "IX_COD_Collections_OrderId",
                table: "COD_Collections",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COD_FOD_Applications_ApplyingBranchId",
                table: "COD_FOD_Applications",
                column: "ApplyingBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_COD_FOD_Applications_AuditorId",
                table: "COD_FOD_Applications",
                column: "AuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_COD_FOD_Applications_RecievingBranchId",
                table: "COD_FOD_Applications",
                column: "RecievingBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_COD_FOD_Applications_RegisterId",
                table: "COD_FOD_Applications",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatorId",
                table: "Departments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ModifiedId",
                table: "Departments",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstSegments_AreaId",
                table: "FirstSegments",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstSegments_CreatorId",
                table: "FirstSegments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstSegments_ModifiedId",
                table: "FirstSegments",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Formulas_ZoneId_QuotationId",
                table: "Formulas",
                columns: new[] { "ZoneId", "QuotationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_COD_FOD_Apps_ApplicationId",
                table: "Order_COD_FOD_Apps",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_BranchScanId",
                table: "Order_Scans",
                column: "BranchScanId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_DeliveryCourierId",
                table: "Order_Scans",
                column: "DeliveryCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_NextBranchId",
                table: "Order_Scans",
                column: "NextBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_PickupCourierId",
                table: "Order_Scans",
                column: "PickupCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_PreviousBranchId",
                table: "Order_Scans",
                column: "PreviousBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_ScanCode",
                table: "Order_Scans",
                column: "ScanCode");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Scans_ScannerId",
                table: "Order_Scans",
                column: "ScannerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Tickets_TicketId",
                table: "Order_Tickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAbnormals_AbnormalId",
                table: "OrderAbnormals",
                column: "AbnormalId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientCode",
                table: "Orders",
                column: "ClientCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryBRId",
                table: "Orders",
                column: "DeliveryBRId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryCourierId",
                table: "Orders",
                column: "DeliveryCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LastUpdateBRId",
                table: "Orders",
                column: "LastUpdateBRId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickupBRId",
                table: "Orders",
                column: "PickupBRId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickupCourierId",
                table: "Orders",
                column: "PickupCourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductTypeCode",
                table: "Orders",
                column: "ProductTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RecieverAddressId",
                table: "Orders",
                column: "RecieverAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SenderAddressId",
                table: "Orders",
                column: "SenderAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SigningBRId",
                table: "Orders",
                column: "SigningBRId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CreatorId",
                table: "Positions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentCode",
                table: "Positions",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_ModifiedId",
                table: "Positions",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_CreatorId",
                table: "ProductTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_ModifiedId",
                table: "ProductTypes",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotation_Zones_QuotationId",
                table: "Quotation_Zones",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_AffailiatedBranchCode",
                table: "Quotations",
                column: "AffailiatedBranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CreatorId",
                table: "Quotations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ModifiedId",
                table: "Quotations",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ProductTypeCode",
                table: "Quotations",
                column: "ProductTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverAddressBooks_AreaId",
                table: "ReceiverAddressBooks",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverAddressBooks_ClientId",
                table: "ReceiverAddressBooks",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAdd_Apps_ApplyingBranchId",
                table: "Return_ChangeAdd_Apps",
                column: "ApplyingBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAdd_Apps_AuditorId",
                table: "Return_ChangeAdd_Apps",
                column: "AuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAdd_Apps_OrderId",
                table: "Return_ChangeAdd_Apps",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAdd_Apps_RecievingBranchId",
                table: "Return_ChangeAdd_Apps",
                column: "RecievingBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAdd_Apps_RegisterId",
                table: "Return_ChangeAdd_Apps",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAddWaybillPrints_PrintBranchId",
                table: "Return_ChangeAddWaybillPrints",
                column: "PrintBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAddWaybillPrints_PrinterId",
                table: "Return_ChangeAddWaybillPrints",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_Return_ChangeAddWaybillPrints_Return_ChangeAdd_AppId",
                table: "Return_ChangeAddWaybillPrints",
                column: "Return_ChangeAdd_AppId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Security",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatorId",
                schema: "Security",
                table: "Roles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ModifiedBy",
                schema: "Security",
                table: "Roles",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Scans_CreatorId",
                table: "Scans",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Scans_ModifiedId",
                table: "Scans",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_AreaId",
                table: "SecondSegments",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_BranchCode",
                table: "SecondSegments",
                column: "BranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_CreatorId",
                table: "SecondSegments",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_FirstSegmentCode",
                table: "SecondSegments",
                column: "FirstSegmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_SecondSegments_ModifiedId",
                table: "SecondSegments",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderAddressBooks_AreaId",
                table: "SenderAddressBooks",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderAddressBooks_ClientId",
                table: "SenderAddressBooks",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReceiverAddressId",
                table: "Tickets",
                column: "ReceiverAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RegisterBrId",
                table: "Tickets",
                column: "RegisterBrId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RegisterId",
                table: "Tickets",
                column: "RegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SubQuestionId",
                table: "Tickets",
                column: "SubQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSubQuestions_MainQuestionId",
                table: "TicketSubQuestions",
                column: "MainQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Security",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "Security",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatorId",
                schema: "Security",
                table: "Users",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentCode",
                schema: "Security",
                table: "Users",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedBy",
                schema: "Security",
                table: "Users",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PositionCode",
                schema: "Security",
                table: "Users",
                column: "PositionCode");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                schema: "Security",
                table: "UserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WaybillReprints_OrderNumber",
                table: "WaybillReprints",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_WaybillReprints_PrintBranchId",
                table: "WaybillReprints",
                column: "PrintBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_WaybillReprints_PrinterId",
                table: "WaybillReprints",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_AffailiatedBranchCode",
                table: "Zones",
                column: "AffailiatedBranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_CreatorId",
                table: "Zones",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_ModifiedId",
                table: "Zones",
                column: "ModifiedId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbnormalImages_Abnormals_AbnormalNumber",
                table: "AbnormalImages",
                column: "AbnormalNumber",
                principalTable: "Abnormals",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbnormalReplies_Abnormals_AbnormalNumber",
                table: "AbnormalReplies",
                column: "AbnormalNumber",
                principalTable: "Abnormals",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Abnormals_BranchLevels_RegisterBrId",
                table: "Abnormals",
                column: "RegisterBrId",
                principalTable: "BranchLevels",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Abnormals_Users_RegisterId",
                table: "Abnormals",
                column: "RegisterId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchLevels_Users_CreatorId",
                table: "BranchLevels",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchLevels_Users_ModifiedId",
                table: "BranchLevels",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchLevels_Users_PrincipalId",
                table: "BranchLevels",
                column: "PrincipalId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cash_FODCollections_Orders_OrderId",
                table: "Cash_FODCollections",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cash_FODCollections_Users_CollectorId",
                table: "Cash_FODCollections",
                column: "CollectorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Quotations_Clients_ClientCode",
                table: "Client_Quotations",
                column: "ClientCode",
                principalTable: "Clients",
                principalColumn: "ClientCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Quotations_Quotations_QuotationId",
                table: "Client_Quotations",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Quotations_QuotationId",
                table: "Clients",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CreatorId",
                table: "Clients",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_ModifiedId",
                table: "Clients",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_SalesPersonId",
                table: "Clients",
                column: "SalesPersonId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COD_Collections_Orders_OrderId",
                table: "COD_Collections",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COD_Collections_Users_CollectorId",
                table: "COD_Collections",
                column: "CollectorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COD_FOD_Applications_Users_AuditorId",
                table: "COD_FOD_Applications",
                column: "AuditorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COD_FOD_Applications_Users_RegisterId",
                table: "COD_FOD_Applications",
                column: "RegisterId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_CreatorId",
                table: "Departments",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_ModifiedId",
                table: "Departments",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstSegments_Users_CreatorId",
                table: "FirstSegments",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FirstSegments_Users_ModifiedId",
                table: "FirstSegments",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formulas_Quotation_Zones_ZoneId_QuotationId",
                table: "Formulas",
                columns: new[] { "ZoneId", "QuotationId" },
                principalTable: "Quotation_Zones",
                principalColumns: new[] { "ZoneId", "QuotationId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_COD_FOD_Apps_Orders_OrderNumber",
                table: "Order_COD_FOD_Apps",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Scans_Orders_OrderNumber",
                table: "Order_Scans",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Scans_Scans_ScanCode",
                table: "Order_Scans",
                column: "ScanCode",
                principalTable: "Scans",
                principalColumn: "ScanCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Scans_Users_DeliveryCourierId",
                table: "Order_Scans",
                column: "DeliveryCourierId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Scans_Users_PickupCourierId",
                table: "Order_Scans",
                column: "PickupCourierId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Scans_Users_ScannerId",
                table: "Order_Scans",
                column: "ScannerId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Tickets_Orders_OrderId",
                table: "Order_Tickets",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Tickets_Tickets_TicketId",
                table: "Order_Tickets",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAbnormals_Orders_OrderId",
                table: "OrderAbnormals",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductTypes_ProductTypeCode",
                table: "Orders",
                column: "ProductTypeCode",
                principalTable: "ProductTypes",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_DeliveryCourierId",
                table: "Orders",
                column: "DeliveryCourierId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_PickupCourierId",
                table: "Orders",
                column: "PickupCourierId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_CreatorId",
                table: "Positions",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_ModifiedId",
                table: "Positions",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_CreatorId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_ModifiedId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_CreatorId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_ModifiedId",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "AbnormalImages");

            migrationBuilder.DropTable(
                name: "AbnormalReplyImages");

            migrationBuilder.DropTable(
                name: "Cash_FODCollections");

            migrationBuilder.DropTable(
                name: "Client_Quotations");

            migrationBuilder.DropTable(
                name: "COD_Collections");

            migrationBuilder.DropTable(
                name: "Formulas");

            migrationBuilder.DropTable(
                name: "Order_COD_FOD_Apps");

            migrationBuilder.DropTable(
                name: "Order_Scans");

            migrationBuilder.DropTable(
                name: "Order_Tickets");

            migrationBuilder.DropTable(
                name: "OrderAbnormals");

            migrationBuilder.DropTable(
                name: "ReceiverAddressBooks");

            migrationBuilder.DropTable(
                name: "Return_ChangeAddWaybillPrints");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "SecondSegments");

            migrationBuilder.DropTable(
                name: "SenderAddressBooks");

            migrationBuilder.DropTable(
                name: "TicketReplyImages");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "WaybillReprints");

            migrationBuilder.DropTable(
                name: "AbnormalReplies");

            migrationBuilder.DropTable(
                name: "Quotation_Zones");

            migrationBuilder.DropTable(
                name: "COD_FOD_Applications");

            migrationBuilder.DropTable(
                name: "Scans");

            migrationBuilder.DropTable(
                name: "Return_ChangeAdd_Apps");

            migrationBuilder.DropTable(
                name: "FirstSegments");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Abnormals");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "TicketSubQuestions");

            migrationBuilder.DropTable(
                name: "AbnormalSubReasons");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "TicketMainQuestions");

            migrationBuilder.DropTable(
                name: "AbnormalMainReasons");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "BranchLevels");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
