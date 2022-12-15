using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMIS.Utility.Static;
using PMIS.Web.Common;
using PMIS.Web.Models;
using System.Diagnostics;

namespace PMIS.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private string GetDefaultPage() => User.Claims.FirstOrDefault(x => x.Type == ClaimsType.DefaultPage).Value.ToString();

        //[AuthorizeCheck]
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

        //[AuthorizeCheck]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult PermissionRestricted()
        {
            //ViewData["DefaultPage"] = this.GetDefaultPage();
            return View();
        }
    }
}