using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Utility.Static;
using PMIS.Utility;
using System.Net;
using PMIS.Service.Interface.PromotionalProductMaterial;
using Microsoft.EntityFrameworkCore;

namespace PMIS.Web.Areas.PromotionalProductMaterial.Controllers
{
    [Area("PromotionalProductMaterial")]

    public class PMInfoController : Controller
    {
        private readonly IPMInfoService _service;
        private readonly ILogError _logger;

        public PMInfoController(IPMInfoService service, ILogError logger, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ListResult<PROMOTIONAL_MATERIAL_INFO>> Get()
        {
            var result = new ListResult<PROMOTIONAL_MATERIAL_INFO>()
            {
                Data = await _service.GetAsync()
            };
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Result<PROMOTIONAL_MATERIAL_INFO>> Get(int id)
        {
            var result = new Result<PROMOTIONAL_MATERIAL_INFO>();
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
        public async Task<Result<PROMOTIONAL_MATERIAL_INFO>> Post([FromBody] PROMOTIONAL_MATERIAL_INFO model)
        {
            var result = new Result<PROMOTIONAL_MATERIAL_INFO>();

            if (!ModelState.IsValid)
            {
                result.Success = false;
                result.Message = ResponseMessage.BAD_REQUEST;
                return result;
            }

            try
            {
                if (model.PM_ID > 0)
                {
                    await _service.UpdateAsync(model);
                    result.Message = ResponseMessage.SUCCESSFULLY_UPDATED;
                }
                else
                {
                    if(model.PM_CATEGORY_CODE != "PMC001")
                    {
                        model.PM_CODE = await _service.GetPMCode();
                    }
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
        [Route("/PromotionalProductMaterial/PMInfo/Delete/{id}")]
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            try
            {
                var item = await _service.FindAsync(id);

                if (item == null)
                {
                    result.Success = false;
                    result.Message = ResponseMessage.NOT_FOUND;
                    return result;
                }


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
