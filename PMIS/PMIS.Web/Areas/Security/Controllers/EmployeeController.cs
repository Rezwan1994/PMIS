using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Entities;
using PMIS.Service.Interface.Security;
using PMIS.Web.Common;

namespace PMIS.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
    
        public IActionResult EmployeeInfo()
        {
            return View();
        }

        [HttpGet]
        public async Task<string> LoadData()
        {
            return await _service.GetEmployeeList(User.GetComapanyId());
        }

        [HttpPost]
        public async Task<JsonResult> AddOrUpdate([FromBody] EMPLOYEE_INFO model)
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
                    model.COMPANY_ID = User.GetComapanyId();
                    result = await _service.AddOrUpdate(model);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }

            return Json(result);
        }
    }
}
