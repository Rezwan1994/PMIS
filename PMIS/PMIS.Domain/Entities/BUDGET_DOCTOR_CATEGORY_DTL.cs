using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class BUDGET_DOCTOR_CATEGORY_DTL
    {
        public int ID { get; set; }
        public int? DTL_ID { get; set; }
        public int? MST_ID { get; set; }
        public string? DOCTORY_CATEGORY_CODE { get; set; }
        public decimal? BUDGET_QUANTITY { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
