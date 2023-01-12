using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Service.Interface.PromotionalProductMaterial;
using PMIS.Utility;
using PMIS.Utility.Static;

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
                Data = (await _service.GetAsync()).OrderBy(e => e.SECTION_CODE).ToList()
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

        [HttpPost]
        public async Task<Result<PRODUCTION_SECTION_INFO>> Post([FromBody] PRODUCTION_SECTION_INFO model)
        {
            var result = new Result<PRODUCTION_SECTION_INFO>();

            if (!ModelState.IsValid)
            {
                result.Success = false;
                result.Message = ResponseMessage.BAD_REQUEST;
                return result;
            }

            try
            {
                if (model.SECTION_ID > 0)
                {
                    await _service.UpdateAsync(model);
                    result.Message = ResponseMessage.SUCCESSFULLY_UPDATED;
                }
                else
                {
                    model.SECTION_CODE = await _service.GetProductionSectionCode();
                    await _service.InsertAsync(model);
                    result.Message = ResponseMessage.SUCCESSFULLY_CREATED;
                }

                result.Data = model;

                return result;
            }
            catch (Exception exp)
            {
                // keep log;
                _logger.Error(exp);
                result.Message = ResponseMessage.Get(exp);
                result.Success = false;
                return result;
            }
        }
    }
}