using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class BUDGET_MST
    {
        public int MST_ID { get; set; }
        public string? BUDGET_NO { get; set; }
        public DateTime? BUDGET_DATE { get; set; }
        public string? YEAR_CODE { get; set; }
        public string? MONTH_CODE { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
