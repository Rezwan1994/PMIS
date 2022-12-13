using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Domain.ViewModels.Security;
using PMIS.Service.Interface.Security;
using PMIS.Utility.Static;
using PMIS.Web.Common;

namespace PMIS.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class RoleController : Controller
    {
        private readonly IRoleManager _service;
        private readonly ILogger<RoleController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUserManager _serviceUser;

        public RoleController(IRoleManager service, ILogger<RoleController> logger, IConfiguration configuration, IUserManager serviceUser)
        {
            _service = service;
            _logger = logger;
            _configuration = configuration;
            _serviceUser = serviceUser;
        }

        [AuthorizeCheck]
        public IActionResult Index()
        {
            _logger.LogInformation("Role Config(Role/Index)  Page Has been accessed By " + User.GetUserName() + " (ID= " + User.GetUserId() + ")");

            return View();
        }

        [AuthorizeCheck]
        public IActionResult RoleMenuConfig()
        {
            _logger.LogInformation("Role Menu Config(Role/RoleMenuConfig) Page Has been accessed By " + User.GetUserName() + " (ID= " + User.GetUserId() + ")");

            return View();
        }

        [AuthorizeCheck]
        public IActionResult RoleUserConfig()
        {
            _logger.LogInformation("Role User Config(Role/RoleUserConfig)  Page Has been accessed By " + User.GetUserName() + " (ID= " + User.GetUserId() + ")");

            return View();
        }

        [AuthorizeCheck]
        public IActionResult CentralRoleUserConfig()
        {
            _logger.LogInformation("CentralRole User Config(Role/CentralRoleUserConfig) Page Has been accessed By " + User.GetUserName() + " (ID= " + User.GetUserId() + ")");
            return View();
        }

        [HttpPost]
        public string LoadData([FromBody] COMPANY_INFO company_Info)
        {
            int comp_id = company_Info == null || company_Info.COMPANY_ID == 0 ? Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : company_Info.COMPANY_ID;
            return _service.LoadData(comp_id);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate([FromBody] ROLE_INFO model)
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
                    if (model.ROLE_ID == 0)
                    {
                        model.ENTERED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        model.ENTERED_DATE = DateTime.Now;
                        model.ENTERED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                        model.COMPANY_ID = model.COMPANY_ID == 0 ? Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : model.COMPANY_ID;
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
        public async Task<IActionResult> ActivateRole([FromBody] ROLE_INFO role_Info)
        {
            string result = await _service.ActivateRole(role_Info.ROLE_ID);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeactivateRole([FromBody] ROLE_INFO role_Info)
        {
            string result = await _service.DeactivateRole(role_Info.ROLE_ID);

            return Json(result);
        }

        //-------------------------------------Role Menu Confiq -------------------------------------------------------------------------------
        public async Task<string> RoleMenuConfigSelectionList([FromBody] RoleMenuConfigView roleMenuConfigView)
        {
            int comp_id = roleMenuConfigView.COMPANY_ID == 0 ? Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : roleMenuConfigView.COMPANY_ID;
            string result = await _service.RoleMenuConfigSelectionList(comp_id, roleMenuConfigView.ROLE_ID);
            return result;
        }

        public async Task<string> GetSearchableRoles([FromBody] ROLE_INFO model)
        {
            int comp_id = User.GetComapanyId();
            return await _service.GetSearchableRoles(comp_id, model.ROLE_NAME);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRoleMenuConfiguration([FromBody] List<ROLE_MENU_CONFIGURATION> model)
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
                        item.ENTERED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                        item.COMPANY_ID = User.GetComapanyId();
                    }
                    else
                    {
                        item.UPDATED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        item.UPDATED_DATE = DateTime.Now;
                        item.UPDATED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                    }
                }
                result = await _service.AddRoleMenuConfiguration(model);
            }

            return Json(result);
        }

        //------------------------------Role User Config ----------------------------------------------------------------------
        public async Task<string> RoleUserConfigSelectionList([FromBody] ROLE_USER_CONFIGURATION roleUserConfigView)
        {
            int comp_id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value);
            string result = await _service.RoleUserConfigSelectionList(comp_id, roleUserConfigView.USER_ID);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> SaveRoleUserConfiguration([FromBody] List<ROLE_USER_CONFIGURATION> model)
        {
            string result = "";
            if (model == null)
            {
                result = "No data provided to insert!!!!";
            }
            else
            {
                int comp_id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value);
                foreach (var item in model)
                {
                    item.ENTERED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                    item.ENTERED_DATE = DateTime.Now;
                    item.ENTERED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                    item.COMPANY_ID = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value);
                    item.PERMITTED_BY = item.ENTERED_BY;
                    item.PERMITE_DATE = item.ENTERED_DATE;
                }
                result = await _service.AddRoleUserConfiguration(model);
            }

            return Json(result);
        }

        //-----------------------Central Roll User Config -------------------------------------

        public async Task<string> RoleCentralUserConfigSelectionList([FromBody] ROLE_USER_CONFIGURATION roleUserConfigView)
        {
            string result = await _service.RoleCentralUserConfigSelectionList(roleUserConfigView.USER_ID);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> SaveCentralRoleUserConfiguration([FromBody] List<ROLE_USER_CONFIGURATION> model)
        {
            string result = "";
            if (model == null)
            {
                result = "No data provided to insert!!!!";
            }
            else
            {
                int comp_id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value);
                foreach (var item in model)
                {
                    item.ENTERED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                    item.ENTERED_DATE = DateTime.Now;
                    item.ENTERED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                    item.COMPANY_ID = _serviceUser.GetCompanyIdByUserId(item.USER_ID);
                    item.PERMITTED_BY = item.ENTERED_BY;
                    item.PERMITE_DATE = item.ENTERED_DATE;
                }
                result = await _service.AddRoleUserConfiguration(model);
            }

            return Json(result);
        }
    }
}