using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Utility.Static;
using PMIS.Utility;
using System.Net;
using Microsoft.EntityFrameworkCore;
using PMIS.Service.Interface.PromotionalProductMaterial;
using PMIS.Service.Implementation.PromotionalProductMaterial;

namespace PMIS.Web.Areas.PromotionalProductMaterial.Controllers
{
    [Area("PromotionalProductMaterial")]
    public class ProductionSectionInfoController : Controller
    {

        private readonly IProductionSectionInfoService _service;
        private readonly IUnitInfoService _unitService;
        private readonly ILogError _logger;
        public ProductionSectionInfoController(IProductionSectionInfoService service, IUnitInfoService unitService, ILogError logger, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _logger = logger;
            _unitService = unitService;
        }
        public IActionResult frmProductionSectionInfo()
        {
            return View();
        }



        [HttpGet]
        public async Task<ListResult<PRODUCTION_SECTION_INFO>> GetSectionList()
        {
            var result = new ListResult<PRODUCTION_SECTION_INFO>()
            {
                Data = await _service.GetAsync()
            };
            return result;
        }
        [HttpGet]
        public async Task<ListResult<UNIT_INFO>> GetUnitList()
        {
            var result = new ListResult<UNIT_INFO>()
            {
                Data = await _unitService.GetAsync()
            };
            return result;
        }


    }
}
