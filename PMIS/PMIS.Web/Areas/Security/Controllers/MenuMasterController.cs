using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Service.Interface.Security;
using PMIS.Utility.Static;
using PMIS.Web.Common;

namespace PMIS.Web.Areas.Security.Controllers
{
    [Area("Security")]
    [Authorize]
    public class MenuMasterController : Controller
    {
        private readonly IMenuMasterService _service;
        private readonly ILogger<MenuMasterController> _logger;

        public MenuMasterController(IMenuMasterService service, ILogger<MenuMasterController> logger)
        {
            _service = service;
            _logger = logger;
        }

        //[AuthorizeCheck]
        public IActionResult Index()
        {
            _logger.LogInformation("Menu Module (MenuMaster/Index) Page Has been accessed By " + User.GetUserName() != null ? User.GetUserName() : "Unknown User" + " ( ID= " + User.GetUserId() != null ? User.GetUserId() : "");

            return View();
        }

        [HttpPost]
        public string LoadData([FromBody] COMPANY_INFO company_Info)
        {
            int comp_id = company_Info == null || company_Info.COMPANY_ID == 0 ? User.GetComapanyId() : company_Info.COMPANY_ID;
            return _service.LoadData(comp_id);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate([FromBody] MENU_CONFIGURATION model)
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
                    if (model.MENU_ID == 0)
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
        public async Task<IActionResult> ActivateMenu([FromBody] MENU_CONFIGURATION menuCategory)
        {
            string result = await _service.ActivateMenu(menuCategory.MENU_ID);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeactivateMenu([FromBody] MENU_CONFIGURATION menuCategory)
        {
            string result = await _service.DeactivateMenu(menuCategory.MENU_ID);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] MENU_CONFIGURATION menuCategory)
        {
            string result = await _service.DeleteMenu(menuCategory.MENU_ID);

            return Json(result);
        }
    }
}