using Microsoft.AspNetCore.Mvc;
using PMIS.Domain.Common;
using PMIS.Domain.ViewModels.Security;
using PMIS.Repository.Interface;
using PMIS.Service.Interface.Security;
using PMIS.Utility.Static;
using PMIS.Web.Common;
using System.Text.Json;

namespace PMIS.Web.Areas.PromotionalProductMaterial.Controllers
{
    [Area("PromotionalProductMaterial")]
    public class ReportController : Controller
    {
        private readonly IReportConfigurationService _reportConfigurationService;
        private readonly ICommonServices _commonService;
        private readonly IHostEnvironment _hostManager;

        public ReportController(IReportConfigurationService reportConfigurationService, ICommonServices commonServices, IHostEnvironment hostManager)
        {
             _reportConfigurationService= reportConfigurationService;
            _commonService= commonServices;
            _hostManager = hostManager;
        }

        public async Task<IActionResult> Index()
        {
            int User_id = Convert.ToInt32(User.GetUserId());
            int Comp_id = User.GetComapanyId();
            
            List<ReportPermission> reportData = await _reportConfigurationService.LoadReportPermissionData(Comp_id, User_id);

            reportData = reportData.Where(x => x.MENU_ACTION == "Index"
                && x.MENU_NAME == "PromotionalProductMaterial-Report")
                .OrderBy(x => x.ORDER_BY_SLNO).ToList();

            foreach (ReportPermission reportDataSpecify in reportData)
            {
                reportDataSpecify.ReportIdEncrypt = _commonService.Encrypt(reportDataSpecify.REPORT_ID.ToString());
            }
            return View(reportData);
        }

        [HttpGet]
        public IActionResult GenerateReport(string ReportId, ReportParams reportParameters)
        {
            string ReportUrl = _hostManager.IsDevelopment() == true ? CodeConstants.Report_URL : CodeConstants.Report_URL_RELEASE;
            reportParameters.USER_NAME = User.GetUserName();
            reportParameters.SECRET_KEY = CodeConstants.Report_Secret_Key;
            reportParameters.COMPANY_ID = User.GetComapanyId();
            reportParameters.UNIT_ID = reportParameters.UNIT_ID;
            reportParameters.REPORT_ID = Convert.ToInt32(_commonService.Decrypt(ReportId.ToString()));

            if (!string.IsNullOrWhiteSpace(reportParameters.MST_ID))
            {
                if (reportParameters.MST_ID[0] == ',')
                {
                    reportParameters.MST_ID = "";
                }
            }

            //reportParameters.REPORT_EXTENSION = "pdf";
            //reportParameters.REPORT_ID = ReportId;
            string q = JsonSerializer.Serialize<ReportParams>(reportParameters);
            q = _commonService.Encrypt(q);
            string Url = "";
            
            switch(reportParameters.REPORT_ID)
            {
                case 1: Url = ReportUrl + "PPMReport/PromotionalMaterial?q=" + q;
                    break;
            }

            return Redirect(Url);
        }


        [HttpPost]
        public string IsReportPermitted([FromBody] ReportPermission report)
        {
            List<ReportPermission> reportPermissions = JsonSerializer.Deserialize<List<ReportPermission>>(HttpContext.Session.GetString(ClaimsType.ReportPermission));

            return JsonSerializer.Serialize(_reportConfigurationService.IsReportPermitted(report.REPORT_ID, reportPermissions));
        }
    }
}
