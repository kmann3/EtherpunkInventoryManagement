using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EtherpunkInventoryManagement.Models;
using EtherpunkInventoryManagement.Data;
using Microsoft.AspNetCore.Authorization;


namespace EtherpunkInventoryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly InventoryDbContext _context;

        public HomeController(InventoryDbContext context)
        {
            _context = context;
        }

        [HttpGet("~/AdminDashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminDashboard()
        {
            return View();
        }

        [HttpGet("~/SuperviserDashboard")]
        [Authorize(Roles = "Admin,Superviser")]
        public IActionResult SuperviserDashboard()
        {

            return View();
        }
        [HttpGet("~/TechDashboard")]
        [Authorize(Roles = "Admin,Superviser,Tech")]
        public IActionResult TechDashboard()
        {
            Home_TechDashboardModel returnModel = new Home_TechDashboardModel();
            
            var topRecentlyEnteredItems = (from hi in _context.HardwareInventories
                                           join hiah in _context.HardwareInventoryAssignmentHistories on hi.Id equals hiah.HardwareInventoryId
                                           join hlo in _context.HardwareLayouts on hi.HardwareLayoutId equals hlo.Id
                                           join userTo in _context.ApplicationUsers on hiah.AssignedTo_UserId equals userTo.Id
                                           join userBy in _context.ApplicationUsers on hiah.AssignedBy_UserId equals userBy.Id
                                           where hi.IsDeleted == false
                                           orderby hiah.CreatedOn descending
                                           select new
                                           {
                                               HardwareInventoryId = hi.Id,
                                               HardwareInventoryShortId = hi.ShortId,
                                               HardwareName = hi.Name,
                                               HardwareLayoutId = hlo.Id,
                                               HardwareLayoutName = hlo.Name,
                                               AssignedToId = userTo.Id,
                                               AssignedToFullName = userTo.FullNameFirstFirst,
                                               AssignedById = userBy.Id,
                                               AssignedByFullName = userBy.FullNameFirstFirst,
                                               AssignedOnDate = hiah.CreatedOn
                                           });

            foreach (var item in topRecentlyEnteredItems.Take(6))
            {
                returnModel.RecentlyEnteredHardwareInventories.Add(new Home_TechDashboardModel.RecentlyEnteredHardwareInventory()
                {
                    HardwareInventoryId = item.HardwareInventoryId,
                    HardwareInventoryShortId = item.HardwareInventoryShortId,
                    HardwareInventoryName = item.HardwareName,
                    HardwareLayoutId = item.HardwareLayoutId,
                    HardwareLayoutName = item.HardwareLayoutName,
                    AssignedToId = item.AssignedToId,
                    AssignedToFullName = item.AssignedToFullName,
                    AssignedOnDate = item.AssignedOnDate,
                    AssignedById = item.AssignedById,
                    AssignedByFullName = item.AssignedByFullName
                });
            }

            var topUnvalidatedItems = (from au in _context.HardwareAudits
                                    join inventory in _context.HardwareInventories on au.HardwareInventoryId equals inventory.Id
                                    join assigneduser in _context.ApplicationUsers on au.AssignedUserId equals assigneduser.Id
                                    join auditrolelookup in _context.Lookups on au.AuditPersonRoleLookupId equals auditrolelookup.Id
                                    join assignedowner in _context.ApplicationUsers on inventory.AssignedUserId equals assignedowner.Id
                                    join hardwarelayout in _context.HardwareLayouts on inventory.HardwareLayoutId equals hardwarelayout.Id
                                    orderby au.CreatedOn descending
                                    where au.ActualCompletionDate == null && inventory.IsDeleted == false
                                    select new
                                    {
                                        Audit = au,
                                        AssignedToUser = assigneduser,
                                        AuditRoleLookup = auditrolelookup,
                                        AssignedOwner = assignedowner,
                                        HardwareInventory = inventory,
                                        HardwareLayout = hardwarelayout,
                                        TimeLate = ((TimeSpan)(DateTime.Now - au.ExpectedCompletionDate))
                                    });

            foreach(var item in topUnvalidatedItems.Take(6))
            {
                returnModel.UnvalidatedItems.Add(new Home_TechDashboardModel.UnvalidatedHardwareInventory
                {
                    AssignedUserId = item.AssignedToUser.Id,
                    AssignedUserName = item.AssignedToUser.FullNameFirstFirst,
                    AuditStartDate = item.Audit.CreatedOn,
                    ExpectedCompletionDate = item.Audit.ExpectedCompletionDate,
                    HardwareInventoryId = item.HardwareInventory.Id,
                    HardwareInventoryName = item.HardwareInventory.Name,
                    HardwareInventoryOwnerId = item.AssignedOwner.Id,
                    HardwareInventoryOwnerName = item.AssignedOwner.FullNameFirstFirst,
                    HardwareLayoutId = item.HardwareInventory.HardwareLayoutId,
                    HardwareLayoutName = item.HardwareLayout.Name,
                    HardwareShortId = item.HardwareInventory.ShortId,
                    OverdueLength = item.TimeLate
                });
            }

            var topUserValidatedItems = (from au in _context.HardwareAudits
                                    join inventory in _context.HardwareInventories on au.HardwareInventoryId equals inventory.Id
                                    join assigneduser in _context.ApplicationUsers on au.AssignedUserId equals assigneduser.Id
                                    join auditrolelookup in _context.Lookups on au.AuditPersonRoleLookupId equals auditrolelookup.Id
                                    join assignedowner in _context.ApplicationUsers on inventory.AssignedUserId equals assignedowner.Id
                                    join hardwarelayout in _context.HardwareLayouts on inventory.HardwareLayoutId equals hardwarelayout.Id
                                    join compbyuser in _context.ApplicationUsers on au.CompletedByUserId equals compbyuser.Id
                                    orderby au.CreatedOn descending
                                    where au.ActualCompletionDate != null && auditrolelookup.LookupName == "User" && inventory.IsDeleted == false
                                    select new
                                    {
                                        Audit = au,
                                        AssignedToUser = assigneduser,
                                        AuditRoleLookup = auditrolelookup,
                                        AssignedOwner = assignedowner,
                                        HardwareInventory = inventory,
                                        CompletedByUser = compbyuser,
                                        HardwareLayout = hardwarelayout,
                                        TimeTaken = ((TimeSpan) (au.ActualCompletionDate - au.CreatedOn))
                                    });

            foreach (var item in topUserValidatedItems.Take(6))
            {
                returnModel.UserValidatedItems.Add(new Home_TechDashboardModel.ValidatedHardwareInventory
                {
                    ActualCompletionDate = (DateTime)item.Audit.ActualCompletionDate,
                    AssignedUserId = item.AssignedToUser.Id,
                    AssignedUserName = item.AssignedToUser.FullNameFirstFirst,
                    AuditStartDate = item.Audit.CreatedOn,
                    HardwareInventoryId = item.HardwareInventory.Id,
                    HardwareInventoryName = item.HardwareInventory.Name,
                    HardwareInventoryOwnerId = item.AssignedOwner.Id,
                    HardwareInventoryOwnerName = item.AssignedOwner.FullNameFirstFirst,
                    HardwareLayoutId = item.HardwareInventory.HardwareLayoutId,
                    HardwareLayoutName = item.HardwareLayout.Name,
                    HardwareShortId = item.HardwareInventory.ShortId,
                    TimeTaken = item.TimeTaken
                });
            }

            var topITValidatedItems = (from au in _context.HardwareAudits
                                        join inventory in _context.HardwareInventories on au.HardwareInventoryId equals inventory.Id
                                        join assigneduser in _context.ApplicationUsers on au.AssignedUserId equals assigneduser.Id
                                        join auditrolelookup in _context.Lookups on au.AuditPersonRoleLookupId equals auditrolelookup.Id
                                        join assignedowner in _context.ApplicationUsers on inventory.AssignedUserId equals assignedowner.Id
                                        join hardwarelayout in _context.HardwareLayouts on inventory.HardwareLayoutId equals hardwarelayout.Id
                                        join compbyuser in _context.ApplicationUsers on au.CompletedByUserId equals compbyuser.Id
                                        orderby au.CreatedOn descending
                                        where au.ActualCompletionDate != null && auditrolelookup.LookupName != "User" && inventory.IsDeleted == false
                                        select new
                                        {
                                            Audit = au,
                                            AssignedToUser = assigneduser,
                                            AuditRoleLookup = auditrolelookup,
                                            AssignedOwner = assignedowner,
                                            HardwareInventory = inventory,
                                            CompletedByUser = compbyuser,
                                            HardwareLayout = hardwarelayout,
                                            TimeTaken = ((TimeSpan)(au.ActualCompletionDate - au.CreatedOn))
                                        });

            foreach (var item in topITValidatedItems.Take(6))
            {
                returnModel.ITValidatedItems.Add(new Home_TechDashboardModel.ValidatedHardwareInventory
                {
                    ActualCompletionDate = (DateTime)item.Audit.ActualCompletionDate,
                    AssignedUserId = item.AssignedToUser.Id,
                    AssignedUserName = item.AssignedToUser.FullNameFirstFirst,
                    AuditStartDate = item.Audit.CreatedOn,
                    HardwareInventoryId = item.HardwareInventory.Id,
                    HardwareInventoryName = item.HardwareInventory.Name,
                    HardwareInventoryOwnerId = item.AssignedOwner.Id,
                    HardwareInventoryOwnerName = item.AssignedOwner.FullNameFirstFirst,
                    HardwareLayoutId = item.HardwareInventory.HardwareLayoutId,
                    HardwareLayoutName = item.HardwareLayout.Name,
                    HardwareShortId = item.HardwareInventory.ShortId,
                    TimeTaken = item.TimeTaken
                });
            }

            return View(returnModel);
        }

        [HttpGet("~/UserDashboard")]
        [Authorize(Roles = "Admin,Superviser,Tech,User")]
        public IActionResult UserDashBoard()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
