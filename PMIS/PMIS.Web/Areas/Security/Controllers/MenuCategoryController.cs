using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PMIS.Domain.Entities;
using PMIS.Service.Interface.Security;
using PMIS.Utility.Static;
using PMIS.Web.Common;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace PMIS.Web.Areas.Security.Controllers
{
    [Area("Security")]
    //[Authorize]
    public class MenuCategoryController : Controller
    {
        private readonly IMenuCategoryService _service;
        private readonly ILogger<MenuCategoryController> _logger;
        private readonly IConfiguration _configuration;
        public MenuCategoryController(IMenuCategoryService service, ILogger<MenuCategoryController> logger, IConfiguration configuration)
        {
            _service = service;
            _logger = logger;
            _configuration = configuration;
        }
        private string GetDbConnectionString() => User.Claims.FirstOrDefault(x => x.Type == ClaimsType.DbSpecifier).Value.ToString();

        //[AuthorizeCheck]
        public IActionResult Index()
        {
            _logger.LogInformation("Menu Module (MenuCategory/Index) Page Has been accessed By " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value != null ? User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value.ToString() : "Unknown User" + " ( ID= " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value != null ? User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value.ToString() : "");

            return View();
        }

        [HttpPost]
        public string LoadData([FromBody] COMPANY_INFO company_Info)
        {
            
            int comp_id = company_Info ==null || company_Info.COMPANY_ID == 0?  Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : company_Info.COMPANY_ID;
            return _service.LoadData(comp_id);

        } 
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate([FromBody]MODULE_INFO model)
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
                    if(model.MODULE_ID==0)
                    {
                        model.ENTERED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        model.ENTERED_DATE = DateTime.Now;
                        model.ENTERED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                       
                        model.COMPANY_ID = model.COMPANY_ID ==0 ? Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : model.COMPANY_ID;

                    }
                    else
                    {
                        model.UPDATED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        model.UPDATED_DATE = DateTime.Now;
                        model.UPDATED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
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
           string  result = await _service.ActivateMenuCategory(menuCategory.MODULE_ID);

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
