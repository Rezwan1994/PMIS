using Microsoft.Reporting.WebForms;
using PMIS.Report.Models;
using PMIS.Report.Services.Common;
using PMIS.Services.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace PMIS.Report.Areas.PPM.Data
{
    public class SampleData : BaseData
    {
        public DataTable GetProductInfo()
        {
            var query = "SELECT * FROM PRODUCTION_UNIT_INFO";
            var dt = _commonServices.GetDataTable(connStr, query, _commonServices.AddParameter(new string[] { }));
            
            return dt;
        }
    }
}