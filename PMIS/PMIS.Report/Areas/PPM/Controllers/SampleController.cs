using Microsoft.Reporting.WebForms;
using PMIS.Report.Areas.PPM.Data;
using PMIS.Report.Models;
using PMIS.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PMIS.Report.Areas.PPM.Controllers
{
    public class SampleController : Controller
    {
        private readonly ILogError _logger = new LogError();
        SampleData _service = new SampleData();

        // GET: PPM/Sample
        public ActionResult Sample()
        {
            try
            {
                ReportParams reportParams = new ReportParams();
                reportParams.COMPANY_ID = 1;

                LocalReport localReport = new LocalReport();
                localReport.ReportPath = Server.MapPath("~/Areas/PPM/Reports/SampleReport.rdlc");

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "ReportHeader";
                reportDataSource.Value = _service.GetPageHeaderReport(reportParams);
                localReport.DataSources.Add(reportDataSource);

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