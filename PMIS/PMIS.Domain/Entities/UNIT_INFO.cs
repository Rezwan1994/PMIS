using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class UNIT_INFO
    {
        public decimal UNIT_ID { get; set; }
        public string? UNIT_CODE { get; set; }
        public string? UNIT_NAME { get; set; }
        public string? UNIT_SHORT_NAME { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public string? STATUS { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
