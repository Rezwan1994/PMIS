using Microsoft.AspNetCore.Mvc;
using PMIS.Service.Interface.Security;
using SalesAndDistributionSystem.Areas.Security.User.Controllers;

namespace PMIS.Web.Areas.ProductPromotionalMaterial.Controllers
{
    public class CategoryInfoController : Controller
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CategoryInfoController(IUserService service, ILogger<UserController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
