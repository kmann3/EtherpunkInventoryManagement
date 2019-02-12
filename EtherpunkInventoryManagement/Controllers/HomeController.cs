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
            Models.Home_TechDashboardModel returnModel = new Home_TechDashboardModel();
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
