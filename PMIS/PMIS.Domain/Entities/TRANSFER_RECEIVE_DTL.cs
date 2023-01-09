using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class TRANSFER_RECEIVE_DTL
    {
        public int DTL_ID { get; set; }
        public int? MST_ID { get; set; }
        public int? RECEIVE_DEPOT_CODE { get; set; }
        public DateTime? RECEIVE_DATE { get; set; }
        public int? PM_CATEGORY_CODE { get; set; }
        public int? PM_CODE { get; set; }
        public int? BATCH_ID { get; set; }
        public string? BATCH_NO { get; set; }
        public decimal? UNIT_PRICE { get; set; }
        public int? TRANSFER_QTY { get; set; }
        public decimal? TRANSFER_AMOUNT { get; set; }
        public int? RECEIVE_QTY { get; set; }
        public decimal? RECEIVE_AMOUNT { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
    }
}
