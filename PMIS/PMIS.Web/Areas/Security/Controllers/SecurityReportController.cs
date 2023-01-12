using Microsoft.AspNetCore.Mvc;

namespace PMIS.Web.Areas.Security.Controllers
{
    public class SecurityReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
