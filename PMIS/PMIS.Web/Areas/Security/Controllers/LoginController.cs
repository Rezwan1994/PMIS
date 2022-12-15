using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Mvc;

using PMIS.Domain.Common;
using PMIS.Domain.Entities;
using PMIS.Domain.ViewModels.Security;
using PMIS.Repository.Interface;
using PMIS.Service.Interface.Security;
using PMIS.Utility.Static;
using PMIS.Web.Common;
using System.Security.Claims;
using System.Text.Json;

namespace PMIS.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _accountService;
        private readonly IConfiguration _configuration;
        private readonly IMenuPermissionService _menuService;
        private readonly ICompanyService _companyService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _Accessor;

        //private readonly IReportConfigurationManager _reportManager;
        private readonly ICommonServices _commonServices;

        public LoginController(ILogger<LoginController> logger, IUserService accountService, IConfiguration configuration, IMenuPermissionService menuPermission, ICompanyService companyManager, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor Accessor/*, IReportConfigurationManager reportManager*/, ICommonServices commonServices)
        {
            _logger = logger;
            this._accountService = accountService;
            _configuration = configuration;
            _menuService = menuPermission;
            _companyService = companyManager;
            _hostingEnvironment = hostingEnvironment;
            _Accessor = Accessor;
            //_reportManager = reportManager;
            _commonServices = commonServices;
        }

        private string GetEmailOfCurrentUser() => User.Claims.FirstOrDefault(x => x.Type == ClaimsType.Email).Value.ToString();

        private string GetUserNameOfCurrentUser() => User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value.ToString();

        public async Task<IActionResult> Index()
        {
            List<COMPANY_INFO> company_Infos = await _companyService.GetCompanyList();

            if (_Accessor.HttpContext.Request.Cookies["LoginMailHolder"] != null)
            {
                ViewBag.UserName = _Accessor.HttpContext.Request.Cookies["LoginMailHolder"];
            }
            if (_Accessor.HttpContext.Request.Cookies["LoginPassHolder"] != null)
            {
                ViewBag.UserPass = _Accessor.HttpContext.Request.Cookies["LoginPassHolder"];
            }
            if (_Accessor.HttpContext.Request.Cookies["LoginCompanyHolder"] != null)
            {
                ViewBag.UserCompany = _Accessor.HttpContext.Request.Cookies["LoginCompanyHolder"];
            }
            return View(company_Infos);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] Login model)
        {
            try
            {
                if (model.Email != null && model.Password != null && model.Email != "" && model.Password != "")
                {
                    Auth _user = null;
                    if (model.CompanyId > 0)
                    {
                        _user = _accountService.GetUserByEmailAndCompany(model.Email, model.CompanyId);
                    }

                    if (_user != null)
                    {
                        if (_accountService.IsValidUser(model.Email, model.Password, _user.CompanyId, _user.Password))
                        {
                            MenuDistribution menuDistribution = await _menuService.LoadPermittedMenuByUserId(_user.UserId, _user.CompanyId);
                            string menuDis = JsonSerializer.Serialize(menuDistribution);
                            string defaultPage = _menuService.LoadUserDefaultPageById(_user.UserId);
                            defaultPage = defaultPage == null ? "Security/User/PagePermissionNotice" : defaultPage;

                            //List<ReportPermission> reportPermissions = await _reportManager.LoadReportPermissionData(GetDbConnectionString(model.CompanyId), _user.CompanyId, _user.UserId);
                            //string reportDis = JsonSerializer.Serialize(reportPermissions);

                            var claims = new List<Claim>()
                            {
                               new Claim(ClaimTypes.Name, _user.UserName),
                               new Claim(ClaimTypes.Role, "Administrator"),
                              new Claim(ClaimTypes.NameIdentifier, _user.UserId.ToString()),
                               new Claim(ClaimsType.UserName, _user.UserName),
                               new Claim(ClaimsType.UserId, _user.UserId.ToString()),
                               new Claim(ClaimsType.Email, _user.Email),
                               new Claim(ClaimsType.UserType, _user.UserType.ToString()),
                               new Claim(ClaimsType.CompanyId, _user.CompanyId.ToString()),
                               new Claim(ClaimsType.DepotId, _user.DepotId.ToString()),
                               new Claim(ClaimsType.DepotName, _user.DepotName.ToString()),

                               new Claim(ClaimsType.CompanyName, _user.CompanyName.ToString()),
                               new Claim(ClaimsType.DistributorId, _user.DistributorId.ToString()),
                               new Claim(ClaimsType.DefaultPage,defaultPage),
                               //new Claim(ClaimsType.DbSpecifier, provider.GetConnectionString(_user.CompanyName))
                            };
                            HttpContext.Session.SetString(ClaimsType.RolePermission, menuDis);
                            //HttpContext.Session.SetString(ClaimsType.ReportPermission, reportDis);

                            HttpContext.Session.SetString("DefaultPage", defaultPage);

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            var authProperties = new AuthenticationProperties
                            {
                                AllowRefresh = true,

                                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1440),

                                IssuedUtc = DateTime.Now,
                            };

                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                authProperties);

                            _logger.LogInformation("User {Email} logged in at {Time}.", _user.Email, DateTime.UtcNow);
                            if (model.RememberMe == true)
                            {
                                CookieOptions option = new CookieOptions();
                                option.Expires = DateTime.Now.AddDays(29);
                                _Accessor.HttpContext.Response.Cookies.Append("LoginMailHolder", _user.Email, option);
                                _Accessor.HttpContext.Response.Cookies.Append("LoginPassHolder", _commonServices.Decrypt(_user.Password), option);
                                _Accessor.HttpContext.Response.Cookies.Append("LoginCompanyHolder", _user.CompanyId.ToString(), option);
                            }

                            string URL = "~/" + defaultPage;

                            return Redirect(URL);
                        }
                        else
                        {
                            ViewBag.errorMessage = "Wrong Password Entered!!!";
                        }
                    }
                    else
                    {
                        ViewBag.errorMessage = model.CompanyId == 0 ? "Please select a company first!!!" : "Wrong Email Entered!!!";
                    }
                }
                else
                {
                    ViewBag.errorMessage = "Please Enter Correct Email and Password!";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            List<COMPANY_INFO> company_Infos = await _companyService.GetCompanyList();

            return View(company_Infos);
        }

        [AuthorizeCheck]
        public IActionResult ChangePassword()
        {
            _logger.LogInformation("Change Password(Login/ChangePassword) Page Has been accessed By " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value.ToString() + " ( ID= " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value.ToString());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(PasswordChangeModel changeModel)
        {
            if (changeModel != null)
            {
                changeModel.USER_ID = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value.ToString());
                changeModel.Email = GetEmailOfCurrentUser();
                changeModel.User_Name = GetUserNameOfCurrentUser();
                changeModel.Path = _hostingEnvironment.WebRootPath + "/Templates/EmailTemplate/AccountVerification_EmailTemplate.cshtml";
                ViewData["ErrMsg"] = await _accountService.UpdateUserPassword(changeModel);
            }
            return View();
        }

        public async Task<IActionResult> ForgetPassword()
        {
            _logger.LogInformation("Forget Password(Login/ForgetPassword) Page Has been accessed");
            List<COMPANY_INFO> company_Infos = await _companyService.GetCompanyList();

            return View(company_Infos);
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(PasswordChangeModel changeModel)
        {
            if (changeModel != null && changeModel.Company_Id > 0)
            {
                Auth _auth = _accountService.GetUserByEmail(changeModel.Email);
                if (_auth != null)
                {
                    changeModel.USER_ID = Convert.ToInt32(_auth.UserId);
                    changeModel.Email = _auth.Email;
                    changeModel.User_Name = _auth.UserName;
                    changeModel.Path = _hostingEnvironment.WebRootPath + "/Templates/EmailTemplate/AccountVerification_EmailTemplate.cshtml";
                    ViewData["Notify"] = await _accountService.ForgetPasswordVerify(changeModel);

                }
                else
                {
                    ViewData["Notify"] = "Please enter valid Email and Select Your Company";

                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _Accessor.HttpContext?.Response.Cookies.Delete("MenuHolder");
            return LocalRedirect("/");
        }
    }
}