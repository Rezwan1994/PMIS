using System;
using System.Collections.Generic;
using System.Text;

namespace PMIS.Domain.ViewModels.Security
{
    public class RoleReportConfigView
    {
        public int ROW_NO { get; set; }
        public int ID { get; set; }
        public int COMPANY_ID { get; set; }
        public int REPORT_ID { get; set; }
        public string REPORT_NAME { get; set; }
        public string REPORT_TITLE { get; set; }
        public int MENU_ID { get; set; }
        public string MENU_NAME { get; set; }
        public int ROLE_ID { get; set; }
        public string PDF_PERMISSION { get; set; }
        public string PREVIEW_PERMISSION { get; set; }
        public string CSV_PERMISSION { get; set; }
    }
}
