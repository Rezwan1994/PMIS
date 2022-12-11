using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class BatchWiseStock
    {
        public string? DepotCode { get; set; }
        public string? PmCode { get; set; }
        public decimal? BatchId { get; set; }
        public string? BatchNo { get; set; }
        public decimal? StockQty { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
