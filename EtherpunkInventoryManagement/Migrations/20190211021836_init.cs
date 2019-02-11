using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EtherpunkInventoryManagement.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ActiveDirectoryGuid = table.Column<string>(nullable: true),
                    ActiveDirectoryUserName = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lookups",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LookupName = table.Column<string>(nullable: true),
                    LookupType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ApplicationRoleId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_ApplicationRoles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "HardwareLayouts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareLayouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareLayouts_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Abbreviation = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FaxNumber = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LocationName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street1 = table.Column<string>(nullable: true),
                    Street2 = table.Column<string>(nullable: true),
                    TechSupportNumber = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HardwareLayoutTemplates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    Datatype_LookupId = table.Column<string>(nullable: true),
                    HardwareLayoutId = table.Column<string>(nullable: true),
                    HardwareLayoutTemplate_TypeLookupId = table.Column<string>(nullable: true),
                    HardwareLayoutTemplate_LookupId = table.Column<string>(nullable: true),
                    OrderIndex = table.Column<int>(nullable: false),
                    PropertyValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareLayoutTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareLayoutTemplates_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareLayoutTemplates_Lookups_Datatype_LookupId",
                        column: x => x.Datatype_LookupId,
                        principalTable: "Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareLayoutTemplates_HardwareLayouts_HardwareLayoutId",
                        column: x => x.HardwareLayoutId,
                        principalTable: "HardwareLayouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareLayoutTemplates_Lookups_HardwareLayoutTemplate_LookupId",
                        column: x => x.HardwareLayoutTemplate_LookupId,
                        principalTable: "Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HardwareInventories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AssignedUserId = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DatePurchased = table.Column<DateTime>(nullable: true),
                    DisposedLookupId = table.Column<string>(nullable: true),
                    FutureReplacementDate = table.Column<DateTime>(nullable: true),
                    HardwareLayoutId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ItemConditionId = table.Column<string>(nullable: true),
                    ItemConditionLookupId = table.Column<string>(nullable: true),
                    LocationDetails = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    ShortId = table.Column<string>(nullable: true),
                    VendorId = table.Column<string>(nullable: true),
                    WarrantyExpiration = table.Column<DateTime>(nullable: true),
                    WarrantyNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareInventories_AspNetUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareInventories_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareInventories_Lookups_DisposedLookupId",
                        column: x => x.DisposedLookupId,
                        principalTable: "Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareInventories_HardwareLayouts_HardwareLayoutId",
                        column: x => x.HardwareLayoutId,
                        principalTable: "HardwareLayouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareInventories_Lookups_ItemConditionId",
                        column: x => x.ItemConditionId,
                        principalTable: "Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareInventories_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareInventories_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HardwareAttachments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AttachmentData = table.Column<byte[]>(nullable: true),
                    AttachmentFileName = table.Column<string>(nullable: true),
                    AttachmentName = table.Column<string>(nullable: true),
                    AttachmentTypeId = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    HardwareInventoryId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareAttachments_Lookups_AttachmentTypeId",
                        column: x => x.AttachmentTypeId,
                        principalTable: "Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAttachments_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAttachments_HardwareInventories_HardwareInventoryId",
                        column: x => x.HardwareInventoryId,
                        principalTable: "HardwareInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HardwareAttributes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    HardwareInventoryId = table.Column<string>(nullable: true),
                    HardwareLayoutTemplateId = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareAttributes_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAttributes_HardwareInventories_HardwareInventoryId",
                        column: x => x.HardwareInventoryId,
                        principalTable: "HardwareInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAttributes_HardwareLayoutTemplates_HardwareLayoutTemplateId",
                        column: x => x.HardwareLayoutTemplateId,
                        principalTable: "HardwareLayoutTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HardwareAudits",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ActualCompletionDate = table.Column<DateTime>(nullable: true),
                    AssignedUserId = table.Column<string>(nullable: true),
                    AuditPersonRoleLookupId = table.Column<string>(nullable: true),
                    CompletedByUserId = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ExpectedCompletionDate = table.Column<DateTime>(nullable: false),
                    HardwareInventoryId = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareAudits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareAudits_AspNetUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAudits_Lookups_AuditPersonRoleLookupId",
                        column: x => x.AuditPersonRoleLookupId,
                        principalTable: "Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAudits_AspNetUsers_CompletedByUserId",
                        column: x => x.CompletedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAudits_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareAudits_HardwareInventories_HardwareInventoryId",
                        column: x => x.HardwareInventoryId,
                        principalTable: "HardwareInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HardwareInventoryAssignmentHistories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AssignedBy_UserId = table.Column<string>(nullable: true),
                    AssignedTo_UserId = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    HardwareInventoryId = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareInventoryAssignmentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareInventoryAssignmentHistories_AspNetUsers_AssignedBy_UserId",
                        column: x => x.AssignedBy_UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareInventoryAssignmentHistories_AspNetUsers_AssignedTo_UserId",
                        column: x => x.AssignedTo_UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareInventoryAssignmentHistories_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareInventoryAssignmentHistories_HardwareInventories_HardwareInventoryId",
                        column: x => x.HardwareInventoryId,
                        principalTable: "HardwareInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b30374c-4005-4021-8e4b-b64e53e68a80", "e8be4888-0461-4ae0-a567-7decdeb5f2fa", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6b28bd3-fffe-4762-bc37-1a63c6d06780", "844ab6fd-00f4-4be5-85ed-99f1e2a3d140", "Superviser", "SUPERVISER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d68a30e-caec-45d4-9df7-126478e0fa04", "d470da95-ee2b-42b2-bbbf-5f0cf47633c9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0416334c-8efe-4fb5-ad4f-7fd69744c228", "2aecd0ff-70cd-4dd4-9326-4e17f8839f98", "Tech", "TECH" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ActiveDirectoryGuid", "ActiveDirectoryUserName", "CreatedByUserId", "CreatedOn", "FirstName", "IsDeleted", "IsDisabled", "LastName" },
                values: new object[] { "4b64005b-9d67-42f6-aef0-048353afa97b", 0, "05e9d5df-1cd4-47cc-972c-f4744c1cdfd1", "ApplicationUser", "admin@admin.com", false, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "ALRDW0BNNACzQlyOjWu2SsZxHq4xU7oNofmkXEE6T+R324Lp48SOgC/I4Agb1JgFZA==", null, false, "d1db9722-9352-4db2-806a-7933c13abfaa", false, "admin@admin.com", null, null, null, new DateTime(2017, 1, 22, 11, 30, 6, 0, DateTimeKind.Unspecified), "Admin", false, true, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ActiveDirectoryGuid", "ActiveDirectoryUserName", "CreatedByUserId", "CreatedOn", "FirstName", "IsDeleted", "IsDisabled", "LastName" },
                values: new object[] { "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", 0, "e344f6b2-6ce6-4343-a53e-cc65511537cb", "ApplicationUser", "ssmith@etherpunk.com", false, true, null, "SSMITH@ETHERPUNK.COM", "SSMITH@ETHERPUNK.COM", "AEcAbg0OYVGWULi9sxi0iKqlnNWiS/S4ne7A9w5ZVRz/lNyNYVYnij86CDl+AwP7gQ==", null, false, "7c8af355-a5d1-4900-8110-ed0abac45251", false, "ssmith@etherpunk.com", null, null, null, new DateTime(2017, 1, 22, 12, 0, 16, 0, DateTimeKind.Unspecified), "Stephanie", false, false, "Smith" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ActiveDirectoryGuid", "ActiveDirectoryUserName", "CreatedByUserId", "CreatedOn", "FirstName", "IsDeleted", "IsDisabled", "LastName" },
                values: new object[] { "9fa7c39d-a4c7-4c7c-9986-b48644c309af", 0, "7f2737a0-574e-4b53-854d-472c75d154f9", "ApplicationUser", "kmann@etherpunk.com", false, true, null, "KMANN@ETHERPUNK.COM", "KMANN@ETHERPUNK.COM", "AJsDjcaPLcFFqWAZv9sOYwC7LiauV0wV13gfH40NLDQ6OIbyPxYw8wsXEHXXl5dfVA==", null, false, "18134513-41e9-4ee7-824a-327ffa04d4a3", false, "kmann@etherpunk.com", null, null, null, new DateTime(2017, 1, 22, 11, 0, 13, 0, DateTimeKind.Unspecified), "Kenny", false, false, "Mann" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ActiveDirectoryGuid", "ActiveDirectoryUserName", "CreatedByUserId", "CreatedOn", "FirstName", "IsDeleted", "IsDisabled", "LastName" },
                values: new object[] { "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", 0, "537b73c4-163d-4094-a6d5-96652bd2d602", "ApplicationUser", "dbrooks@etherpunk.com", false, true, null, "DBROOKS@ETHERPUNK.COM", "DBROOKS@ETHERPUNK.COM", "AD92BPSbLwQc6chOIjqZCJGZpfQCw2lwCrpBcU3Oen6aKuntGTiXeC5kY/Kadxs16w==", null, false, "1a341a2c-9397-4e27-8a2b-be9952e196e8", false, "dbrooks@etherpunk.com", null, null, null, new DateTime(2017, 1, 22, 12, 0, 14, 0, DateTimeKind.Unspecified), "Doug", false, false, "Brooks" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ActiveDirectoryGuid", "ActiveDirectoryUserName", "CreatedByUserId", "CreatedOn", "FirstName", "IsDeleted", "IsDisabled", "LastName" },
                values: new object[] { "d3ebdb0c-1884-4cde-ba8e-ade906609b99", 0, "c4d09148-fe3a-43bc-ad96-348dd494957f", "ApplicationUser", "njean@etherpunk.com", false, true, null, "NJEAN@ETHERPUNK.COM", "NJEAN@ETHERPUNK.COM", "APdVo9EYBJU5b93w/1wvYnd0Fdxh0Gi80qoa6g8WYpiDVkyozuEKEOvuibyH/JamnA==", null, false, "6c57daf5-5131-495c-8b67-6252a69a9e84", false, "njean@etherpunk.com", null, null, null, new DateTime(2017, 1, 22, 12, 0, 15, 0, DateTimeKind.Unspecified), "Norma", false, false, "Jean" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "05cececd-9719-4a9a-bf51-2e15f31faa5b", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9178), "Possibly Broken", "ItemCondition" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "01153d43-6f74-49e2-a191-88ed5237df96", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9162), "Broke", "ItemCondition" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "d07801e2-981b-4163-9dd6-79483ae63628", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9182), "Unknown", "ItemCondition" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "107ca0c2-fe5c-49e5-909c-4fb0d4f6e915", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9067), "Graphics Card", "HardwareTemplateLayout" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "2e7d8395-6638-4fad-9103-09d05c901354", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9072), "Make", "HardwareTemplateLayout" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "0f7feb72-c67b-4ad1-a536-328a36c0a864", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9076), "Memory", "HardwareTemplateLayout" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "212f7b7e-df8f-424b-8ca4-a4ace16ae831", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9080), "Model", "HardwareTemplateLayout" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "db3b0c57-2231-4b8f-9d95-1c7f6ee21cf8", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9141), "Price", "HardwareTemplateLayout" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "ac3d39cb-ca09-4716-a57c-210c26828d16", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9150), "Processor", "HardwareTemplateLayout" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "fc77a71a-77f5-4a01-80e8-fb54d47a883f", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9154), "Serial Number", "HardwareTemplateLayout" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "9147c301-271c-4faf-bb36-cd44cf54b5dc", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9158), "Storage Capacity", "HardwareTemplateLayout" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "ef13987e-7276-4961-9008-bbed538382d5", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9187), "Hardware", "TemplateType" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "02ec251c-d9d7-4438-9a01-c970dee721c4", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9191), "Software", "TemplateType" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "16719bae-4ed1-492e-8d85-0ce7332e088d", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9174), "Poor", "ItemCondition" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "fa9f1d43-87bb-4406-a3ca-280ea0e21909", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(6793), "Supervisor", "AuditPersonRole" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "3487407e-ea58-47b4-ba2a-e3642ccfd4f4", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9166), "Good", "ItemCondition" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "db3475df-4cde-41ad-ab1e-6081d4e7a105", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9063), "Sold", "DisposalMethod" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "315929ad-1aaa-49f7-8499-e0f6e53b58d9", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(8961), "Tech", "AuditPersonRole" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "ba42df51-8a45-42d1-abbf-f4697596d4ac", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(8994), "Supervisor", "AuditPersonRole" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "e3e6af98-265b-4ebc-a290-60d65d50dd00", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(8998), "Invoice", "BinaryDatatype" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "89fbc095-3965-4818-a221-4863c33699d9", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9002), "License", "BinaryDatatype" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "18207c02-ca41-402d-95bb-a09d107a1795", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9014), "Picture", "BinaryDatatype" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "d9c5c265-a220-4ca3-abbe-65b71d104704", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9010), "Other", "BinaryDatatype" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "659aec90-c918-49b5-b626-85a58a4255c4", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9170), "New", "ItemCondition" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "5f4aaee8-c55c-4d13-9ba2-f4a10ba66da1", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9031), "Capacity MB", "Datatype" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "b4be67cd-6e01-4caa-be04-c01971a27988", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9035), "Capacity TB", "Datatype" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "5f8ab34b-e60d-4e5a-bd5c-83f4b268812a", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9039), "Currency", "Datatype" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "7c145e98-5528-47e6-b385-e56cb906f69e", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9043), "Integer", "Datatype" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "b1c86a47-1e49-4f83-935a-5e9ac39059a0", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9047), "Real", "Datatype" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "2495bce9-8632-4681-9a10-5ea00f9eeb37", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9051), "String", "Datatype" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "d03b0c23-e14e-4afb-b565-adbe0f3da51c", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9055), "Destroyed", "DisposalMethod" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "7453eab1-8609-42cd-9460-b469c83c1e6a", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9026), "Capacity GB", "Datatype" });

            migrationBuilder.InsertData(
                table: "Lookups",
                columns: new[] { "Id", "CreatedOn", "LookupName", "LookupType" },
                values: new object[] { "987ffdc8-f90d-46bf-a0ac-4b09784852b7", new DateTime(2019, 2, 11, 2, 18, 36, 301, DateTimeKind.Utc).AddTicks(9059), "Donated", "DisposalMethod" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator", "ApplicationRoleId", "ApplicationUserId" },
                values: new object[] { "4b64005b-9d67-42f6-aef0-048353afa97b", "6d68a30e-caec-45d4-9df7-126478e0fa04", "ApplicationUserRole", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator", "ApplicationRoleId", "ApplicationUserId" },
                values: new object[] { "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", "d6b28bd3-fffe-4762-bc37-1a63c6d06780", "ApplicationUserRole", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator", "ApplicationRoleId", "ApplicationUserId" },
                values: new object[] { "9fa7c39d-a4c7-4c7c-9986-b48644c309af", "0416334c-8efe-4fb5-ad4f-7fd69744c228", "ApplicationUserRole", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator", "ApplicationRoleId", "ApplicationUserId" },
                values: new object[] { "d3ebdb0c-1884-4cde-ba8e-ade906609b99", "0416334c-8efe-4fb5-ad4f-7fd69744c228", "ApplicationUserRole", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator", "ApplicationRoleId", "ApplicationUserId" },
                values: new object[] { "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", "6b30374c-4005-4021-8e4b-b64e53e68a80", "ApplicationUserRole", null, null });

            migrationBuilder.InsertData(
                table: "HardwareLayouts",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "IsDelete", "Name", "Notes" },
                values: new object[] { "c7cfb168-e8b9-4b31-a5b8-504fb77cd449", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 12, 8, 43, 0, DateTimeKind.Unspecified), false, "Dell XPS 150", "" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Abbreviation", "City", "Country", "CreatedByUserId", "CreatedOn", "FaxNumber", "IsDeleted", "LocationName", "PhoneNumber", "State", "Street1", "Street2", "Zip" },
                values: new object[] { "721ee439-8040-4b3e-b047-6b44b1057e73", "BMT", "Beaumont", "US", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 11, 0, 13, 0, DateTimeKind.Unspecified), "1-888-111-1111", false, "Beamont Office", "409-444-1111", "TX", "103 Bird Street", "", "77701" });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "City", "Country", "CreatedByUserId", "CreatedOn", "Email", "FaxNumber", "IsDeleted", "Name", "Notes", "PhoneNumber", "State", "Street1", "Street2", "TechSupportNumber", "Zip" },
                values: new object[] { "0541cd81-b043-4b65-900c-812dcad5692e", "Dallas", "US", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 12, 5, 13, 0, DateTimeKind.Unspecified), "support@dell.com", "866-444-5454", false, "Dell", "Extension 5310 then press 9", "855-393-2299", "TX", "521 West End Blvd", "", "800-630-2910", "77618" });

            migrationBuilder.InsertData(
                table: "HardwareInventories",
                columns: new[] { "Id", "AssignedUserId", "CreatedByUserId", "CreatedOn", "DatePurchased", "DisposedLookupId", "FutureReplacementDate", "HardwareLayoutId", "IsDeleted", "ItemConditionId", "ItemConditionLookupId", "LocationDetails", "LocationId", "Name", "Notes", "ShortId", "VendorId", "WarrantyExpiration", "WarrantyNotes" },
                values: new object[] { "9a378792-3a2f-4682-ac17-17c798b9681d", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 12, 10, 10, 0, DateTimeKind.Unspecified), new DateTime(2016, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "c7cfb168-e8b9-4b31-a5b8-504fb77cd449", false, null, "3487407e-ea58-47b4-ba2a-e3642ccfd4f4", "On Kennys desk", "721ee439-8040-4b3e-b047-6b44b1057e73", "Developer machine", "", "EI-YFK-VV8-WDG", "0541cd81-b043-4b65-900c-812dcad5692e", new DateTime(2018, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Call 1-888-541-9284 for tech support; Call 1-877-483-1139 for warranty stuff" });

            migrationBuilder.InsertData(
                table: "HardwareInventories",
                columns: new[] { "Id", "AssignedUserId", "CreatedByUserId", "CreatedOn", "DatePurchased", "DisposedLookupId", "FutureReplacementDate", "HardwareLayoutId", "IsDeleted", "ItemConditionId", "ItemConditionLookupId", "LocationDetails", "LocationId", "Name", "Notes", "ShortId", "VendorId", "WarrantyExpiration", "WarrantyNotes" },
                values: new object[] { "9c8c0a85-4a31-4552-b8da-fd1114849829", "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 12, 11, 13, 0, DateTimeKind.Unspecified), new DateTime(2016, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "c7cfb168-e8b9-4b31-a5b8-504fb77cd449", false, null, "3487407e-ea58-47b4-ba2a-e3642ccfd4f4", "On Doug's desk", "721ee439-8040-4b3e-b047-6b44b1057e73", "", "", "EI-QQF-DKH-KY8", "0541cd81-b043-4b65-900c-812dcad5692e", new DateTime(2018, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Call 1-877-555-1111, Extension 5, Previous tech code 815A3" });

            migrationBuilder.InsertData(
                table: "HardwareInventories",
                columns: new[] { "Id", "AssignedUserId", "CreatedByUserId", "CreatedOn", "DatePurchased", "DisposedLookupId", "FutureReplacementDate", "HardwareLayoutId", "IsDeleted", "ItemConditionId", "ItemConditionLookupId", "LocationDetails", "LocationId", "Name", "Notes", "ShortId", "VendorId", "WarrantyExpiration", "WarrantyNotes" },
                values: new object[] { "30079d5e-83a4-4c12-9100-63b573c5dd6b", "d3ebdb0c-1884-4cde-ba8e-ade906609b99", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 12, 13, 43, 0, DateTimeKind.Unspecified), new DateTime(2016, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "c7cfb168-e8b9-4b31-a5b8-504fb77cd449", false, null, "16719bae-4ed1-492e-8d85-0ce7332e088d", "", "721ee439-8040-4b3e-b047-6b44b1057e73", "", "", "EI-M34-47F-BTX", "0541cd81-b043-4b65-900c-812dcad5692e", new DateTime(2018, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Call 1-877-555-1111, Extension 5, Previous tech code 815A3" });

            migrationBuilder.InsertData(
                table: "HardwareInventories",
                columns: new[] { "Id", "AssignedUserId", "CreatedByUserId", "CreatedOn", "DatePurchased", "DisposedLookupId", "FutureReplacementDate", "HardwareLayoutId", "IsDeleted", "ItemConditionId", "ItemConditionLookupId", "LocationDetails", "LocationId", "Name", "Notes", "ShortId", "VendorId", "WarrantyExpiration", "WarrantyNotes" },
                values: new object[] { "68889378-4756-46a4-90c3-0ca178109a24", "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 12, 15, 22, 0, DateTimeKind.Unspecified), new DateTime(2016, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "c7cfb168-e8b9-4b31-a5b8-504fb77cd449", false, null, "3487407e-ea58-47b4-ba2a-e3642ccfd4f4", "", "721ee439-8040-4b3e-b047-6b44b1057e73", "", "", "EI-46V-7F8-AQ3", "0541cd81-b043-4b65-900c-812dcad5692e", null, "Call 1-877-555-1111, Extension 5, Previous tech code 815A3" });

            migrationBuilder.InsertData(
                table: "HardwareLayoutTemplates",
                columns: new[] { "Id", "CreatedByUserId", "Datatype_LookupId", "HardwareLayoutId", "HardwareLayoutTemplate_LookupId", "HardwareLayoutTemplate_TypeLookupId", "OrderIndex", "PropertyValue" },
                values: new object[] { "f29cf67c-9a2c-47c8-9f72-eee55e6988d4", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", "2495bce9-8632-4681-9a10-5ea00f9eeb37", "c7cfb168-e8b9-4b31-a5b8-504fb77cd449", null, "2e7d8395-6638-4fad-9103-09d05c901354", 1, "Dell" });

            migrationBuilder.InsertData(
                table: "HardwareLayoutTemplates",
                columns: new[] { "Id", "CreatedByUserId", "Datatype_LookupId", "HardwareLayoutId", "HardwareLayoutTemplate_LookupId", "HardwareLayoutTemplate_TypeLookupId", "OrderIndex", "PropertyValue" },
                values: new object[] { "b943d0eb-4807-46ab-9025-f0c73147468e", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", "7453eab1-8609-42cd-9460-b469c83c1e6a", "c7cfb168-e8b9-4b31-a5b8-504fb77cd449", null, "0f7feb72-c67b-4ad1-a536-328a36c0a864", 4, "8" });

            migrationBuilder.InsertData(
                table: "HardwareLayoutTemplates",
                columns: new[] { "Id", "CreatedByUserId", "Datatype_LookupId", "HardwareLayoutId", "HardwareLayoutTemplate_LookupId", "HardwareLayoutTemplate_TypeLookupId", "OrderIndex", "PropertyValue" },
                values: new object[] { "7f30a163-7aec-47da-a87f-f6183a4745e3", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", "2495bce9-8632-4681-9a10-5ea00f9eeb37", "c7cfb168-e8b9-4b31-a5b8-504fb77cd449", null, "2e7d8395-6638-4fad-9103-09d05c901354", 2, "XPS 150" });

            migrationBuilder.InsertData(
                table: "HardwareLayoutTemplates",
                columns: new[] { "Id", "CreatedByUserId", "Datatype_LookupId", "HardwareLayoutId", "HardwareLayoutTemplate_LookupId", "HardwareLayoutTemplate_TypeLookupId", "OrderIndex", "PropertyValue" },
                values: new object[] { "851c2fbd-39c8-4a75-b401-92d61a4347b4", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", "5f8ab34b-e60d-4e5a-bd5c-83f4b268812a", "c7cfb168-e8b9-4b31-a5b8-504fb77cd449", null, "db3b0c57-2231-4b8f-9d95-1c7f6ee21cf8", 3, "678.93" });

            migrationBuilder.InsertData(
                table: "HardwareAttachments",
                columns: new[] { "Id", "AttachmentData", "AttachmentFileName", "AttachmentName", "AttachmentTypeId", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "IsDeleted" },
                values: new object[] { "62796146-70e7-4fb9-9760-cd85a73df182", null, "invoice.pdf", "XPS 150 Invoice", "e3e6af98-265b-4ebc-a290-60d65d50dd00", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2018, 8, 10, 20, 18, 36, 324, DateTimeKind.Local).AddTicks(8283), "9a378792-3a2f-4682-ac17-17c798b9681d", false });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "6fca1bc2-cac4-403a-802a-15d5447682ee", "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", new DateTime(2017, 1, 22, 12, 15, 22, 0, DateTimeKind.Unspecified), "68889378-4756-46a4-90c3-0ca178109a24", "b943d0eb-4807-46ab-9025-f0c73147468e", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "479c9ba5-bacc-47e6-acb1-4488f01926aa", "d3ebdb0c-1884-4cde-ba8e-ade906609b99", new DateTime(2017, 1, 22, 12, 13, 43, 0, DateTimeKind.Unspecified), "30079d5e-83a4-4c12-9100-63b573c5dd6b", "851c2fbd-39c8-4a75-b401-92d61a4347b4", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "110d5b05-3d43-4be6-a655-1e7f652ba66d", "d3ebdb0c-1884-4cde-ba8e-ade906609b99", new DateTime(2017, 1, 22, 12, 13, 43, 0, DateTimeKind.Unspecified), "30079d5e-83a4-4c12-9100-63b573c5dd6b", "b943d0eb-4807-46ab-9025-f0c73147468e", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "8e336999-b0e5-4245-89c3-57e7e63c9fb2", "d3ebdb0c-1884-4cde-ba8e-ade906609b99", new DateTime(2017, 1, 22, 12, 13, 43, 0, DateTimeKind.Unspecified), "30079d5e-83a4-4c12-9100-63b573c5dd6b", "7f30a163-7aec-47da-a87f-f6183a4745e3", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "cf0ffc9b-d879-4909-85ac-aeeebf4ef378", "d3ebdb0c-1884-4cde-ba8e-ade906609b99", new DateTime(2017, 1, 22, 12, 13, 43, 0, DateTimeKind.Unspecified), "30079d5e-83a4-4c12-9100-63b573c5dd6b", "f29cf67c-9a2c-47c8-9f72-eee55e6988d4", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "67ae432b-3390-4acf-b724-83ec60d3b834", "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", new DateTime(2017, 1, 22, 12, 15, 22, 0, DateTimeKind.Unspecified), "68889378-4756-46a4-90c3-0ca178109a24", "f29cf67c-9a2c-47c8-9f72-eee55e6988d4", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "3cdcc7f3-b148-4146-88fc-181047612eb5", "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", new DateTime(2017, 1, 22, 12, 11, 13, 0, DateTimeKind.Unspecified), "9c8c0a85-4a31-4552-b8da-fd1114849829", "b943d0eb-4807-46ab-9025-f0c73147468e", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "50d30d4d-c526-4a51-b405-b763dc5c2896", "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", new DateTime(2017, 1, 22, 12, 11, 13, 0, DateTimeKind.Unspecified), "9c8c0a85-4a31-4552-b8da-fd1114849829", "851c2fbd-39c8-4a75-b401-92d61a4347b4", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "f1672f5d-a885-494e-a5cb-3289a0d1f79a", "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", new DateTime(2017, 1, 22, 12, 11, 13, 0, DateTimeKind.Unspecified), "9c8c0a85-4a31-4552-b8da-fd1114849829", "f29cf67c-9a2c-47c8-9f72-eee55e6988d4", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "ca187d2b-2b4e-4027-9b21-f9ad6849cad4", "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", new DateTime(2017, 1, 22, 12, 15, 22, 0, DateTimeKind.Unspecified), "68889378-4756-46a4-90c3-0ca178109a24", "851c2fbd-39c8-4a75-b401-92d61a4347b4", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "5959f2d2-3430-4d31-a59a-e36c0250bfc1", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 12, 10, 10, 0, DateTimeKind.Unspecified), "9a378792-3a2f-4682-ac17-17c798b9681d", "851c2fbd-39c8-4a75-b401-92d61a4347b4", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "6cd2b1c9-fafc-4dae-a42a-a45bca940184", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 12, 10, 10, 0, DateTimeKind.Unspecified), "9a378792-3a2f-4682-ac17-17c798b9681d", "b943d0eb-4807-46ab-9025-f0c73147468e", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "a17667c3-9906-49bb-98c2-c1a8309a97c6", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 12, 10, 10, 0, DateTimeKind.Unspecified), "9a378792-3a2f-4682-ac17-17c798b9681d", "7f30a163-7aec-47da-a87f-f6183a4745e3", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "c45feaea-32ea-4d5b-85a0-abc639494260", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 12, 10, 10, 0, DateTimeKind.Unspecified), "9a378792-3a2f-4682-ac17-17c798b9681d", "f29cf67c-9a2c-47c8-9f72-eee55e6988d4", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "bc0f12ac-8785-4d81-97f0-71a24ab24d8e", "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", new DateTime(2017, 1, 22, 12, 11, 13, 0, DateTimeKind.Unspecified), "9c8c0a85-4a31-4552-b8da-fd1114849829", "7f30a163-7aec-47da-a87f-f6183a4745e3", "" });

            migrationBuilder.InsertData(
                table: "HardwareAttributes",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "HardwareLayoutTemplateId", "Notes" },
                values: new object[] { "cf1df671-224a-4e05-9558-99138988e988", "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", new DateTime(2017, 1, 22, 12, 15, 22, 0, DateTimeKind.Unspecified), "68889378-4756-46a4-90c3-0ca178109a24", "7f30a163-7aec-47da-a87f-f6183a4745e3", "" });

            migrationBuilder.InsertData(
                table: "HardwareAudits",
                columns: new[] { "Id", "ActualCompletionDate", "AssignedUserId", "AuditPersonRoleLookupId", "CompletedByUserId", "CreatedByUserId", "CreatedOn", "ExpectedCompletionDate", "HardwareInventoryId", "Notes" },
                values: new object[] { "c4c9cbca-49a5-4083-8b55-02fbed2edff2", new DateTime(2018, 10, 13, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(8393), "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", "fa9f1d43-87bb-4406-a3ca-280ea0e21909", "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", null, new DateTime(2018, 10, 10, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(8377), new DateTime(2018, 11, 10, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(8397), "9c8c0a85-4a31-4552-b8da-fd1114849829", "" });

            migrationBuilder.InsertData(
                table: "HardwareAudits",
                columns: new[] { "Id", "ActualCompletionDate", "AssignedUserId", "AuditPersonRoleLookupId", "CompletedByUserId", "CreatedByUserId", "CreatedOn", "ExpectedCompletionDate", "HardwareInventoryId", "Notes" },
                values: new object[] { "dda5fd7e-0e7f-418f-9a06-f5bf6a92634b", new DateTime(2018, 2, 14, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(8451), "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", "ba42df51-8a45-42d1-abbf-f4697596d4ac", "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", null, new DateTime(2018, 2, 10, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(8447), new DateTime(2018, 3, 10, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(8455), "68889378-4756-46a4-90c3-0ca178109a24", "" });

            migrationBuilder.InsertData(
                table: "HardwareAudits",
                columns: new[] { "Id", "ActualCompletionDate", "AssignedUserId", "AuditPersonRoleLookupId", "CompletedByUserId", "CreatedByUserId", "CreatedOn", "ExpectedCompletionDate", "HardwareInventoryId", "Notes" },
                values: new object[] { "8b9c9347-3189-43c8-9b7f-14d64dd19590", new DateTime(2018, 10, 13, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(6636), "9fa7c39d-a4c7-4c7c-9986-b48644c309af", "315929ad-1aaa-49f7-8499-e0f6e53b58d9", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2018, 10, 10, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(5544), new DateTime(2018, 11, 10, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(7268), "9a378792-3a2f-4682-ac17-17c798b9681d", "Fan making funny noise" });

            migrationBuilder.InsertData(
                table: "HardwareAudits",
                columns: new[] { "Id", "AssignedUserId", "AuditPersonRoleLookupId", "CompletedByUserId", "CreatedByUserId", "CreatedOn", "ExpectedCompletionDate", "HardwareInventoryId", "Notes" },
                values: new object[] { "e3dda6f9-537e-4ce5-b71d-4847b55293fe", "d3ebdb0c-1884-4cde-ba8e-ade906609b99", "315929ad-1aaa-49f7-8499-e0f6e53b58d9", null, null, new DateTime(2018, 12, 10, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(8422), new DateTime(2019, 1, 10, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(8426), "30079d5e-83a4-4c12-9100-63b573c5dd6b", "" });

            migrationBuilder.InsertData(
                table: "HardwareAudits",
                columns: new[] { "Id", "ActualCompletionDate", "AssignedUserId", "AuditPersonRoleLookupId", "CompletedByUserId", "CreatedByUserId", "CreatedOn", "ExpectedCompletionDate", "HardwareInventoryId", "Notes" },
                values: new object[] { "993cd2f2-d503-4d2c-85ae-85d7a9a8c464", new DateTime(2018, 2, 13, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(8434), "d3ebdb0c-1884-4cde-ba8e-ade906609b99", "315929ad-1aaa-49f7-8499-e0f6e53b58d9", "d3ebdb0c-1884-4cde-ba8e-ade906609b99", null, new DateTime(2018, 2, 10, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(8434), new DateTime(2018, 3, 10, 20, 18, 36, 328, DateTimeKind.Local).AddTicks(8438), "30079d5e-83a4-4c12-9100-63b573c5dd6b", "" });

            migrationBuilder.InsertData(
                table: "HardwareInventoryAssignmentHistories",
                columns: new[] { "Id", "AssignedBy_UserId", "AssignedTo_UserId", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "Notes" },
                values: new object[] { "3e2c865f-90d3-4f0c-969d-f804c2b6c16a", "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4", new DateTime(2017, 1, 22, 12, 11, 13, 0, DateTimeKind.Unspecified), "9c8c0a85-4a31-4552-b8da-fd1114849829", "Initial designation." });

            migrationBuilder.InsertData(
                table: "HardwareInventoryAssignmentHistories",
                columns: new[] { "Id", "AssignedBy_UserId", "AssignedTo_UserId", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "Notes" },
                values: new object[] { "201b1b65-5ccd-4360-92c5-aab3fdc88e5a", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", "9fa7c39d-a4c7-4c7c-9986-b48644c309af", new DateTime(2017, 1, 22, 12, 10, 10, 0, DateTimeKind.Unspecified), "9a378792-3a2f-4682-ac17-17c798b9681d", "Initial designation." });

            migrationBuilder.InsertData(
                table: "HardwareInventoryAssignmentHistories",
                columns: new[] { "Id", "AssignedBy_UserId", "AssignedTo_UserId", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "Notes" },
                values: new object[] { "468e5c12-9d4d-40d1-b31d-71a92cd39736", "d3ebdb0c-1884-4cde-ba8e-ade906609b99", "d3ebdb0c-1884-4cde-ba8e-ade906609b99", "d3ebdb0c-1884-4cde-ba8e-ade906609b99", new DateTime(2017, 1, 22, 12, 13, 43, 0, DateTimeKind.Unspecified), "30079d5e-83a4-4c12-9100-63b573c5dd6b", "Initial designation." });

            migrationBuilder.InsertData(
                table: "HardwareInventoryAssignmentHistories",
                columns: new[] { "Id", "AssignedBy_UserId", "AssignedTo_UserId", "CreatedByUserId", "CreatedOn", "HardwareInventoryId", "Notes" },
                values: new object[] { "1a35c031-489b-4773-b08a-b270035d20d5", "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d", new DateTime(2017, 1, 22, 12, 15, 22, 0, DateTimeKind.Unspecified), "68889378-4756-46a4-90c3-0ca178109a24", "Initial designation." });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ApplicationRoleId",
                table: "AspNetUserRoles",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ApplicationUserId",
                table: "AspNetUserRoles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreatedByUserId",
                table: "AspNetUsers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAttachments_AttachmentTypeId",
                table: "HardwareAttachments",
                column: "AttachmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAttachments_CreatedByUserId",
                table: "HardwareAttachments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAttachments_HardwareInventoryId",
                table: "HardwareAttachments",
                column: "HardwareInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAttributes_CreatedByUserId",
                table: "HardwareAttributes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAttributes_HardwareInventoryId",
                table: "HardwareAttributes",
                column: "HardwareInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAttributes_HardwareLayoutTemplateId",
                table: "HardwareAttributes",
                column: "HardwareLayoutTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAudits_AssignedUserId",
                table: "HardwareAudits",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAudits_AuditPersonRoleLookupId",
                table: "HardwareAudits",
                column: "AuditPersonRoleLookupId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAudits_CompletedByUserId",
                table: "HardwareAudits",
                column: "CompletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAudits_CreatedByUserId",
                table: "HardwareAudits",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareAudits_HardwareInventoryId",
                table: "HardwareAudits",
                column: "HardwareInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareInventories_AssignedUserId",
                table: "HardwareInventories",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareInventories_CreatedByUserId",
                table: "HardwareInventories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareInventories_DisposedLookupId",
                table: "HardwareInventories",
                column: "DisposedLookupId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareInventories_HardwareLayoutId",
                table: "HardwareInventories",
                column: "HardwareLayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareInventories_ItemConditionId",
                table: "HardwareInventories",
                column: "ItemConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareInventories_LocationId",
                table: "HardwareInventories",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareInventories_VendorId",
                table: "HardwareInventories",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareInventoryAssignmentHistories_AssignedBy_UserId",
                table: "HardwareInventoryAssignmentHistories",
                column: "AssignedBy_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareInventoryAssignmentHistories_AssignedTo_UserId",
                table: "HardwareInventoryAssignmentHistories",
                column: "AssignedTo_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareInventoryAssignmentHistories_CreatedByUserId",
                table: "HardwareInventoryAssignmentHistories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareInventoryAssignmentHistories_HardwareInventoryId",
                table: "HardwareInventoryAssignmentHistories",
                column: "HardwareInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareLayouts_CreatedByUserId",
                table: "HardwareLayouts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareLayoutTemplates_CreatedByUserId",
                table: "HardwareLayoutTemplates",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareLayoutTemplates_Datatype_LookupId",
                table: "HardwareLayoutTemplates",
                column: "Datatype_LookupId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareLayoutTemplates_HardwareLayoutId",
                table: "HardwareLayoutTemplates",
                column: "HardwareLayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareLayoutTemplates_HardwareLayoutTemplate_LookupId",
                table: "HardwareLayoutTemplates",
                column: "HardwareLayoutTemplate_LookupId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CreatedByUserId",
                table: "Locations",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_CreatedByUserId",
                table: "Vendors",
                column: "CreatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "HardwareAttachments");

            migrationBuilder.DropTable(
                name: "HardwareAttributes");

            migrationBuilder.DropTable(
                name: "HardwareAudits");

            migrationBuilder.DropTable(
                name: "HardwareInventoryAssignmentHistories");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "HardwareLayoutTemplates");

            migrationBuilder.DropTable(
                name: "HardwareInventories");

            migrationBuilder.DropTable(
                name: "Lookups");

            migrationBuilder.DropTable(
                name: "HardwareLayouts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
