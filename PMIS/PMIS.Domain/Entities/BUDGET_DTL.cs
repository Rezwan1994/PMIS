using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class BUDGET_DTL
    {
        public decimal? DTL_ID { get; set; }
        public decimal? MST_ID { get; set; }
        public string? SBU { get; set; }
        public string? PM_CATEGORY_CODE { get; set; }
        public string? DEPOT_CODE { get; set; }
        public string? UNIT_CODE { get; set; }
        public string? PRODUCTION_UNIT_CODE { get; set; }
        public string? PM_CODE { get; set; }
        public decimal? BUDGET_QUANTITY { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
