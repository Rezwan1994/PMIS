using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ALLOCATION_MST
    {
        public int MST_ID { get; set; }
        public string? YEAR_CODE { get; set; }
        public string? MONTH_CODE { get; set; }
        public string? PRODUCT_GROUP { get; set; }
        public string? MARKET_GROUP { get; set; }
        public string? MARKET_CODE { get; set; }
        public string? TERRITORY_CODE { get; set; }
        public string? REGION_CODE { get; set; }
        public string? DIVISION_CODE { get; set; }
        public string? DEPOT_CODE { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
    }
}
