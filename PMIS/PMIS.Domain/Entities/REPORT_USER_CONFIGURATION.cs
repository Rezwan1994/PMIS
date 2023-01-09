using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class REPORT_USER_CONFIGURATION
    {
        public int ID { get; set; }
        public int? REPORT_ID { get; set; }
        public int? USER_ID { get; set; }
        public string? PREVIEW_PERMISSION { get; set; }
        public string? CSV_PERMISSION { get; set; }
        public string? PDF_PERMISSION { get; set; }
        public int? COMPANY_ID { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
