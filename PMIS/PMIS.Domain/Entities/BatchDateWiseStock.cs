using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class BatchDateWiseStock
    {
        public DateTime StockDate { get; set; }
        public string DepotCode { get; set; } = null!;
        public string PmCode { get; set; } = null!;
        public decimal? BatchId { get; set; }
        public string BatchNo { get; set; } = null!;
        public decimal? OpeningStockQty { get; set; }
        public decimal? ClosingStockQty { get; set; }
    }
}
