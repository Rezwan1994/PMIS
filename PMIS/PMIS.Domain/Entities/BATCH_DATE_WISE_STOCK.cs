using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class BATCH_DATE_WISE_STOCK
    {
        public DateTime STOCK_DATE { get; set; }
        public string DEPOT_CODE { get; set; } = null!;
        public string PM_CODE { get; set; } = null!;
        public decimal? BATCH_ID { get; set; }
        public string BATCH_NO { get; set; } = null!;
        public decimal? OPENING_STOCK_QTY { get; set; }
        public decimal? CLOSING_STOCK_QTY { get; set; }
    }
}
