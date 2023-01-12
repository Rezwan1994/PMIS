using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Service.Interface.PromotionalProductMaterial;
using PMIS.Utility;
using PMIS.Utility.Static;

namespace PMIS.Web.Areas.PromotionalProductMaterial.Controllers
{
    [Area("PromotionalProductMaterial")]
    public class ReturnCauseController : Controller
    {
        private readonly IReturnCauseService _service;
        private readonly ILogError _logger;
        public ReturnCauseController(IReturnCauseService service, ILogError logger)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<ListResult<RETURN_CAUSE_INFO>> Get()
        {
            var result = new ListResult<RETURN_CAUSE_INFO>()
            {
                Data = (await _service.GetAsync()).OrderBy(e => e.RETURN_CAUSE_CODE).ToList()
            };
            return result;
        }

        [HttpPost]
        public async Task<Result<RETURN_CAUSE_INFO>> Post([FromBody] RETURN_CAUSE_INFO model)
        {
            var result = new Result<RETURN_CAUSE_INFO>();

            if (!ModelState.IsValid)
            {
                result.Success = false;
                result.Message = ResponseMessage.BAD_REQUEST;
                return result;
            }

            try
            {
                if (model.RETURN_CAUSE_ID > 0)
                {
                    await _service.UpdateAsync(model);
                    result.Message = ResponseMessage.SUCCESSFULLY_UPDATED;
                }
                else
                {
                    model.RETURN_CAUSE_CODE = await _service.GetCode();
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
