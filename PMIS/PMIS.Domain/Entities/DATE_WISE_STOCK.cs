using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class DATE_WISE_STOCK
    {
        public DateTime? STOCK_DATE { get; set; }
        public string? DEPOT_CODE { get; set; }
        public string? PM_CODE { get; set; }
        public decimal? OPENING_STOCK_QTY { get; set; }
        public decimal? CLOSING_STOCK_QTY { get; set; }
    }
}
