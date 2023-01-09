using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Service.Interface.PromotionalProductMaterial;
using PMIS.Utility;
using PMIS.Utility.Static;
using System.Net;

namespace PMIS.Web.Areas.PromotionalProductMaterial.Controllers
{
  
    [Area("PromotionalProductMaterial")]
    public class CategoryInfoController : Controller
    {
        private readonly ICategoryInfoService _service;
        private readonly ILogError _logger;

        public CategoryInfoController(ICategoryInfoService service, ILogError logger, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ListResult<PM_CATEGORY_INFO>> Get()
        {
            var result = new ListResult<PM_CATEGORY_INFO>()
            {
                Data = await _service.GetAsync()
            };
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Result<PM_CATEGORY_INFO>> Get(int id)
        {
            var result = new Result<PM_CATEGORY_INFO>();
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
        public async Task<Result<PM_CATEGORY_INFO>> Post(PM_CATEGORY_INFO model)
        {
            var result = new Result<PM_CATEGORY_INFO>();

            if (!ModelState.IsValid)
            {
                result.Success = false;
                result.Message = ResponseMessage.BAD_REQUEST;
                return result;
            }

            try
            {
                await _service.InsertAsync(model);
                result.Data = model;
                result.Message = ResponseMessage.SUCCESSFULLY_CREATED;
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

        [HttpPut("{id}")]
        public async Task<Result<PM_CATEGORY_INFO>> Put(int id, PM_CATEGORY_INFO model)
        {
            var result = new Result<PM_CATEGORY_INFO>();

            if (id != model.PM_CATEGORY_ID || !ModelState.IsValid)
            {
                result.Success = false;
                result.Message = ResponseMessage.BAD_REQUEST;
                return result;
            }
            try
            {
                await _service.UpdateAsync(model);
                result.Data = model;
                result.Message = ResponseMessage.SUCCESSFULLY_UPDATED;
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

        [HttpDelete("{id}")]
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
