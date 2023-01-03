using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PMIS.Domain.Common;
using PMIS.Service.Interface.Security;
using PMIS.Web.Common;
using System.Globalization;

namespace SalesAndDistributionSystem.Areas.Security.Controllers
{
    [Area("Security")]
    public class UserLogController : Controller
    {
        private readonly IUserLogService _service;

        //private readonly ServiceProvider Provider = new ServiceProvider();

        public UserLogController(IUserLogService _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public Task<string> LoadData()
        {
            return _service.LoadData(User.GetComapanyId().ToString());
        }

        [HttpPost]
        public async Task<string> Search([FromBody] SearchModel model)
        {
            if (!ModelState.IsValid)
            {
                var arr = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                return JsonConvert.SerializeObject(arr);
            }
            return await _service.Search(User.GetComapanyId(), model);
        }

        [HttpPost]
        public async Task<string> ActivityLogData(SearchModel model)
        {
            model.USER_ID = User.GetUserId();
            model.FROM_DATE ??= DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            model.TO_DATE ??= DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            return await _service.Search(User.GetComapanyId(), model);
        }

        public IActionResult ViewLogs()
        {
            return View();
        }

        public IActionResult ActivityLog()
        {
            return View();
        }
    }
}