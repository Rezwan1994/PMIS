using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Common;
using PMIS.Domain.Entities;
using PMIS.Service.Interface.Security;
using PMIS.Utility.Static;
using PMIS.Web.Common;

namespace SalesAndDistributionSystem.Areas.Security.User.Controllers
{
    [Area("Security")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UserController(IUserService service, ILogger<UserController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        private string GetUserTypeString() => User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserType).Value.ToString();

        public IActionResult Index()
        {
            _logger.LogInformation("User Config(User/Index)  Page Has been accessed By " + User.GetUserName() + " (ID= " + User.GetUserId() + ")");
            return View();
        }

        public IActionResult DefaultPage()
        {
            _logger.LogInformation("User Config(User/DefaultPage)  Page Has been accessed By " + User.GetUserName() + " (ID= " + User.GetUserId() + ")");

            return View();
        }

        public string LoadData()
        {
            int comp_id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId)?.Value);
            if (GetUserTypeString() == UserType.SuperAdmin)
            {
                return _service.GetUsers();
            }
            else
            {
                return _service.GetUsersByCompany(comp_id);
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddOrUpdate([FromBody] USER_INFO model)
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
                    if (model.USER_ID == 0)
                    {
                        model.ENTERED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        model.ENTERED_DATE = DateTime.Now;
                        model.ENTERED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                        if (model.COMPANY_ID == 0)
                        {
                            model.COMPANY_ID = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value);
                        }
                    }
                    else
                    {
                        model.UPDATED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        model.UPDATED_DATE = DateTime.Now;
                        model.UPDATED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                    }
                    result = await _service.AddOrUpdate(model, _hostingEnvironment.WebRootPath + "/Templates/EmailTemplate/AccountVerification_EmailTemplate.cshtml");
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }

            return Json(result);
        }

        [HttpPost]
        public string GetEmployeeWithoutAccount(USER_INFO model)
        {
            int comp_id = User.GetComapanyId();
            return _service.GetEmployeesWithoutAccount(comp_id);
        }

        //-------------------------Default Pages ------------------------------------------------------------------
        [HttpPost]
        public async Task<string> GetSearchableDefaultPages([FromBody] USER_DEFAULT_PAGE model)
        {
            int comp_id = model == null || model.COMPANY_ID == 0 ? Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : model.COMPANY_ID;
            return await _service.LoadSearchableDefaultPages(comp_id, model.MENU_ID.ToString());
        }

        [HttpPost]
        public async Task<string> LoadDefaultPages([FromBody] USER_DEFAULT_PAGE model)
        {
            int comp_id = model == null || model.COMPANY_ID == 0 ? Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : model.COMPANY_ID;
            return await _service.LoadDefaultPages(comp_id);
        }

        [HttpPost]
        public async Task<JsonResult> AddOrUpdateDefaultPage([FromBody] USER_DEFAULT_PAGE model)
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
                    if (model.ID == 0)
                    {
                        model.ENTERED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        model.ENTERED_DATE = DateTime.Now;
                        model.ENTERED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                        if (model.COMPANY_ID == 0)
                        {
                            model.COMPANY_ID = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value);
                        }
                    }
                    else
                    {
                        model.UPDATED_BY = User.Claims.FirstOrDefault(c => c.Type == ClaimsType.UserId)?.Value;
                        model.UPDATED_DATE = DateTime.Now;
                        model.UPDATED_TERMINAL = HttpContext.Connection.RemoteIpAddress.ToString();
                    }

                    result = await _service.AddOrUpdateDefaultPage(model);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }

            return Json(result);
        }

        //---------------User Verification--------------------------------------------------
        [HttpGet]
        public IActionResult AccountVerification(Auth auth)
        {
            return View(_service.IsVerified(auth.UniqueId));
        }

        [HttpGet]
        public IActionResult PagePermissionNotice(Auth auth)
        {
            return View();
        }

        [HttpPost]
        public string LoadUsersByCompanyId([FromBody] USER_INFO model)
        {
            int comp_id = model == null || model.COMPANY_ID == 0 ? Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : model.COMPANY_ID;
            return _service.GetUsersByCompany(comp_id);
        }
    }
}