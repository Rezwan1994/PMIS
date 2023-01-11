using System;
using System.Collections.Generic;
using System.Text;

namespace PMIS.Domain.Common
{
    public class ReportParams
    {
        public string PREVIEW { get; set; }
        public string DATE_FROM { get; set; }
        public string DATE_TO { get; set; }
        public string MST_ID { get; set; }
        public int REPORT_ID { get; set; }
        public string DB { get; set; }
        public string DB_SECURITY { get; set; }
        public string SECRET_KEY { get; set; }
        public string USER_NAME { get; set; }
        public string YEAR { get; set; }
        public string MONTH_CODE { get; set; }

        public string DIVISION_ID { get; set; }
        public string REGION_ID { get; set; }
        public string AREA_ID { get; set; }
        public string TERRITORY_ID { get; set; }
        public string MARKET_ID { get; set; }
        public string CUSTOMER_ID { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public int COMPANY_ID { get; set; }
        public string UNIT_ID { get; set; }
        public string PM_CATEGORY_CODE { get; set; }
    }
}
