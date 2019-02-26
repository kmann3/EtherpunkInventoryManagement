using Microsoft.AspNetCore.Identity;
using System;
using System.IO;

namespace EtherpunkInventoryManagement.Data
{
    /// <summary>
    /// Used to seed data into the database.
    /// Fake timeline is as follows:
    /// 2016.05.13 @ 00:00:00 - Doug's Dell XPS purchased (no expected replacement date)
    /// 2016.10.23 @ 00:00:00 - Kenny's Dell XPS purchased (3 year replacement date)
    /// 2016.11.14 @ 00:00:00 - Norma's XPS Purchased (no replacement date)
    /// 2017.01.22 @ 11:30:06 - Admin
    /// 2017.01.22 @ 12:00:13 - Kenny added
    /// 2017.01.22 @ 12:00:14 - Doug added
    /// 2017.01.22 @ 12:00:15 - Norma added
    /// 2017.01.22 @ 12:00:16 - Stephanie added
    /// 2017.01.22 @ 12:05:33 - Vendor / Dell added
    /// 2017.01.22 @ 12:08:43 - Dell XPS 150 added
    /// 2017.01.22 @ 12:10:10 - Kenny given Dell XPS
    /// 2017.01.22 @ 12:11:13 - Doug given Dell XPS
    /// 2017.01.22 @ 12.13:43 - Norma
    /// 2017.01.22 @ 12.15:22 - Stpehanie
    /// 2018.10.23 @ 00:00:00 - Kenny and Doug's warranty expires
    /// 2018.11.14 @ 00:00:00 - Norma's warranty expires
    /// 2019.10.23 @ 00:00:00 - Kenny's expected replacement date
    /// </summary>
    public class Entities
    {
        /// <summary>
        /// All references and assignments to inventory will be referenced in this table.
        /// </summary>
        public class AppUser
        {
            /// <summary>
            /// Primary admin account. Should be disable-able.
            /// </summary>
            public static ApplicationUser Admin = new ApplicationUser()
            {
                Id = "4b64005b-9d67-42f6-aef0-048353afa97b",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                NormalizedEmail = "admin@admin.com".ToUpper(),
                Email = "admin@admin.com",
                EmailConfirmed = false,
                PasswordHash = Util.General.HashPassword("Foobarbang!"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Admin",
                LastName = "Admin",
                IsDisabled = true,
                IsDeleted = false,
                CreatedOn = new DateTime(2017, 01, 22, 11, 30, 6)
            };

            /// <summary>
            /// Supervisor
            /// </summary>
            public static ApplicationUser Doug = new ApplicationUser()
            {
                Id = "e194001e-6302-4b2b-9ccf-cb1ba8cc9ea4",
                UserName = "dbrooks@etherpunk.com",
                NormalizedUserName = "DBROOKS@ETHERPUNK.COM",
                NormalizedEmail = "dbrooks@etherpunk.com".ToUpper(),
                Email = "dbrooks@etherpunk.com",
                EmailConfirmed = false,
                PasswordHash = Util.General.HashPassword("Foobarbang!"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Doug",
                LastName = "Brooks",
                IsDisabled = false,
                IsDeleted = false,
                CreatedOn = new DateTime(2017, 1, 22, 12, 00, 14)
            };

            /// <summary>
            /// First User / Admin
            /// </summary>
            public static ApplicationUser Kenny = new ApplicationUser()
            {
                Id = "9fa7c39d-a4c7-4c7c-9986-b48644c309af",
                UserName = "kmann@etherpunk.com",
                NormalizedUserName = "KMANN@ETHERPUNK.COM",
                NormalizedEmail = "kmann@etherpunk.com".ToUpper(),
                Email = "kmann@etherpunk.com",
                EmailConfirmed = false,
                PasswordHash = Util.General.HashPassword("Foobarbang!"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Kenny",
                LastName = "Mann",
                IsDisabled = false,
                IsDeleted = false,
                CreatedOn = new DateTime(2017, 01, 22, 11, 00, 13)
            };

            /// <summary>
            /// IT Tech
            /// </summary>
            public static ApplicationUser Norma = new ApplicationUser()
            {
                Id = "d3ebdb0c-1884-4cde-ba8e-ade906609b99",
                UserName = "njean@etherpunk.com",
                NormalizedUserName = "NJEAN@ETHERPUNK.COM",
                NormalizedEmail = "njean@etherpunk.com".ToUpper(),
                Email = "njean@etherpunk.com",
                EmailConfirmed = false,
                PasswordHash = Util.General.HashPassword("Foobarbang!"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Norma",
                LastName = "Jean",
                IsDisabled = false,
                IsDeleted = false,
                CreatedOn = new DateTime(2017, 1, 22, 12, 00, 15)
            };

            /// <summary>
            /// Clerk up front
            /// </summary>
            public static ApplicationUser Stephanie = new ApplicationUser()
            {
                Id = "f93b6937-dc27-4f8a-9d9b-5cc23c7d449d",
                UserName = "ssmith@etherpunk.com",
                NormalizedUserName = "SSMITH@ETHERPUNK.COM",
                NormalizedEmail = "ssmith@etherpunk.com".ToUpper(),
                Email = "ssmith@etherpunk.com",
                EmailConfirmed = false,
                PasswordHash = Util.General.HashPassword("Foobarbang!"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Stephanie",
                LastName = "Smith",
                IsDisabled = false,
                IsDeleted = false,
                CreatedOn = new DateTime(2017, 1, 22, 12, 00, 16)
            };
        }

        public class AppUserRole
        {
            public static ApplicationUserRole AdminAdmin = new ApplicationUserRole
            {
                UserId = AppUser.Admin.Id,
                RoleId = Roles.Admin.Id
            };

            public static ApplicationUserRole DougSupervisor = new ApplicationUserRole
            {
                UserId = AppUser.Doug.Id,
                RoleId = Roles.Superviser.Id
            };

            public static ApplicationUserRole KennyAdmin = new ApplicationUserRole
            {
                UserId = AppUser.Kenny.Id,
                RoleId = Roles.Tech.Id
            };

            public static ApplicationUserRole NormaTech = new ApplicationUserRole
            {
                UserId = AppUser.Norma.Id,
                RoleId = Roles.Tech.Id
            };

            public static ApplicationUserRole StephanieUser = new ApplicationUserRole
            {
                UserId = AppUser.Stephanie.Id,
                RoleId = Roles.User.Id
            };
        }

        public class HardwareAttachments
        {
            public static HardwareAttachment HardwareAttachment_KennyInvoice = new HardwareAttachment()
            {
                AttachmentData = File.Exists("Data/Binaries/Fake_Invoice.pdf") ? File.ReadAllBytes("Data/Binaries/Fake_Invoice.pdf") : null,
                Id = "62796146-70e7-4fb9-9760-cd85a73df182",
                AttachmentName = "XPS 150 Invoice",
                AttachmentFileName = "invoice.pdf",
                AttachmentTypeId = Lookups.BinaryDatatype_Invoice.Id,
                HardwareInventoryId = HardwareInventories.HardwareInventory_KennysComputer.Id,
                CreatedByUserId = AppUser.Kenny.Id,
                IsDeleted = false,
                CreatedOn = DateTime.Now.AddMonths(-6)
            };
        }

        public class HardwareAttributes
        {
            public static HardwareAttribute HardwareAttributes_DougDellXPS150_Make = new HardwareAttribute()
            {
                Id = "f1672f5d-a885-494e-a5cb-3289a0d1f79a",
                CreatedByUserId = AppUser.Doug.Id,
                CreatedOn = HardwareInventories.HardwareInventory_DougsComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Make.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_DougsComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_DougDellXPS150_Memory = new HardwareAttribute()
            {
                Id = "3cdcc7f3-b148-4146-88fc-181047612eb5",
                CreatedByUserId = AppUser.Doug.Id,
                CreatedOn = HardwareInventories.HardwareInventory_DougsComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Memory.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_DougsComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_DougDellXPS150_Model = new HardwareAttribute()
            {
                Id = "bc0f12ac-8785-4d81-97f0-71a24ab24d8e",
                CreatedByUserId = AppUser.Doug.Id,
                CreatedOn = HardwareInventories.HardwareInventory_DougsComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Model.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_DougsComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_DougDellXPS150_Price = new HardwareAttribute()
            {
                Id = "50d30d4d-c526-4a51-b405-b763dc5c2896",
                CreatedByUserId = AppUser.Doug.Id,
                CreatedOn = HardwareInventories.HardwareInventory_DougsComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Price.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_DougsComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_KennyDellXPS150_Make = new HardwareAttribute()
            {
                Id = "c45feaea-32ea-4d5b-85a0-abc639494260",
                CreatedByUserId = AppUser.Kenny.Id,
                CreatedOn = HardwareInventories.HardwareInventory_KennysComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Make.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_KennysComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_KennyDellXPS150_Memory = new HardwareAttribute()
            {
                Id = "6cd2b1c9-fafc-4dae-a42a-a45bca940184",
                CreatedByUserId = AppUser.Kenny.Id,
                CreatedOn = HardwareInventories.HardwareInventory_KennysComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Memory.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_KennysComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_KennyDellXPS150_Model = new HardwareAttribute()
            {
                Id = "a17667c3-9906-49bb-98c2-c1a8309a97c6",
                CreatedByUserId = AppUser.Kenny.Id,
                CreatedOn = HardwareInventories.HardwareInventory_KennysComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Model.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_KennysComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_KennyDellXPS150_Price = new HardwareAttribute()
            {
                Id = "5959f2d2-3430-4d31-a59a-e36c0250bfc1",
                CreatedByUserId = AppUser.Kenny.Id,
                CreatedOn = HardwareInventories.HardwareInventory_KennysComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Price.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_KennysComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_NormaDellXPS150_Make = new HardwareAttribute()
            {
                Id = "cf0ffc9b-d879-4909-85ac-aeeebf4ef378",
                CreatedByUserId = AppUser.Norma.Id,
                CreatedOn = HardwareInventories.HardwareInventory_NormasComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Make.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_NormasComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_NormaDellXPS150_Memory = new HardwareAttribute()
            {
                Id = "110d5b05-3d43-4be6-a655-1e7f652ba66d",
                CreatedByUserId = AppUser.Norma.Id,
                CreatedOn = HardwareInventories.HardwareInventory_NormasComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Memory.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_NormasComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_NormaDellXPS150_Model = new HardwareAttribute()
            {
                Id = "8e336999-b0e5-4245-89c3-57e7e63c9fb2",
                CreatedByUserId = AppUser.Norma.Id,
                CreatedOn = HardwareInventories.HardwareInventory_NormasComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Model.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_NormasComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_NormaDellXPS150_Price = new HardwareAttribute()
            {
                Id = "479c9ba5-bacc-47e6-acb1-4488f01926aa",
                CreatedByUserId = AppUser.Norma.Id,
                CreatedOn = HardwareInventories.HardwareInventory_NormasComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Price.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_NormasComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_StephanieDellXPS150_Make = new HardwareAttribute()
            {
                Id = "67ae432b-3390-4acf-b724-83ec60d3b834",
                CreatedByUserId = AppUser.Stephanie.Id,
                CreatedOn = HardwareInventories.HardwareInventory_StephaniesComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Make.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_StephaniesComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_StephanieDellXPS150_Memory = new HardwareAttribute()
            {
                Id = "6fca1bc2-cac4-403a-802a-15d5447682ee",
                CreatedByUserId = AppUser.Stephanie.Id,
                CreatedOn = HardwareInventories.HardwareInventory_StephaniesComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Memory.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_StephaniesComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_StephanieDellXPS150_Model = new HardwareAttribute()
            {
                Id = "cf1df671-224a-4e05-9558-99138988e988",
                CreatedByUserId = AppUser.Stephanie.Id,
                CreatedOn = HardwareInventories.HardwareInventory_StephaniesComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Model.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_StephaniesComputer.Id
            };

            public static HardwareAttribute HardwareAttributes_StephanieDellXPS150_Price = new HardwareAttribute()
            {
                Id = "ca187d2b-2b4e-4027-9b21-f9ad6849cad4",
                CreatedByUserId = AppUser.Stephanie.Id,
                CreatedOn = HardwareInventories.HardwareInventory_StephaniesComputer.CreatedOn,
                HardwareLayoutTemplateId = HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Price.Id,
                Notes = "",
                HardwareInventoryId = HardwareInventories.HardwareInventory_StephaniesComputer.Id
            };
        }

        public class HardwareAudits
        {
            /// <summary>
            /// Kenny validated his own hardware.
            /// </summary>
            public static HardwareAudit HardwareAudit_Kenny = new HardwareAudit()
            {
                Id = "8b9c9347-3189-43c8-9b7f-14d64dd19590",
                HardwareInventoryId = HardwareInventories.HardwareInventory_KennysComputer.Id,
                AuditPersonRoleLookupId = Lookups.AuditPersonRole_Tech.Id,
                CompletedByUserId = AppUser.Kenny.Id,
                CreatedByUserId = AppUser.Kenny.Id,
                CreatedOn = DateTime.Now.AddMonths(-4),
                Notes = "Fan making funny noise",
                ActualCompletionDate = DateTime.Now.AddMonths(-4).AddDays(3),
                ExpectedCompletionDate = DateTime.Now.AddMonths(-3),
                AssignedUserId = AppUser.Kenny.Id,
            };

            /// <summary>
            /// Doug validated his own hardware.
            /// </summary>
            public static HardwareAudit HardwareAudit_Doug = new HardwareAudit()
            {
                Id = "c4c9cbca-49a5-4083-8b55-02fbed2edff2",
                HardwareInventoryId = HardwareInventories.HardwareInventory_DougsComputer.Id,
                AuditPersonRoleLookupId = Lookups.AuditPersonRole_Supervisor.Id,
                CompletedByUserId = AppUser.Doug.Id,
                CreatedOn = DateTime.Now.AddMonths(-4),
                Notes = "",
                ActualCompletionDate = DateTime.Now.AddMonths(-4).AddDays(3),
                ExpectedCompletionDate = DateTime.Now.AddMonths(-3),
                AssignedUserId = AppUser.Doug.Id
            };

            public static HardwareAudit HardwareAudit_Norma1 = new HardwareAudit()
            {
                Id = "e3dda6f9-537e-4ce5-b71d-4847b55293fe",
                HardwareInventoryId = HardwareInventories.HardwareInventory_NormasComputer.Id,
                AuditPersonRoleLookupId = Lookups.AuditPersonRole_Tech.Id,
                CompletedByUserId = null,
                CreatedOn = DateTime.Now.AddMonths(-2),
                Notes = "",
                ActualCompletionDate = null,
                ExpectedCompletionDate = DateTime.Now.AddMonths(-1),
                AssignedUserId = AppUser.Norma.Id
            };

            public static HardwareAudit HardwareAudit_Norma2 = new HardwareAudit()
            {
                Id = "993cd2f2-d503-4d2c-85ae-85d7a9a8c464",
                HardwareInventoryId = HardwareInventories.HardwareInventory_NormasComputer.Id,
                AuditPersonRoleLookupId = Lookups.AuditPersonRole_Tech.Id,
                CompletedByUserId = AppUser.Norma.Id,
                CreatedOn = DateTime.Now.AddMonths(-12),
                Notes = "",
                ActualCompletionDate = DateTime.Now.AddMonths(-12).AddDays(3),
                ExpectedCompletionDate = DateTime.Now.AddMonths(-11),
                AssignedUserId = AppUser.Norma.Id
            };

            public static HardwareAudit HardwareAudit_Stephanie = new HardwareAudit()
            {
                Id = "dda5fd7e-0e7f-418f-9a06-f5bf6a92634b",
                HardwareInventoryId = HardwareInventories.HardwareInventory_StephaniesComputer.Id,
                AuditPersonRoleLookupId = Lookups.AuditPersonRole_User.Id,
                CompletedByUserId = AppUser.Stephanie.Id,
                CreatedOn = DateTime.Now.AddMonths(-12),
                Notes = "",
                ActualCompletionDate = DateTime.Now.AddMonths(-12).AddDays(4),
                ExpectedCompletionDate = DateTime.Now.AddMonths(-11),
                AssignedUserId = AppUser.Stephanie.Id
            };


        }

        public class HardwareInventories
        {
            //InventoryId = GuidPair[GuidLookup.Inventory_Two.ToString()],
            //ShortId = EtherpunkAssetManagementContext.GenerateNewUId("EPIM-", 9),
            //Locationdetails = "Under desk",
            //Name = "Norma's Front Desk",
            //WarrantyNotes = "Call 1-888-541-9284 for tech support; Call 1-877-483-1139 for warranty stuff",
            //WarrantyExpiration = DateTime.Now.AddYears(1).AddMonths(13).AddDays(5), // Sometime in the future it expires; color code this and also shoudl have a display on dashboard indicating expiring soon items,
            //DatePurchased = null, // unkown day we purcahsed it as an example
            //Notes = "Test object.",
            //IsDeleted = false,
            //DisposedLookupId = null,
            //FutureReplacementDate = null, // Since most companies never replace it until it does, this will show that there's no expected replacement date
            //AssignedUserId = GuidPair[GuidLookup.User_NormaJean.ToString()],
            //InventoryTemplateId = GuidPair[GuidLookup.InventoryTemplate_One.ToString()], // Dell XPS 150
            //LocationId = GuidPair[GuidLookup.Location_Beaumont.ToString()], // Beaumont Location
            //ItemConditionLookupId = GuidPair[GuidLookup.Lookup_ItemCondition_Good.ToString()],
            //VendorId = GuidPair[GuidLookup.Vendor_Dell.ToString()],
            //CreatedByUserId = GuidPair[GuidLookup.User_Kenny.ToString()],
            //CreatedOn = DateTime.Now.AddMonths(-6)

            public static HardwareInventory HardwareInventory_DougsComputer = new HardwareInventory
            {
                Id = "9c8c0a85-4a31-4552-b8da-fd1114849829",
                HardwareLayoutId = HardwareLayouts.HardwareLayout_DellXPS150.Id,
                CreatedOn = new DateTime(2017, 1, 22, 12, 11, 13),
                CreatedByUserId = AppUser.Kenny.Id,
                AssignedUserId = AppUser.Doug.Id,
                DatePurchased = new DateTime(2016, 05, 13, 0, 0, 0),
                DisposedLookupId = null,
                FutureReplacementDate = null,
                IsDeleted = false,
                ItemConditionLookupId = Lookups.ItemCondition_Good.Id,
                LocationDetails = "On Doug's desk",
                Name = "",
                Notes = "",
                LocationId = Locations.Location_Beaumont.Id,
                VendorId = Vendors.Vendor_Dell.Id,
                WarrantyExpiration = new DateTime(2016, 10, 23, 0, 0, 0).AddYears(2),
                WarrantyNotes = "Call 1-877-555-1111, Extension 5, Previous tech code 815A3"
            };

            public static HardwareInventory HardwareInventory_KennysComputer = new HardwareInventory
            {
                Id = "9a378792-3a2f-4682-ac17-17c798b9681d",
                HardwareLayoutId = HardwareLayouts.HardwareLayout_DellXPS150.Id,
                CreatedOn = new DateTime(2017, 1, 22, 12, 10, 10),
                CreatedByUserId = AppUser.Kenny.Id,
                AssignedUserId = AppUser.Kenny.Id,
                DatePurchased = new DateTime(2016, 10, 23, 0, 0, 0),
                DisposedLookupId = null,
                FutureReplacementDate = new DateTime(2016, 10, 23, 0, 0, 0).AddYears(3),
                IsDeleted = false,
                ItemConditionLookupId = Lookups.ItemCondition_Good.Id,
                LocationDetails = "On Kennys desk",
                Name = "Developer machine",
                Notes = "",
                LocationId = Locations.Location_Beaumont.Id,
                VendorId = Vendors.Vendor_Dell.Id,
                WarrantyExpiration = new DateTime(2016, 10, 23, 0, 0, 0).AddYears(2),
                WarrantyNotes = "Call 1-888-541-9284 for tech support; Call 1-877-483-1139 for warranty stuff"
            };

            public static HardwareInventory HardwareInventory_NormasComputer = new HardwareInventory
            {
                Id = "30079d5e-83a4-4c12-9100-63b573c5dd6b",
                HardwareLayoutId = HardwareLayouts.HardwareLayout_DellXPS150.Id,
                CreatedOn = new DateTime(2017, 1, 22, 12, 13, 43),
                CreatedByUserId = AppUser.Kenny.Id,
                AssignedUserId = AppUser.Norma.Id,
                DatePurchased = new DateTime(2016, 11, 14, 0, 0, 0),
                DisposedLookupId = null,
                FutureReplacementDate = null,
                IsDeleted = false,
                ItemConditionLookupId = Lookups.ItemCondition_Poor.Id,
                LocationDetails = "",
                Name = "",
                Notes = "",
                LocationId = Locations.Location_Beaumont.Id,
                VendorId = Vendors.Vendor_Dell.Id,
                WarrantyExpiration = new DateTime(2016, 11, 14, 0, 0, 0).AddYears(2),
                WarrantyNotes = "Call 1-877-555-1111, Extension 5, Previous tech code 815A3"
            };

            public static HardwareInventory HardwareInventory_StephaniesComputer = new HardwareInventory
            {
                Id = "68889378-4756-46a4-90c3-0ca178109a24",
                HardwareLayoutId = HardwareLayouts.HardwareLayout_DellXPS150.Id,
                CreatedOn = new DateTime(2017, 1, 22, 12, 15, 22),
                CreatedByUserId = AppUser.Kenny.Id,
                AssignedUserId = AppUser.Stephanie.Id,
                DatePurchased = new DateTime(2016, 11, 14, 0, 0, 0),
                DisposedLookupId = null,
                FutureReplacementDate = null,
                IsDeleted = false,
                ItemConditionLookupId = Lookups.ItemCondition_Good.Id,
                LocationDetails = "",
                Name = "",
                Notes = "",
                LocationId = Locations.Location_Beaumont.Id,
                VendorId = Vendors.Vendor_Dell.Id,
                WarrantyExpiration = null,
                WarrantyNotes = "Call 1-877-555-1111, Extension 5, Previous tech code 815A3"
            };
        }

        public class HardwareInventoryAssignmentHistories
        {
            public static HardwareInventoryAssignmentHistory HardwareInventoryAssignmentHistory_Kenny = new HardwareInventoryAssignmentHistory()
            {
                Id = "201b1b65-5ccd-4360-92c5-aab3fdc88e5a",
                AssignedBy_UserId = AppUser.Kenny.Id,
                AssignedTo_UserId = AppUser.Kenny.Id,
                CreatedByUserId = AppUser.Kenny.Id,
                CreatedOn = HardwareInventories.HardwareInventory_KennysComputer.CreatedOn,
                HardwareInventoryId = HardwareInventories.HardwareInventory_KennysComputer.Id,
                Notes = "Initial designation."
            };

            public static HardwareInventoryAssignmentHistory HardwareInventoryAssignmentHistory_Doug = new HardwareInventoryAssignmentHistory()
            {
                Id = "3e2c865f-90d3-4f0c-969d-f804c2b6c16a",
                AssignedBy_UserId = AppUser.Doug.Id,
                AssignedTo_UserId = AppUser.Doug.Id,
                CreatedByUserId = AppUser.Doug.Id,
                CreatedOn = HardwareInventories.HardwareInventory_DougsComputer.CreatedOn,
                HardwareInventoryId = HardwareInventories.HardwareInventory_DougsComputer.Id,
                Notes = "Initial designation."
            };

            public static HardwareInventoryAssignmentHistory HardwareInventoryAssignmentHistory_Norma = new HardwareInventoryAssignmentHistory()
            {
                Id = "468e5c12-9d4d-40d1-b31d-71a92cd39736",
                AssignedBy_UserId = AppUser.Norma.Id,
                AssignedTo_UserId = AppUser.Norma.Id,
                CreatedByUserId = AppUser.Norma.Id,
                CreatedOn = HardwareInventories.HardwareInventory_NormasComputer.CreatedOn,
                HardwareInventoryId = HardwareInventories.HardwareInventory_NormasComputer.Id,
                Notes = "Initial designation."
            };

            public static HardwareInventoryAssignmentHistory HardwareInventoryAssignmentHistory_Stephanie = new HardwareInventoryAssignmentHistory()
            {
                Id = "1a35c031-489b-4773-b08a-b270035d20d5",
                AssignedBy_UserId = AppUser.Stephanie.Id,
                AssignedTo_UserId = AppUser.Stephanie.Id,
                CreatedByUserId = AppUser.Stephanie.Id,
                CreatedOn = HardwareInventories.HardwareInventory_StephaniesComputer.CreatedOn,
                HardwareInventoryId = HardwareInventories.HardwareInventory_StephaniesComputer.Id,
                Notes = "Initial designation."
            };
        }

        public class HardwareLayouts
        {
            public static HardwareLayout HardwareLayout_DellXPS150 = new HardwareLayout
            {
                Id = "c7cfb168-e8b9-4b31-a5b8-504fb77cd449",
                CreatedByUserId = AppUser.Kenny.Id,
                IsDelete = false,
                Name = "Dell XPS 150",
                Notes = "",
                CreatedOn = new DateTime(2017, 1, 22, 12, 08, 43)
            };
        }

        public class HardwareLayoutTemplates
        {
            public static HardwareLayoutTemplate HardwareLayoutTemplate_DellXPS_Make = new HardwareLayoutTemplate
            {
                Id = "f29cf67c-9a2c-47c8-9f72-eee55e6988d4",
                CreatedByUserId = AppUser.Kenny.Id,
                Datatype_LookupId = Lookups.Datatype_String.Id,
                HardwareLayoutTemplate_TypeLookupId = Lookups.HardwareLayoutTemplate_Make.Id,
                OrderIndex = 1,
                PropertyValue = "Dell",
                HardwareLayoutId = HardwareLayouts.HardwareLayout_DellXPS150.Id
            };

            public static HardwareLayoutTemplate HardwareLayoutTemplate_DellXPS_Memory = new HardwareLayoutTemplate
            {
                Id = "b943d0eb-4807-46ab-9025-f0c73147468e",
                CreatedByUserId = AppUser.Kenny.Id,
                Datatype_LookupId = Lookups.Datatype_CapacityGB.Id,
                HardwareLayoutTemplate_TypeLookupId = Lookups.HardwareLayoutTemplate_Memory.Id,
                OrderIndex = 4,
                PropertyValue = "8",
                HardwareLayoutId = HardwareLayouts.HardwareLayout_DellXPS150.Id
            };

            public static HardwareLayoutTemplate HardwareLayoutTemplate_DellXPS_Model = new HardwareLayoutTemplate
            {
                Id = "7f30a163-7aec-47da-a87f-f6183a4745e3",
                CreatedByUserId = AppUser.Kenny.Id,
                Datatype_LookupId = Lookups.Datatype_String.Id,
                HardwareLayoutTemplate_TypeLookupId = Lookups.HardwareLayoutTemplate_Make.Id,
                OrderIndex = 2,
                PropertyValue = "XPS 150",
                HardwareLayoutId = HardwareLayouts.HardwareLayout_DellXPS150.Id
            };

            public static HardwareLayoutTemplate HardwareLayoutTemplate_DellXPS_Price = new HardwareLayoutTemplate
            {
                Id = "851c2fbd-39c8-4a75-b401-92d61a4347b4",
                CreatedByUserId = AppUser.Kenny.Id,
                Datatype_LookupId = Lookups.Datatype_Currency.Id,
                HardwareLayoutTemplate_TypeLookupId = Lookups.HardwareLayoutTemplate_Price.Id,
                OrderIndex = 3,
                PropertyValue = "678.93",
                HardwareLayoutId = HardwareLayouts.HardwareLayout_DellXPS150.Id
            };
        }

        public class Locations
        {
            public static Location Location_Beaumont = new Location()
            {
                Id = "721ee439-8040-4b3e-b047-6b44b1057e73",
                Abbreviation = "BMT",
                City = "Beaumont",
                Country = "US",
                CreatedByUserId = AppUser.Kenny.Id,
                CreatedOn = AppUser.Kenny.CreatedOn,
                FaxNumber = "1-888-111-1111",
                IsDeleted = false,
                LocationName = "Beamont Office",
                PhoneNumber = "409-444-1111",
                State = "TX",
                Street1 = "103 Bird Street",
                Street2 = "",
                Zip = "77701"
            };
        }

        public class Lookups
        {
            public static Lookup AuditPersonRole_Supervisor = new Lookup()
            {
                Id = "fa9f1d43-87bb-4406-a3ca-280ea0e21909",
                LookupName = "Supervisor",
                LookupType = Lookup.LookupTypes.AuditPersonRole.ToString()
            };

            public static Lookup AuditPersonRole_Tech = new Lookup()
            {
                Id = "315929ad-1aaa-49f7-8499-e0f6e53b58d9",
                LookupName = "Tech",
                LookupType = Lookup.LookupTypes.AuditPersonRole.ToString()
            };

            public static Lookup AuditPersonRole_User = new Lookup()
            {
                Id = "ba42df51-8a45-42d1-abbf-f4697596d4ac",
                LookupName = "User",
                LookupType = Lookup.LookupTypes.AuditPersonRole.ToString()
            };

            public static Lookup BinaryDatatype_Invoice = new Lookup()
            {
                Id = "e3e6af98-265b-4ebc-a290-60d65d50dd00",
                LookupName = "Invoice",
                LookupType = Lookup.LookupTypes.BinaryDatatype.ToString()
            };

            public static Lookup BinaryDatatype_License = new Lookup()
            {
                Id = "89fbc095-3965-4818-a221-4863c33699d9",
                LookupName = "License",
                LookupType = Lookup.LookupTypes.BinaryDatatype.ToString()
            };

            public static Lookup BinaryDatatype_Other = new Lookup()
            {
                Id = "d9c5c265-a220-4ca3-abbe-65b71d104704",
                LookupName = "Other",
                LookupType = Lookup.LookupTypes.BinaryDatatype.ToString()
            };

            public static Lookup BinaryDatatype_Picture = new Lookup()
            {
                Id = "18207c02-ca41-402d-95bb-a09d107a1795",
                LookupName = "Picture",
                LookupType = Lookup.LookupTypes.BinaryDatatype.ToString()
            };

            public static Lookup Datatype_CapacityGB = new Lookup()
            {
                Id = "7453eab1-8609-42cd-9460-b469c83c1e6a",
                LookupName = "Capacity GB",
                LookupType = Lookup.LookupTypes.Datatype.ToString()
            };

            public static Lookup Datatype_CapacityMB = new Lookup()
            {
                Id = "5f4aaee8-c55c-4d13-9ba2-f4a10ba66da1",
                LookupName = "Capacity MB",
                LookupType = Lookup.LookupTypes.Datatype.ToString()
            };

            public static Lookup Datatype_CapacityTB = new Lookup()
            {
                Id = "b4be67cd-6e01-4caa-be04-c01971a27988",
                LookupName = "Capacity TB",
                LookupType = Lookup.LookupTypes.Datatype.ToString()
            };

            public static Lookup Datatype_Currency = new Lookup()
            {
                Id = "5f8ab34b-e60d-4e5a-bd5c-83f4b268812a",
                LookupName = "Currency",
                LookupType = Lookup.LookupTypes.Datatype.ToString()
            };

            public static Lookup Datatype_Integer = new Lookup()
            {
                Id = "7c145e98-5528-47e6-b385-e56cb906f69e",
                LookupName = "Integer",
                LookupType = Lookup.LookupTypes.Datatype.ToString()
            };

            public static Lookup Datatype_Real = new Lookup()
            {
                Id = "b1c86a47-1e49-4f83-935a-5e9ac39059a0",
                LookupName = "Real",
                LookupType = Lookup.LookupTypes.Datatype.ToString()
            };

            public static Lookup Datatype_String = new Lookup()
            {
                Id = "2495bce9-8632-4681-9a10-5ea00f9eeb37",
                LookupName = "String",
                LookupType = Lookup.LookupTypes.Datatype.ToString()
            };

            public static Lookup DisposalMethod_Destroyed = new Lookup()
            {
                Id = "d03b0c23-e14e-4afb-b565-adbe0f3da51c",
                LookupName = "Destroyed",
                LookupType = Lookup.LookupTypes.DisposalMethod.ToString()
            };

            public static Lookup DisposalMethod_Donated = new Lookup()
            {
                Id = "987ffdc8-f90d-46bf-a0ac-4b09784852b7",
                LookupName = "Donated",
                LookupType = Lookup.LookupTypes.DisposalMethod.ToString()
            };

            public static Lookup DisposalMethod_Sold = new Lookup()
            {
                Id = "db3475df-4cde-41ad-ab1e-6081d4e7a105",
                LookupName = "Sold",
                LookupType = Lookup.LookupTypes.DisposalMethod.ToString()
            };

            public static Lookup HardwareLayoutTemplate_GraphicsCard = new Lookup
            {
                Id = "107ca0c2-fe5c-49e5-909c-4fb0d4f6e915",
                LookupName = "Graphics Card",
                LookupType = Lookup.LookupTypes.HardwareTemplateLayout.ToString()
            };

            public static Lookup HardwareLayoutTemplate_Make = new Lookup
            {
                Id = "2e7d8395-6638-4fad-9103-09d05c901354",
                LookupName = "Make",
                LookupType = Lookup.LookupTypes.HardwareTemplateLayout.ToString()
            };

            public static Lookup HardwareLayoutTemplate_Memory = new Lookup
            {
                Id = "0f7feb72-c67b-4ad1-a536-328a36c0a864",
                LookupName = "Memory",
                LookupType = Lookup.LookupTypes.HardwareTemplateLayout.ToString()
            };

            public static Lookup HardwareLayoutTemplate_Model = new Lookup
            {
                Id = "212f7b7e-df8f-424b-8ca4-a4ace16ae831",
                LookupName = "Model",
                LookupType = Lookup.LookupTypes.HardwareTemplateLayout.ToString()
            };

            public static Lookup HardwareLayoutTemplate_Price = new Lookup
            {
                Id = "db3b0c57-2231-4b8f-9d95-1c7f6ee21cf8",
                LookupName = "Price",
                LookupType = Lookup.LookupTypes.HardwareTemplateLayout.ToString()
            };

            public static Lookup HardwareLayoutTemplate_Processor = new Lookup
            {
                Id = "ac3d39cb-ca09-4716-a57c-210c26828d16",
                LookupName = "Processor",
                LookupType = Lookup.LookupTypes.HardwareTemplateLayout.ToString()
            };

            public static Lookup HardwareLayoutTemplate_SerialNumber = new Lookup
            {
                Id = "fc77a71a-77f5-4a01-80e8-fb54d47a883f",
                LookupName = "Serial Number",
                LookupType = Lookup.LookupTypes.HardwareTemplateLayout.ToString()
            };

            public static Lookup HardwareLayoutTemplate_StorageCapacity = new Lookup
            {
                Id = "9147c301-271c-4faf-bb36-cd44cf54b5dc",
                LookupName = "Storage Capacity",
                LookupType = Lookup.LookupTypes.HardwareTemplateLayout.ToString()
            };

            public static Lookup ItemCondition_Broke = new Lookup
            {
                Id = "01153d43-6f74-49e2-a191-88ed5237df96",
                LookupName = "Broke",
                LookupType = Lookup.LookupTypes.ItemCondition.ToString()
            };

            public static Lookup ItemCondition_Good = new Lookup
            {
                Id = "3487407e-ea58-47b4-ba2a-e3642ccfd4f4",
                LookupName = "Good",
                LookupType = Lookup.LookupTypes.ItemCondition.ToString()
            };

            public static Lookup ItemCondition_New = new Lookup
            {
                Id = "659aec90-c918-49b5-b626-85a58a4255c4",
                LookupName = "New",
                LookupType = Lookup.LookupTypes.ItemCondition.ToString()
            };

            public static Lookup ItemCondition_Poor = new Lookup
            {
                Id = "16719bae-4ed1-492e-8d85-0ce7332e088d",
                LookupName = "Poor",
                LookupType = Lookup.LookupTypes.ItemCondition.ToString()
            };

            public static Lookup ItemCondition_PossiblyBroken = new Lookup
            {
                Id = "05cececd-9719-4a9a-bf51-2e15f31faa5b",
                LookupName = "Possibly Broken",
                LookupType = Lookup.LookupTypes.ItemCondition.ToString()
            };

            public static Lookup ItemCondition_Unknown = new Lookup
            {
                Id = "d07801e2-981b-4163-9dd6-79483ae63628",
                LookupName = "Unknown",
                LookupType = Lookup.LookupTypes.ItemCondition.ToString()
            };

            public static Lookup TemplateType_Hardware = new Lookup
            {
                Id = "ef13987e-7276-4961-9008-bbed538382d5",
                LookupName = "Hardware",
                LookupType = Lookup.LookupTypes.TemplateType.ToString()
            };

            public static Lookup TemplateType_Software = new Lookup
            {
                Id = "02ec251c-d9d7-4438-9a01-c970dee721c4",
                LookupName = "Software",
                LookupType = Lookup.LookupTypes.TemplateType.ToString()
            };
        }

        public class Roles
        {
            public static ApplicationRole Admin
            {
                get
                {
                    return new ApplicationRole()
                    {
                        Id = "6d68a30e-caec-45d4-9df7-126478e0fa04",
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    };
                }
            }

            public static IdentityRole Superviser
            {
                get
                {
                    return new IdentityRole()
                    {
                        Id = "d6b28bd3-fffe-4762-bc37-1a63c6d06780",
                        Name = "Superviser",
                        NormalizedName = "SUPERVISER"
                    };
                }
            }

            public static IdentityRole Tech
            {
                get
                {
                    return new IdentityRole()
                    {
                        Id = "0416334c-8efe-4fb5-ad4f-7fd69744c228",
                        Name = "Tech",
                        NormalizedName = "TECH"
                    };
                }
            }

            public static IdentityRole User
            {
                get
                {
                    return new IdentityRole()
                    {
                        Id = "6b30374c-4005-4021-8e4b-b64e53e68a80",
                        Name = "User",
                        NormalizedName = "USER"
                    };
                }
            }
        }

        public class Vendors
        {
            public static Vendor Vendor_Dell = new Vendor
            {
                Id = "0541cd81-b043-4b65-900c-812dcad5692e",
                City = "Dallas",
                Country = "US",
                CreatedByUserId = AppUser.Kenny.Id,
                Email = "support@dell.com",
                FaxNumber = "866-444-5454",
                IsDeleted = false,
                Notes = "Extension 5310 then press 9",
                Name = "Dell",
                PhoneNumber = "855-393-2299",
                State = "TX",
                Zip = "77618",
                Street1 = "521 West End Blvd",
                Street2 = string.Empty,
                TechSupportNumber = "800-630-2910",
                CreatedOn = new DateTime(2017, 1, 22, 12, 05, 13)
            };
        }
    }
}