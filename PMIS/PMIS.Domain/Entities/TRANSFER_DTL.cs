using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class TRANSFER_DTL
    {
        public decimal? DTL_ID { get; set; }
        public decimal? MST_ID { get; set; }
        public string? TRANSFER_DEPOT_CODE { get; set; }
        public DateTime? TRANSFER_DATE { get; set; }
        public string? PM_CATEGORY_CODE { get; set; }
        public string? PM_CODE { get; set; }
        public decimal? BATCH_ID { get; set; }
        public string? BATCH_NO { get; set; }
        public decimal? UNIT_PRICE { get; set; }
        public decimal? TRANSFER_QTY { get; set; }
        public decimal? TRANSFER_AMOUNT { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
    }
}
