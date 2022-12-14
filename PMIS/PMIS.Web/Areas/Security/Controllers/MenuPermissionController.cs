using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Domain.ViewModels.Security;
using PMIS.Service.Interface.Security;
using PMIS.Utility.Static;
using PMIS.Web.Common;
using System.Text.Json;

namespace PMIS.Web.Areas.Security.Controllers
{
    [Authorize]
    [Area("Security")]
    public class MenuPermissionController : Controller
    {
        private readonly IMenuPermissionService _service;
        private readonly IUserMenuConfigService _UserMenuConfigservice;
        private readonly IHttpContextAccessor _Accessor;

        private readonly ILogger<MenuPermissionController> _logger;

        public MenuPermissionController(IMenuPermissionService service, ILogger<MenuPermissionController> logger, IUserMenuConfigService UserMenuConfigservice, IHttpContextAccessor Accessor)
        {
            _service = service;
            _logger = logger;
            _UserMenuConfigservice = UserMenuConfigservice;
            _Accessor = Accessor;
        }

        private string GetDbConnectionString() => User.Claims.FirstOrDefault(x => x.Type == ClaimsType.DbSpecifier).Value.ToString();

        private string GetPermissionString() => HttpContext?.Session?.GetString(ClaimsType.RolePermission) != null ? HttpContext?.Session?.GetString(ClaimsType.RolePermission)?.ToString() : null;

        //[AuthorizeCheck]
        public IActionResult Index()
        {
            _logger.LogInformation("Menu Permission(MenuPermission / Index) Page Has been accessed By " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value != null ? User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value.ToString() : "Unknown User" + " ( ID= " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value != null ? User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value.ToString() : "");

            return View();
        }

        [HttpPost]
        public IActionResult GetPermissions([FromBody] UserPermission model)
        {
            if (this.GetPermissionString() != null)
            {
                MenuDistribution distribution = JsonSerializer.Deserialize<MenuDistribution>(this.GetPermissionString());

                if (distribution != null)
                {
                    PermittedMenu permittedMenu = distribution.PermittedMenus
                        .Where(x => x.ACTION == model.Action_Name && x.CONTROLLER == model.Controller_Name)
                        .FirstOrDefault();
                    if (permittedMenu != null)
                    {
                        permittedMenu.USER_TYPE = User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserType)?.Value;
                    }
                    return Json(permittedMenu);
                }
            }

            return Json("");
        }

        public async Task<string> UserMenuConfigSelectionList([FromBody] UserMenuConfigView UserMenuConfigView)
        {
            int comp_id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId)?.Value);
            string result = await _UserMenuConfigservice.UserMenuConfigSelectionList(comp_id, UserMenuConfigView.USER_ID);
            return result;
        }

        public async Task<string> GetSearchableUsers([FromBody] USER_INFO model)
        {
            int comp_id = User.GetComapanyId();
            return await _UserMenuConfigservice.GetSearchableUsers(comp_id, model.USER_NAME);
        }

        public async Task<string> GetSearchableCentralUsers([FromBody] USER_INFO model)
        {
            return await _UserMenuConfigservice.GetSearchableCentralUsers(model.USER_NAME);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRoleMenuConfiguration([FromBody] List<MENU_USER_CONFIGURATION> model)
        {
            string result = "";
            if (model == null)
            {
                result = "No data provided to insert!!!!";
            }
            else
            {
                int comp_id = User.GetComapanyId();
                foreach (var item in model)
                {
                    if (item.ID == 0)
                    {
                        item.ENTERED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        item.ENTERED_DATE = DateTime.Now;
                        item.ENTERED_TERMINAL = HttpContext.Connection.RemoteIpAddress?.ToString();
                        item.COMPANY_ID = comp_id;
                    }
                    else
                    {
                        item.UPDATED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        item.UPDATED_DATE = DateTime.Now;
                        item.UPDATED_TERMINAL = HttpContext.Connection.RemoteIpAddress?.ToString();
                    }
                }
                result = await _UserMenuConfigservice.AddUserMenuConfiguration(model);
            }

            return Json(result);
        }

        public IActionResult GetSidebarMenu()
        {
            var claims = User.Claims.FirstOrDefault(x => x.Type == ClaimsType.RolePermission).Value;

            MenuDistribution menuDistribution = JsonSerializer.Deserialize<MenuDistribution>(claims);

            return PartialView("GetSidebarMenu", menuDistribution);
        }

        [HttpGet]
        public IActionResult GetMenuDistribution()
        {
            var claims = User.Claims.FirstOrDefault(x => x.Type == ClaimsType.RolePermission)?.Value;

            MenuDistribution menuDistribution = JsonSerializer.Deserialize<MenuDistribution>(claims);
            return Json(menuDistribution.PermittedModules);
        }

        [HttpGet]
        public IActionResult GetUserInfo()
        {
            var claims = User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName)?.Value;

            return Json(claims);
        }

        [HttpPost]
        public string SearchableMenuLoad([FromBody] string MENU_NAME)
        {
            string user_id = User.GetUserId();
            string comp_id = User.GetComapanyId().ToString();
            return _service.SearchableMenuLoad(comp_id, user_id, MENU_NAME);
        }

        //--------Menu Holder--------------------------

        [HttpPost]
        public string MenuCookieHolerSet([FromBody] string Value)
        {
            if (Value != null)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(720);

                _Accessor.HttpContext?.Response.Cookies?.Append("MenuHolder", Value, option);
                return "1";
            }
            return "0";
        }

        [HttpPost]
        public string MenuCookieHolerGet([FromBody] string Value)
        {
            string result = "";
            if (_Accessor.HttpContext.Request.Cookies["MenuHolder"] != null)
            {
                result = _Accessor.HttpContext.Request.Cookies["MenuHolder"];
            }

            return result;
        }

        [HttpPost]
        public string NavCookieHolderSet([FromBody] string Value)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(720);
            if (_Accessor.HttpContext?.Request.Cookies["NavCookieHolder"] != null)
            {
                Value = _Accessor.HttpContext.Request.Cookies["NavCookieHolder"];
                Value = Value == "1" ? "0" : "1";
            }
            else
            {
                Value = "1";
            }
            _Accessor.HttpContext.Response.Cookies.Append("NavCookieHolder", Value, option);

            return "1";
        }

        [HttpPost]
        public string NavCookieHolderGet([FromBody] string Value)
        {
            string result = "";
            if (_Accessor.HttpContext.Request.Cookies["NavCookieHolder"] != null)
            {
                result = _Accessor.HttpContext.Request.Cookies["NavCookieHolder"];
            }

            return result;
        }
    }
}