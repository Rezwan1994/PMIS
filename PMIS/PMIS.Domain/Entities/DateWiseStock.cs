using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class DateWiseStock
    {
        public DateTime? StockDate { get; set; }
        public string? DepotCode { get; set; }
        public string? PmCode { get; set; }
        public decimal? OpeningStockQty { get; set; }
        public decimal? ClosingStockQty { get; set; }
    }
}
