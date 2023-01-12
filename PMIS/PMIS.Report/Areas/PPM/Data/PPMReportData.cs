using Microsoft.Reporting.WebForms;
using PMIS.Report.Models;
using PMIS.Report.Services.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PMIS.Report.Areas.PPM.Data
{
    public class PPMReportData : BaseData
    {
        public DataTable GetProductInfo(ReportParams reportParams)
        {
            var query = @"SELECT PM_ID,
                PM_CODE,
                PM_NAME,
                PACK_SIZE,
                PM_CATEGORY_CODE,
                PM_CATEGORY_NAME,
                STATUS
            FROM PROMOTIONAL_MATERIAL_INFO";

            if (!string.IsNullOrWhiteSpace(reportParams.PM_CATEGORY_CODE)
                && reportParams.PM_CATEGORY_CODE != "undefined")
            {
                query += " AND B.PM_CATEGORY_CODE IN (";
                var arr = reportParams.PM_CATEGORY_CODE.Split(',');
                var ids = "";
                foreach (var no in arr)
                {
                    ids += "'" + no + "',";
                }
                query += ids.Substring(0, ids.Length - 1) + ") ";
            }

            query += " ORDER BY B.PM_CATEGORY_NAME";

            var dt = _commonServices.GetDataTable(connStr, query, _commonServices.AddParameter(new string[] { }));

            return dt;
        }
    }
}