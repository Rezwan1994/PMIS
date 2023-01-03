using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Service.Interface.Security;
using PMIS.Utility.Static;
using PMIS.Web.Common;

namespace PMIS.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class MenuCategoryController : Controller
    {
        private readonly IMenuCategoryService _service;
        private readonly ILogger<MenuCategoryController> _logger;

        public MenuCategoryController(IMenuCategoryService service, ILogger<MenuCategoryController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [AuthorizeCheck]
        public IActionResult Index()
        {
            _logger.LogInformation("Menu Module (MenuCategory/Index) Page Has been accessed By " + User.GetUserName() != null ? User.GetUserName() : "Unknown User" + " ( ID= " + User.GetUserId() != null ? User.GetUserId() : "");

            return View();
        }

        [HttpPost]
        public string LoadData([FromBody] COMPANY_INFO company_Info)
        {
            int comp_id = User.GetComapanyId();
            return _service.LoadData(comp_id);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate([FromBody] MODULE_INFO model)
        {
            string result = "";

            if (model == null)
            {
                result = "No Changes Found!";
            }
            else
            {
                try
                {
                    if (model.MODULE_ID == 0)
                    {
                        model.ENTERED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        model.ENTERED_DATE = DateTime.Now;
                        model.ENTERED_TERMINAL = HttpContext.Connection.RemoteIpAddress?.ToString();

                        model.COMPANY_ID = model.COMPANY_ID == 0 ? User.GetComapanyId() : model.COMPANY_ID;
                    }
                    else
                    {
                        model.UPDATED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        model.UPDATED_DATE = DateTime.Now;
                        model.UPDATED_TERMINAL = HttpContext.Connection.RemoteIpAddress?.ToString();
                    }

                    result = await _service.AddOrUpdate(model);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> ActivateMenuCategory([FromBody] MODULE_INFO menuCategory)
        {
            string result = await _service.ActivateMenuCategory(menuCategory.MODULE_ID);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> DectivateMenuCategory([FromBody] MODULE_INFO menuCategory)
        {
            string result = await _service.DeactivateMenuCategory(menuCategory.MODULE_ID);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] MODULE_INFO menuCategory)
        {
            string result = await _service.DeleteMenuCategory(menuCategory.MODULE_ID);

            return Json(result);
        }
    }
}