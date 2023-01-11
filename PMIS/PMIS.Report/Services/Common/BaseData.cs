using PMIS.Report.Models;
using PMIS.Services.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace PMIS.Report.Services.Common
{
    public class BaseData
    {
        protected readonly CommonServices _commonServices = new CommonServices();
        protected readonly string connStr = ConfigurationManager.ConnectionStrings["PMIS"].ConnectionString;

        public DataTable GetPageHeaderReport(ReportParams reportParameters)
        {
            var sql = @"Select  
                COMPANY_NAME 
                ,COMPANY_ADDRESS
                from VW_REPORT_HEADER_DATA where COMPANY_ID = :param1 and ROWNUM =1";

            var dt = _commonServices.GetDataTable(connStr, sql, _commonServices.AddParameter(new string[] { reportParameters.COMPANY_ID.ToString() }));

            dt.Columns.Add("UNIT_NAME");
            dt.Columns.Add("DATE_FROM");
            dt.Columns.Add("DATE_TO");
            dt.Rows[0]["UNIT_NAME"] = reportParameters.UNIT_NAME;
            dt.Rows[0]["DATE_FROM"] = reportParameters.DATE_FROM;
            dt.Rows[0]["DATE_TO"] = reportParameters.DATE_TO;
            return dt;
        }
    }
}