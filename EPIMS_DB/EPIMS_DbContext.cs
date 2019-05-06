using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using EtherpunkUtilCore;

namespace EPIMS_DB
{
    public class EPIMS_DbContext : IdentityDbContext<IdentityUser>
    {
        public EPIMS_DbContext(DbContextOptions<EPIMS_DbContext> options) : base(options) { }

        public EPIMS_DbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EtherpunkDb.sqlite3"); // For Sqlite
        }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }

    public partial class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        public ApplicationRole()
        {

        }

        public static Guid GetRoleId(Role role)
        {
            switch (role)
            {
                case Role.Admin:
                    using (EPIMS_DbContext _context = new EPIMS_DbContext())
                    {
                        return Guid.Parse((from b in _context.ApplicationRoles where b.Name == "Admin" select b.Id).Single());
                    }
                case Role.User:
                    using (EPIMS_DbContext _context = new EPIMS_DbContext())
                    {
                        return Guid.Parse((from b in _context.ApplicationRoles where b.Name == "User" select b.Id).Single());
                    }
                default:
                    throw new NotImplementedException("Unknown role: " + role.ToString());
            }
        }

        public enum Role
        {
            Admin,
            User
        }
    }

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
                return this.FirstName + " " + this.LastName;
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

        public static bool IsUserInGroup(Guid userId, ApplicationRole.Role role)
        {
            using (EPIMS_DbContext _context = new EPIMS_DbContext())
            {
                Guid roleId = ApplicationRole.GetRoleId(role);
                var link = (from a in _context.ApplicationUserRoles where a.RoleId == roleId.ToString() && a.UserId == userId.ToString() select a).FirstOrDefault();

                if (link == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }

    public partial class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationUserRole() : base() { }

    }
}
