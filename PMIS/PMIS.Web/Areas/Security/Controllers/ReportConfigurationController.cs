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
    [Authorize]
    public class ReportConfigurationController : Controller
    {
        private readonly IReportConfigurationService _service;
        private readonly ILogger<ReportConfigurationController> _logger;

        public ReportConfigurationController(IReportConfigurationService service, ILogger<ReportConfigurationController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [AuthorizeCheck]
        public IActionResult Index()
        {
            _logger.LogInformation("Report Module (ReportConfiguration/Index) Page Has been accessed By " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value.ToString() + " ( ID= " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value.ToString());

            return View();
        }

        [AuthorizeCheck]
        public IActionResult RoleReportConfig()
        {
            _logger.LogInformation("Report Module (ReportConfiguration/RoleReportConfig) Page Has been accessed By " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value.ToString() + " ( ID= " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value.ToString());

            return View();
        }

        public IActionResult UserReportConfig()
        {
            _logger.LogInformation("Report Module (ReportConfiguration/RoleReportConfig) Page Has been accessed By " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value.ToString() + " ( ID= " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value.ToString());

            return View();
        }

        [HttpPost]
        public async Task<string> LoadData([FromBody] COMPANY_INFO company_Info)
        {
            int comp_id = company_Info == null || company_Info.COMPANY_ID == 0 ? Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : company_Info.COMPANY_ID;
            return await _service.LoadData(comp_id);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate([FromBody] REPORT_CONFIGURATION model)
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
                    if (model.REPORT_ID == 0)
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
        public async Task<IActionResult> ActivateReport([FromBody] REPORT_CONFIGURATION reportConfiguration)
        {
            string result = await _service.ActivateReport(reportConfiguration.REPORT_ID);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeactivateReport([FromBody] REPORT_CONFIGURATION reportConfiguration)
        {
            string result = await _service.DeactivateReport(reportConfiguration.REPORT_ID);

            return Json(result);
        }

        //Role Report Configuration -------------------------------------------------------------------
        public async Task<string> RoleReportConfigSelectionList([FromBody] RoleReportConfigView roleMenuConfigView)
        {
            int comp_id = roleMenuConfigView.COMPANY_ID == 0 ? Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : roleMenuConfigView.COMPANY_ID;
            string result = await _service.RoleReportConfigSelectionList(comp_id, roleMenuConfigView.ROLE_ID);
            return result;
        }

        public async Task<string> GetSearchableRoles([FromBody] ROLE_INFO model)
        {
            int comp_id = User.GetComapanyId();
            return await _service.GetSearchableRoles(comp_id, model.ROLE_NAME);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRoleReportConfiguration([FromBody] List<ROLE_REPORT_CONFIGURATION> model)
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
                        item.COMPANY_ID = item.COMPANY_ID == 0 ? Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : item.COMPANY_ID;
                    }
                    else
                    {
                        item.UPDATED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        item.UPDATED_DATE = DateTime.Now;
                        item.UPDATED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                    }
                }
                result = await _service.AddRoleReportConfiguration(model);
            }

            return Json(result);
        }

        //Report User Configurationb----------------------------------------------------

        public async Task<string> UserReportConfigSelectionList([FromBody] UserReportConfigView UserMenuConfigView)
        {
            int comp_id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value);
            string result = await _service.UserReportConfigSelectionList(comp_id, UserMenuConfigView.USER_ID);
            return result;
        }

        public async Task<string> GetSearchableUsers([FromBody] USER_INFO model)
        {
            int comp_id = User.GetComapanyId();
            return await _service.GetSearchableUsers(comp_id, model.USER_NAME);
        }

        public async Task<string> GetSearchableCentralUsers([FromBody] USER_INFO model)
        {
            return await _service.GetSearchableCentralUsers(model.USER_NAME);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUserReportConfiguration([FromBody] List<REPORT_USER_CONFIGURATION> model)
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
                    if (item.ID == 0)
                    {
                        item.ENTERED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        item.ENTERED_DATE = DateTime.Now;
                        item.ENTERED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                        item.COMPANY_ID = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value);
                    }
                    else
                    {
                        item.UPDATED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        item.UPDATED_DATE = DateTime.Now;
                        item.UPDATED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                    }
                }
                result = await _service.AddUserReportConfiguration(model);
            }

            return Json(result);
        }
    }
}