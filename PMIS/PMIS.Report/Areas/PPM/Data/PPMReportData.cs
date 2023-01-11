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
            var query = @"SELECT A.PM_ID, A.PM_CODE, A.PM_NAME, A.PACK_SIZE,
                A.PM_CATEGORY_CODE, B.PM_CATEGORY_NAME, A.STATUS
                FROM PROMOTIONAL_MATERIAL_INFO A, PM_CATEGORY_INFO B
                WHERE A.PM_CATEGORY_CODE = B.PM_CATEGORY_CODE";

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

            var dt = _commonServices.GetDataTable(connStr, query, _commonServices.AddParameter(new string[] { }));

            return dt;
        }
    }
}