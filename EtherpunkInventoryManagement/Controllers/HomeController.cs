using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EtherpunkInventoryManagement.Models;
using EtherpunkInventoryManagement.Data;
using Microsoft.AspNetCore.Mvc;
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
            /*CREATE VIEW[V_RecentlyEnteredItem]
AS
    SELECT Inventories.InventoryId, Inventories.ShortId, InventoryTemplates.InventoryTemplateId, InventoryTemplates.Name AS InventoryTemplateName,  
    Inventories.Name AS InventoryName, AssignedTo.Id AS AssignedToUserId, AssignedTo.FirstName As AssignedToUsernameFirstName,
        AssignedTo.LastName AS AssignedToUsernameLastName, AssignedBy.Id AS AssignedByUserId, AssignedBy.FirstName As AssignedByUsernameFirstName, AssignedBy.LastName AS AssignedByUsernameLastName, InventoryAssignmentHistories.CreatedOn AS AssignedToDate
    FROM Inventories
        INNER JOIN InventoryAssignmentHistories ON InventoryAssignmentHistories.InventoryId = Inventories.InventoryId
        INNER JOIN InventoryTemplates ON InventoryTemplates.InventoryTemplateId = Inventories.InventoryTemplateId
        INNER JOIN AspNetUsers AssignedTo ON AssignedTo.Id = InventoryAssignmentHistories.AssignedTo_UserId
        INNER JOIN AspNetUsers AssignedBy ON AssignedBy.Id = InventoryAssignmentHistories.AssignedBy_UserId
    WHERE Inventories.IsDeleted = 0*/
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

            foreach (var item in topRecentlyEnteredItems.Take(5))
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

            var unvalidatedItems = (from au in _context.HardwareAudits
                                    join inventory in _context.HardwareInventories on au.HardwareInventoryId equals inventory.Id
                                    join assigneduser in _context.ApplicationUsers on au.AssignedUserId equals assigneduser.Id
                                    join auditrolelookup in _context.Lookups on au.AuditPersonRoleLookupId equals auditrolelookup.Id
                                    join assignedowner in _context.ApplicationUsers on inventory.AssignedUserId equals assignedowner.Id
                                    join compbyuserp1 in _context.ApplicationUsers on au.CompletedByUserId equals compbyuserp1.Id into compbyuserp2
                                    from compbyuser in compbyuserp2.DefaultIfEmpty()
                                    orderby au.CreatedOn descending
                                    where au.ActualCompletionDate == null && inventory.IsDeleted == false
                                    select new
                                    {
                                        Audit = au,
                                        AssignedToUser = assigneduser,
                                        AuditRoleLookup = auditrolelookup,
                                        AssignedOwner = assignedowner,
                                        HardwareInventory = inventory,
                                        CompletedByUser = compbyuser
                                    });

            foreach(var item in unvalidatedItems.Take(6))
            {
                returnModel.UnvalidatedItems.Add(new Home_TechDashboardModel.UnvalidatedHardwareInventory
                {
                    AssignedUserId = item.AssignedToUser.Id,
                    AssignedUserName = item.AssignedToUser.FullNameFirstFirst,
                    AuditStartDate = item.Audit.CreatedOn,
                    ExpectedCompletionDate = item.Audit.ExpectedCompletionDate
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
