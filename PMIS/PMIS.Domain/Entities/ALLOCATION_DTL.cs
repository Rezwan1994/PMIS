using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ALLOCATION_DTL
    {
        public int DTL_ID { get; set; }
        public int? MST_ID { get; set; }
        public string? PM_CATEGORY_CODE { get; set; }
        public string? PM_CODE { get; set; }
        public decimal? ALLOCATION_QTY { get; set; }
        public string? STATUS { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
    }
}
