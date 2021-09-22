using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asi.Infrastructure.Factory.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CertificateTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlPercent = table.Column<int>(type: "int", nullable: false),
                    AgancyPercent = table.Column<int>(type: "int", nullable: false),
                    CertificatePercent = table.Column<int>(type: "int", nullable: false),
                    MarketingPercent = table.Column<int>(type: "int", nullable: false),
                    BranchPercent = table.Column<int>(type: "int", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signiture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permissions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTypes_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateTypeId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    StandradRefference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToolCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormTemplates_CertificateTypes_CertificateTypeId",
                        column: x => x.CertificateTypeId,
                        principalTable: "CertificateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormTemplates_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormTemplateGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    HasNote = table.Column<bool>(type: "bit", nullable: false),
                    IsCheckbox = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasSubtitle = table.Column<bool>(type: "bit", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormTemplateGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormTemplateGroups_FormTemplates_FormId",
                        column: x => x.FormId,
                        principalTable: "FormTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedFormDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedFormDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedFormDatas_FormTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "FormTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerColumns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerColumns_FormTemplateGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "FormTemplateGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormTemplateRows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    TemplateGroupId = table.Column<int>(type: "int", nullable: false),
                    FirstQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForthQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormTemplateRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormTemplateRows_FormTemplateGroups_TemplateGroupId",
                        column: x => x.TemplateGroupId,
                        principalTable: "FormTemplateGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionHeaders_FormTemplateGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "FormTemplateGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpirationNotified = table.Column<bool>(type: "bit", nullable: false),
                    NeedToBeCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Rejected = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HologramNumber = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CertificateTypeId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CertificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CertificateExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvinceIdId = table.Column<int>(type: "int", nullable: false),
                    RefferenceFormId = table.Column<int>(type: "int", nullable: true),
                    Company_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_CertificateTypes_CertificateTypeId",
                        column: x => x.CertificateTypeId,
                        principalTable: "CertificateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificates_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificates_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Certificates_Provinces_ProvinceIdId",
                        column: x => x.ProvinceIdId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificates_SavedFormDatas_RefferenceFormId",
                        column: x => x.RefferenceFormId,
                        principalTable: "SavedFormDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certificates_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DataGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    SavedFormDataId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataGroups_FormTemplateGroups_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "FormTemplateGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataGroups_SavedFormDatas_SavedFormDataId",
                        column: x => x.SavedFormDataId,
                        principalTable: "SavedFormDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TemplateRowMissMatchWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateRowMissMatchWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateRowMissMatchWords_FormTemplateRows_RowId",
                        column: x => x.RowId,
                        principalTable: "FormTemplateRows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificateControls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Submitted = table.Column<bool>(type: "bit", nullable: false),
                    CertificateId = table.Column<int>(type: "int", nullable: false),
                    ControlTime = table.Column<int>(type: "int", nullable: false),
                    ControlDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CertificateControllerId = table.Column<int>(type: "int", nullable: true),
                    MainControllerId = table.Column<int>(type: "int", nullable: false),
                    ControlFormId = table.Column<int>(type: "int", nullable: false),
                    AgancyId = table.Column<int>(type: "int", nullable: true),
                    MarketingId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    TechnicalManagerId = table.Column<int>(type: "int", nullable: true),
                    Location_Longtitude = table.Column<double>(type: "float", nullable: true),
                    Location_Latitude = table.Column<double>(type: "float", nullable: true),
                    Link_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link_Signiture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificateControls_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificateControls_Persons_AgancyId",
                        column: x => x.AgancyId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CertificateControls_Persons_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CertificateControls_Persons_CertificateControllerId",
                        column: x => x.CertificateControllerId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CertificateControls_Persons_MainControllerId",
                        column: x => x.MainControllerId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CertificateControls_Persons_MarketingId",
                        column: x => x.MarketingId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CertificateControls_Persons_TechnicalManagerId",
                        column: x => x.TechnicalManagerId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CertificateControls_SavedFormDatas_ControlFormId",
                        column: x => x.ControlFormId,
                        principalTable: "SavedFormDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateId = table.Column<int>(type: "int", nullable: false),
                    ReceiptNumber = table.Column<int>(type: "int", nullable: false),
                    FactorNumber = table.Column<int>(type: "int", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormDataRows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    FirstAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForthAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FifthAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissMatchWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormDataRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormDataRows_DataGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "DataGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormDataRows_FormTemplateRows_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "FormTemplateRows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ControlImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlImage_CertificateControls_ControlId",
                        column: x => x.ControlId,
                        principalTable: "CertificateControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerColumns_GroupId",
                table: "AnswerColumns",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateControls_AgancyId",
                table: "CertificateControls",
                column: "AgancyId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateControls_BranchId",
                table: "CertificateControls",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateControls_CertificateControllerId",
                table: "CertificateControls",
                column: "CertificateControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateControls_CertificateId",
                table: "CertificateControls",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateControls_ControlFormId",
                table: "CertificateControls",
                column: "ControlFormId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateControls_MainControllerId",
                table: "CertificateControls",
                column: "MainControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateControls_MarketingId",
                table: "CertificateControls",
                column: "MarketingId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateControls_TechnicalManagerId",
                table: "CertificateControls",
                column: "TechnicalManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CertificateTypeId",
                table: "Certificates",
                column: "CertificateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_DepartmentId",
                table: "Certificates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_ItemId",
                table: "Certificates",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_ProvinceIdId",
                table: "Certificates",
                column: "ProvinceIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_RefferenceFormId",
                table: "Certificates",
                column: "RefferenceFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_ServiceTypeId",
                table: "Certificates",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlImage_ControlId",
                table: "ControlImage",
                column: "ControlId");

            migrationBuilder.CreateIndex(
                name: "IX_DataGroups_SavedFormDataId",
                table: "DataGroups",
                column: "SavedFormDataId");

            migrationBuilder.CreateIndex(
                name: "IX_DataGroups_TemplateId",
                table: "DataGroups",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_FormDataRows_GroupId",
                table: "FormDataRows",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FormDataRows_TemplateId",
                table: "FormDataRows",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_FormTemplateGroups_FormId",
                table: "FormTemplateGroups",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormTemplateRows_TemplateGroupId",
                table: "FormTemplateRows",
                column: "TemplateGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FormTemplates_CertificateTypeId",
                table: "FormTemplates",
                column: "CertificateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FormTemplates_ItemId",
                table: "FormTemplates",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ServiceTypeId",
                table: "Items",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CertificateId",
                table: "Payments",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionHeaders_GroupId",
                table: "QuestionHeaders",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedFormDatas_TemplateId",
                table: "SavedFormDatas",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_DepartmentId",
                table: "ServiceTypes",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateRowMissMatchWords_RowId",
                table: "TemplateRowMissMatchWords",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_DepartmentId",
                table: "UserDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_UserId",
                table: "UserDepartments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_ItemId",
                table: "UserItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_UserId",
                table: "UserItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerColumns");

            migrationBuilder.DropTable(
                name: "ControlImage");

            migrationBuilder.DropTable(
                name: "FormDataRows");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "QuestionHeaders");

            migrationBuilder.DropTable(
                name: "TemplateRowMissMatchWords");

            migrationBuilder.DropTable(
                name: "UserDepartments");

            migrationBuilder.DropTable(
                name: "UserItems");

            migrationBuilder.DropTable(
                name: "CertificateControls");

            migrationBuilder.DropTable(
                name: "DataGroups");

            migrationBuilder.DropTable(
                name: "FormTemplateRows");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "FormTemplateGroups");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "SavedFormDatas");

            migrationBuilder.DropTable(
                name: "FormTemplates");

            migrationBuilder.DropTable(
                name: "CertificateTypes");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
