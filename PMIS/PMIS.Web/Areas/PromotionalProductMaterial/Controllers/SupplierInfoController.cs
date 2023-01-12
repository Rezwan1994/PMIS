using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Service.Interface;
using PMIS.Service.Interface.PromotionalProductMaterial;
using PMIS.Utility;
using PMIS.Utility.Static;
using System.Net;

namespace PMIS.Web.Areas.PromotionalProductMaterial.Controllers
{
    [Area("PromotionalProductMaterial")]
    public class SupplierInfoController : Controller
    {
        private readonly ISupplierInfoService _service;
        private readonly ILogError _logger;

        public SupplierInfoController(ISupplierInfoService service, ILogError logger)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ListResult<SUPPLIER_INFO>> Get()
        {
            var result = new ListResult<SUPPLIER_INFO>()
            {
                Data = (await _service.GetAsync()).OrderBy(e => e.SUPPLIER_CODE).ToList()
            };
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Result<SUPPLIER_INFO>> Get(int id)
        {
            var result = new Result<SUPPLIER_INFO>();
            var item = await _service.FindAsync(id);
            if (item == null)
            {
                result.StatusCode = HttpStatusCode.NotFound;
                result.Message = ResponseMessage.NOT_FOUND;
            }
            result.Data = item;
            return result;
        }

        [HttpPost]
        public async Task<Result<SUPPLIER_INFO>> Post([FromBody] SUPPLIER_INFO model)
        {
            var result = new Result<SUPPLIER_INFO>();

            if (!ModelState.IsValid)
            {
                result.Success = false;
                result.Message = ResponseMessage.BAD_REQUEST;
                return result;
            }

            try
            {
                if (model.SUPPLIER_ID > 0)
                {
                    await _service.UpdateAsync(model);
                    result.Message = ResponseMessage.SUCCESSFULLY_UPDATED;
                }
                else
                {
                    model.SUPPLIER_CODE = await _service.GetSupplierCode();
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

        [HttpDelete("{id}")]
        [Route("/PromotionalProductMaterial/DoctorCategory/Delete/{id}")]
        public async Task<Result> Delete(int id)
        {
            var result = new Result();

            var item = await _service.FindAsync(id);
            if (item == null)
            {
                result.Success = false;
                result.Message = ResponseMessage.NOT_FOUND;
                return result;
            }

            try
            {
                await _service.DeleteAsync(item);
                result.Message = ResponseMessage.SUCCESSFULLY_DELETED;
                return result;
            }
            catch (Exception exp)
            {
                // keep log
                _logger.Error(exp);
                result.Message = ResponseMessage.Get(exp);
                result.Success = false;

                return result;
            }
        }

    }
}
