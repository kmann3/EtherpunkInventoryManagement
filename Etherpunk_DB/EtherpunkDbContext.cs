using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Database schema and context for LotEK.
/// If you need to rebuild the database then do the following:
/// Open up SSMS and run the following code to remove all the tables (or you can manually delete them).
/// <code>
/// DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR
/// SET @Cursor = CURSOR FAST_FORWARD FOR
/// SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_SCHEMA + '].[' +  tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + '];'
/// FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
/// LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME = rc1.CONSTRAINT_NAME
/// OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql
/// WHILE (@@FETCH_STATUS = 0)
/// BEGIN
/// Exec sp_executesql @Sql
/// FETCH NEXT FROM @Cursor INTO @Sql
/// END
/// CLOSE @Cursor DEALLOCATE @Cursor
/// GO
/// EXEC sp_MSforeachtable 'DROP TABLE ?'
/// GO
/// </code>
/// Then delete the migrations
/// Then run, in Package Manager Console with the default project set to LotEK_DB:
/// add-migration init
/// update-database
/// </summary>
namespace Etherpunk_DB
{
    public class EtherpunkDbContext : IdentityDbContext<IdentityUser>
    {
        public EtherpunkDbContext() { }

        public EtherpunkDbContext(DbContextOptions<EtherpunkDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EtherpunkDb.sqlite3"); // For Sqlite
        }

        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasData(Seeds.AppUser.Admin);
            builder.Entity<ApplicationUser>().HasData(Seeds.AppUser.Kenny);
            builder.Entity<ApplicationUser>().HasData(Seeds.AppUser.Doug);
            builder.Entity<ApplicationUser>().HasData(Seeds.AppUser.Norma);
            builder.Entity<ApplicationUser>().HasData(Seeds.AppUser.Stephanie);

            builder.Entity<IdentityRole>().HasData(Seeds.Roles.Admin);
            builder.Entity<IdentityRole>().HasData(Seeds.Roles.Superviser);
            builder.Entity<IdentityRole>().HasData(Seeds.Roles.Tech);
            builder.Entity<IdentityRole>().HasData(Seeds.Roles.User);

            builder.Entity<ApplicationUserRole>().HasData(Seeds.AppUserRole.AdminAdmin);
            builder.Entity<ApplicationUserRole>().HasData(Seeds.AppUserRole.KennyAdmin);
            builder.Entity<ApplicationUserRole>().HasData(Seeds.AppUserRole.DougSupervisor);
            builder.Entity<ApplicationUserRole>().HasData(Seeds.AppUserRole.NormaTech);
            builder.Entity<ApplicationUserRole>().HasData(Seeds.AppUserRole.StephanieUser);

            builder.Entity<Lookup>().HasData(Seeds.Lookups.AuditPersonRole_Supervisor);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.AuditPersonRole_Tech);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.AuditPersonRole_User);

            builder.Entity<Lookup>().HasData(Seeds.Lookups.BinaryDatatype_Invoice);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.BinaryDatatype_License);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.BinaryDatatype_Picture);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.BinaryDatatype_Other);

            builder.Entity<Lookup>().HasData(Seeds.Lookups.Datatype_CapacityMB);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.Datatype_CapacityGB);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.Datatype_CapacityTB);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.Datatype_Currency);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.Datatype_Integer);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.Datatype_Real);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.Datatype_String);

            builder.Entity<Lookup>().HasData(Seeds.Lookups.DisposalMethod_Destroyed);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.DisposalMethod_Donated);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.DisposalMethod_Sold);

            builder.Entity<Lookup>().HasData(Seeds.Lookups.ItemCondition_New);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.ItemCondition_Good);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.ItemCondition_Poor);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.ItemCondition_PossiblyBroken);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.ItemCondition_Broke);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.ItemCondition_Unknown);

            builder.Entity<Lookup>().HasData(Seeds.Lookups.HardwareLayoutTemplate_GraphicsCard);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.HardwareLayoutTemplate_Make);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.HardwareLayoutTemplate_Memory);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.HardwareLayoutTemplate_Model);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.HardwareLayoutTemplate_Price);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.HardwareLayoutTemplate_Processor);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.HardwareLayoutTemplate_SerialNumber);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.HardwareLayoutTemplate_StorageCapacity);

            builder.Entity<Lookup>().HasData(Seeds.Lookups.TemplateType_Hardware);
            builder.Entity<Lookup>().HasData(Seeds.Lookups.TemplateType_Software);

            builder.Entity<Location>().HasData(Seeds.Locations.Location_Beaumont);

            builder.Entity<Vendor>().HasData(Seeds.Vendors.Vendor_Dell);

            builder.Entity<HardwareLayout>().HasData(Seeds.HardwareLayouts.HardwareLayout_DellXPS150);

            builder.Entity<HardwareLayoutTemplate>().HasData(Seeds.HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Make);
            builder.Entity<HardwareLayoutTemplate>().HasData(Seeds.HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Memory);
            builder.Entity<HardwareLayoutTemplate>().HasData(Seeds.HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Model);
            builder.Entity<HardwareLayoutTemplate>().HasData(Seeds.HardwareLayoutTemplates.HardwareLayoutTemplate_DellXPS_Price);

            builder.Entity<HardwareInventory>().HasData(Seeds.HardwareInventories.HardwareInventory_KennysComputer);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_KennyDellXPS150_Make);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_KennyDellXPS150_Model);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_KennyDellXPS150_Memory);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_KennyDellXPS150_Price);
            builder.Entity<HardwareInventoryAssignmentHistory>().HasData(Seeds.HardwareInventoryAssignmentHistories.HardwareInventoryAssignmentHistory_Kenny);
            builder.Entity<HardwareAttachment>().HasData(Seeds.HardwareAttachments.HardwareAttachment_KennyInvoice);
            builder.Entity<HardwareAudit>().HasData(Seeds.HardwareAudits.HardwareAudit_Kenny);

            builder.Entity<HardwareInventory>().HasData(Seeds.HardwareInventories.HardwareInventory_DougsComputer);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_DougDellXPS150_Make);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_DougDellXPS150_Model);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_DougDellXPS150_Memory);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_DougDellXPS150_Price);
            builder.Entity<HardwareInventoryAssignmentHistory>().HasData(Seeds.HardwareInventoryAssignmentHistories.HardwareInventoryAssignmentHistory_Doug);
            builder.Entity<HardwareAudit>().HasData(Seeds.HardwareAudits.HardwareAudit_Doug);

            builder.Entity<HardwareInventory>().HasData(Seeds.HardwareInventories.HardwareInventory_NormasComputer);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_NormaDellXPS150_Make);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_NormaDellXPS150_Model);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_NormaDellXPS150_Memory);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_NormaDellXPS150_Price);
            builder.Entity<HardwareInventoryAssignmentHistory>().HasData(Seeds.HardwareInventoryAssignmentHistories.HardwareInventoryAssignmentHistory_Norma);
            builder.Entity<HardwareAudit>().HasData(Seeds.HardwareAudits.HardwareAudit_Norma1);
            builder.Entity<HardwareAudit>().HasData(Seeds.HardwareAudits.HardwareAudit_Norma2);

            builder.Entity<HardwareInventory>().HasData(Seeds.HardwareInventories.HardwareInventory_StephaniesComputer);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_StephanieDellXPS150_Make);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_StephanieDellXPS150_Model);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_StephanieDellXPS150_Memory);
            builder.Entity<HardwareAttribute>().HasData(Seeds.HardwareAttributes.HardwareAttributes_StephanieDellXPS150_Price);
            builder.Entity<HardwareInventoryAssignmentHistory>().HasData(Seeds.HardwareInventoryAssignmentHistories.HardwareInventoryAssignmentHistory_Stephanie);
            builder.Entity<HardwareAudit>().HasData(Seeds.HardwareAudits.HardwareAudit_Stephanie);

        }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<HardwareAttachment> HardwareAttachments { get; set; }
        public DbSet<HardwareAttribute> HardwareAttributes { get; set; }
        public DbSet<HardwareAudit> HardwareAudits { get; set; }
        public DbSet<HardwareInventory> HardwareInventories { get; set; }
        public DbSet<HardwareInventoryAssignmentHistory> HardwareInventoryAssignmentHistories { get; set; }
        public DbSet<HardwareLayout> HardwareLayouts { get; set; }
        public DbSet<HardwareLayoutTemplate> HardwareLayoutTemplates { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Lookup> Lookups { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

    }

    public partial class ApplicationRole : IdentityRole<string>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }

    /// <summary>
    /// Note: https://stackoverflow.com/questions/22652118/disable-user-in-aspnet-identity-2-0
    /// </summary>
    public partial class ApplicationUser : IdentityUser
    {
        public string ActiveDirectoryGuid { get; set; } // How to exclude id?
        public string ActiveDirectoryUserName { get; set; } // Used for authenticating
        public virtual ApplicationUser CreatedByUser { get; set; }
        public string CreatedByUserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string FirstName { get; set; }

        public string FullNameFirstFirst
        {
            get
            {
                return this.FirstName + " " + this.FirstName;
            }
        }

        public string FullNameLastFirst
        {
            get
            {
                return this.LastName + ", " + this.FirstName;
            }
        }

        [Key]
        public override string Id { get => base.Id; set => base.Id = value; }

        /// <summary>
        /// Users are NEVER deleted because they can reference data and deleting them would orphan that data.
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        public bool IsDisabled { get; set; } = false;
        public string LastName { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }

    public partial class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUserRole() : base() { }

    }

    public class HardwareAttachment
    {
        public byte[] AttachmentData { get; set; }
        public string AttachmentFileName { get; set; }
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AttachmentName { get; set; }
        public virtual Lookup AttachmentType { get; set; }
        public string AttachmentTypeId { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        public string CreatedByUserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public virtual HardwareInventory HardwareInventory { get; set; }
        public string HardwareInventoryId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    public class HardwareAudit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? ActualCompletionDate { get; set; }

        public virtual ApplicationUser AssignedUser { get; set; }
        public string AssignedUserId { get; set; }
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public virtual Lookup AuditPersonRoleLookup { get; set; }
        public string AuditPersonRoleLookupId { get; set; }

        public virtual ApplicationUser CompletedByUser { get; set; }
        public string CompletedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public string CreatedByUserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime ExpectedCompletionDate { get; set; }

        public virtual HardwareInventory HardwareInventory { get; set; }
        public string HardwareInventoryId { get; set; }

        public string Notes { get; set; }
    }

    public class HardwareInventory
    {
        public virtual ApplicationUser AssignedUser { get; set; }
        public string AssignedUserId { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        public string CreatedByUserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? DatePurchased { get; set; }
        public virtual Lookup DisposedLookup { get; set; }
        public string DisposedLookupId { get; set; }

        /// <summary>
        /// Expected date to replace. Null means no replacement date.
        /// </summary>
        public DateTime? FutureReplacementDate { get; set; }
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public virtual ICollection<HardwareAttachment> Attachments { get; set; }
        public string HardwareLayoutId { get; set; }
        public virtual HardwareLayout HardwareLayout { get; set; }

        /// <summary>
        /// Soft deletes are used to prevent orphaning historical records.
        /// </summary>
        public bool IsDeleted { get; set; } = false;
        public virtual Lookup ItemCondition { get; set; }
        public string ItemConditionLookupId { get; set; }
        //public virtual Location Location { get; set; }
        /// <summary>
        /// Used to denote specifics of a location. Whereas the locationId may link to "Beaumont" the details would be "Server clset 403, corner of room".
        /// </summary>
        public string LocationDetails { get; set; }
        public string LocationId { get; set; }
        // Example: Storage Closet in IT room
        public string Name { get; set; }

        public string Notes { get; set; }
        public string ShortId { get; set; } = EtherpunkUtilCore.Misc.GenerateNewUId("EI-", 9);
        public virtual ICollection<HardwareAttribute> HardwareAttributes { get; set; }
        public virtual Vendor Vendor { get; set; }

        public string VendorId { get; set; }

        public DateTime? WarrantyExpiration { get; set; }

        public string WarrantyNotes { get; set; }
    }

    public class HardwareInventoryAssignmentHistory
    {
        public virtual ApplicationUser AssignedBy_User { get; set; }
        public string AssignedBy_UserId { get; set; }

        public virtual ApplicationUser AssignedTo_User { get; set; }
        public string AssignedTo_UserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public string CreatedByUserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public virtual HardwareInventory HardwareInventory { get; set; }
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string HardwareInventoryId { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

    public class HardwareLayout
    {
        public virtual ApplicationUser CreatedByUser { get; set; }
        public string CreatedByUserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsDelete { get; set; } = false;
        public string Name { get; set; }
        public string Notes { get; set; }
    }

    public class HardwareLayoutTemplate
    {
        public virtual ApplicationUser CreatedByUser { get; set; }
        public string CreatedByUserId { get; set; }
        /// <summary>
        /// Example: Links to Gigabyte Lookup
        /// </summary>
        public string Datatype_LookupId { get; set; }
        public virtual Lookup DataType_Lookup { get; set; }
        public virtual HardwareLayout HardwareLayout { get; set; }
        /// <summary>
        /// Example: Links to Dell XPS as part of its group.
        /// </summary>
        public string HardwareLayoutId { get; set; }
        /// <summary>
        /// Example: Links to Memory Lookup
        /// </summary>
        public string HardwareLayoutTemplate_TypeLookupId { get; set; }
        public virtual Lookup HardwareLayoutTemplate_Lookup { get; set; }
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// Example: 2 -> Second in list.
        /// </summary>
        public int OrderIndex { get; set; }
        /// <summary>
        /// Example: 8 (8 -> applied datatype GB -> 8GB)
        /// </summary>
        public string PropertyValue { get; set; }
    }

    public class HardwareAttribute
    {

        public virtual ApplicationUser CreatedByUser { get; set; }
        public string CreatedByUserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public virtual HardwareInventory HardwareInventory { get; set; }
        public string HardwareInventoryId { get; set; }

        public string HardwareLayoutTemplateId { get; set; }
        public virtual HardwareLayoutTemplate HardwareLayoutTemplate { get; set; }
        public string Notes { get; set; }
    }
    public class Location
    {
        public string Abbreviation { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        public string CreatedByUserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string FaxNumber { get; set; }
        public virtual ICollection<HardwareInventory> HardwareInventories { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string LocationName { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Zip { get; set; }
        // Not to be formatted in the database. Getting the property should format it?
    }

    public class Lookup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string LookupName { get; set; }
        public string LookupType { get; set; }

        public enum LookupTypes
        {
            AuditPersonRole,
            BinaryDatatype,
            Datatype,
            DisposalMethod,
            ItemCondition,
            HardwareTemplateLayout,
            InventoryTemplateLayout,
            TemplateType
        }
    }

    public class Vendor
    {
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        public string CreatedByUserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string Email { get; set; }
        public string FaxNumber { get; set; }
        public virtual ICollection<HardwareInventory> HardwareInventories { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; }
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string TechSupportNumber { get; set; }
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Zip { get; set; }
    }
}