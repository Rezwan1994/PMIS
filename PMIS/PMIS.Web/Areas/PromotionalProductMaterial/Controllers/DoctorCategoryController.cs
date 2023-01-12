using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Service.Interface.PromotionalProductMaterial;
using PMIS.Utility;
using PMIS.Utility.Static;

namespace PMIS.Web.Areas.PromotionalProductMaterial.Controllers
{
    [Area("PromotionalProductMaterial")]
    public class DoctorCategoryController : Controller
    {
        private readonly IDoctorCategoryService _service;
        private readonly ILogError _logger;

        public DoctorCategoryController(IDoctorCategoryService service, ILogError logger)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ListResult<DOCTOR_CATEGORY_INFO>> Get()
        {
            var result = new ListResult<DOCTOR_CATEGORY_INFO>()
            {
                Data = (await _service.GetAsync()).OrderBy(e => e.DOCTOR_CATEGORY_CODE).ToList()
            };
            return result;
        }

        [HttpPost]
        public async Task<Result<DOCTOR_CATEGORY_INFO>> Post([FromBody] DOCTOR_CATEGORY_INFO model)
        {
            var result = new Result<DOCTOR_CATEGORY_INFO>();

            if (!ModelState.IsValid)
            {
                result.Success = false;
                result.Message = ResponseMessage.BAD_REQUEST;
                return result;
            }

            try
            {
                if (model.DOCTOR_CATEGORY_ID > 0)
                {
                    await _service.UpdateAsync(model);
                    result.Message = ResponseMessage.SUCCESSFULLY_UPDATED;
                }
                else
                {
                    model.DOCTOR_CATEGORY_CODE = await _service.GetCatCode();
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