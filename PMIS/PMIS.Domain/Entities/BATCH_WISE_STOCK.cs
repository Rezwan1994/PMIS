using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class BATCH_WISE_STOCK
    {
        public string? DEPOT_CODE { get; set; }
        public string? PM_CODE { get; set; }
        public decimal? BATCH_ID { get; set; }
        public string? BATCH_NO { get; set; }
        public decimal? STOCK_QTY { get; set; }
        public decimal? UNIT_PRICE { get; set; }
        public DateTime? EXPIRY_DATE { get; set; }
        public int ID { get; set; }
    }
}
