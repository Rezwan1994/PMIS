using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesAndDistributionSystem.Areas.Security.Company.Controllers
{
    [Area("Security")]
    public class CompanyController : Controller
    {
        private readonly ICompanyManager _service;
        private readonly ILogger<CompanyController> _logger;
        private readonly IConfiguration _configuration;
        public CompanyController(ICompanyManager service, ILogger<CompanyController> logger, IConfiguration configuration)
        {
            _service = service;
            _logger = logger;
            _configuration = configuration;
        }
 
        private string GetDbConnectionString() => User.Claims.FirstOrDefault(x => x.Type == ClaimsType.DbSpecifier).Value.ToString();

        public string GetCompany() => User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value.ToString();
        public string GetCompanyName() => User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyName).Value.ToString();

        public string GetUnit() => User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UnitId).Value.ToString();
        public string GetUnitName() => User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UnitName).Value.ToString();


        [AuthorizeCheck]
        public IActionResult Index()
        {
            _logger.LogInformation("Company Index (Company/Index) Page Has been accessed By " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value != null ? User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value.ToString() : "Unknown User" + " ( ID= " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value != null ? User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value.ToString() : "");

            return View();
        }

        [AuthorizeCheck]
        public IActionResult Unit()
        {
            _logger.LogInformation("Company Unit (Company/Unit) Page Has been accessed By " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value != null ? User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserName).Value.ToString() : "Unknown User" + " ( ID= " + User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value != null ? User.Claims.FirstOrDefault(x => x.Type == ClaimsType.UserId).Value.ToString() : "");

            return View();
        }
     
        [HttpGet]
        public async Task<string> LoadData()
        {
            return await _service.GetCompanyJsonList(GetDbConnectionString());
        }

        [HttpGet]
        public async Task<string> GetUserUnit()
        {
            var comapnayId = User.GetComapanyId();
            var unitId = User.GetUnitId();
            return await _service.GetUnitInfo(GetDbConnectionString(), comapnayId, unitId);
        }

        [HttpPost]
        public async Task<string> GetUnitListByCompanyId([FromBody]  Company_Info model)
        {
            model.COMPANY_ID = model.COMPANY_ID == 0 ? Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimsType.CompanyId).Value) : model.COMPANY_ID;

            return await _service.GetUnitByCompanyId(GetDbConnectionString(), model.COMPANY_ID);
        }
        [HttpPost]
        public async Task<JsonResult> AddOrUpdate([FromBody] Company_Info model)
        {
            string result;

            if (model == null)
            {
                result = "No Changes Found!";
            }
            else
            {
                try
                {
                   
                    result = await _service.AddOrUpdate(GetDbConnectionString(), model);

                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }

            }


            return Json(result);


        }
        [HttpGet]
        public async Task<string> LoadUnitData()
        {
            return await _service.GetUnitJsonList(GetDbConnectionString());
        }

        [HttpPost]
        public async Task<JsonResult> AddOrUpdateUnit([FromBody] Company_Info model)

        {
            string result;

            if (model == null)
            {
                result = "No Changes Found!";
            }
            else
            {
                try
                {

                    result = await _service.AddOrUpdateUnit(GetDbConnectionString(), model);

                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }

            }


            return Json(result);


        }
        
        [HttpPost]
        public async Task<IActionResult> ActivateUnit([FromBody] Company_Info company_Info)
        {
            string result = await _service.ActivateUnit(GetDbConnectionString(), company_Info.ID);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeactivateUnit([FromBody] Company_Info company_Info)
        {
            string result = await _service.DeactivateUnit(GetDbConnectionString(), company_Info.ID);

            return Json(result);
        }

    }
}
