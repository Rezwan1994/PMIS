using Microsoft.AspNetCore.Mvc;
using PMIS.Service.Interface.PromotionalProductMaterial;
using PMIS.Service.Interface.Security;
using SalesAndDistributionSystem.Areas.Security.User.Controllers;

namespace PMIS.Web.Areas.PromotionalProductMaterial.Controllers
{
    [Area("PromotionalProductMaterial")]
    public class CategoryInfoController : Controller
    {
        private readonly ICategoryInfoService _service;
        private readonly ILogger<CategoryInfoController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CategoryInfoController(ICategoryInfoService service, ILogger<CategoryInfoController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult CategoryInfo()
        {
            return View();
        }
    }
}
