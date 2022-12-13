using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class COMPANY_INFO
    {
        public int COMPANY_ID { get; set; }
        public string? COMPANY_CODE { get; set; }
        public string? COMPANY_NAME { get; set; }
        public string? COMPANY_SHORT_NAME { get; set; }
        public string? COMPANY_ADDRESS1 { get; set; }
        public string? COMPANY_ADDRESS2 { get; set; }
        public string? STATUS { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
    }
}
