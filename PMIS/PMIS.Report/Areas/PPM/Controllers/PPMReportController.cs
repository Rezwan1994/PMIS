using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using PMIS.Report.Areas.PPM.Data;
using PMIS.Report.Models;
using PMIS.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMIS.Report.Areas.PPM.Controllers
{
    public class PPMReportController : Controller
    {
        private readonly ILogError _logger = new LogError();
        PPMReportData _service = new PPMReportData();
        private readonly CommonServices _commonservice = new CommonServices();

        // GET: PPM/Sample
        public ActionResult PromotionalMaterial(string q)
        {
            try
            {
                q = _commonservice.Decrypt(q);
                ReportParams reportParams = JsonConvert.DeserializeObject<ReportParams>(q);
                reportParams.COMPANY_ID = reportParams.COMPANY_ID;

                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Areas/PPM/Reports/PPMReport.rdlc");

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "ReportHeader";
                reportDataSource.Value = _service.GetPageHeaderReport(reportParams);
                localReport.DataSources.Add(reportDataSource);

                ReportDataSource reportDataSource2 = new ReportDataSource();
                reportDataSource2.Name = "PromotionalMaterial";
                reportDataSource2.Value = _service.GetProductInfo(reportParams);
                localReport.DataSources.Add(reportDataSource2);

                string reportType = "pdf"; //reportParameters.REPORT_EXTENSION;
                (byte[] renderedBytes, string mimeType) = localReport.RenderReport(reportType);
                return new FileContentResult(renderedBytes, mimeType);
            }
            catch (Exception exp)
            {
                _logger.Error(Server, exp);
                return Content("<h1>Something Went Wrong!</h1>");
            }
        }
    }
}