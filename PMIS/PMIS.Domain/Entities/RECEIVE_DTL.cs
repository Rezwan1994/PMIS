using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class RECEIVE_DTL
    {
        public int DTL_ID { get; set; }
        public int? MST_ID { get; set; }
        public string? DEPOT_CODE { get; set; }
        public DateTime? RECEIVE_DATE { get; set; }
        public string? SBU { get; set; }
        public string? PM_CATEGORY_CODE { get; set; }
        public string? UNIT_CODE { get; set; }
        public string? PRODUCTION_UNIT_CODE { get; set; }
        public string? PM_CODE { get; set; }
        public decimal? UNIT_PRICE { get; set; }
        public decimal? BUDGET_QUANTITY { get; set; }
        public decimal? STOCK_TRANSFER_ORDER_QUANTITY { get; set; }
        public decimal? RECEIVED_QUANTITY { get; set; }
        public decimal? RECEIVE_AMOUNT { get; set; }
        public int? FROM_SURPLUS_QUANTITY { get; set; }
        public int? DUE_PART_DUE_EXCESS_QUANTITY { get; set; }
        public int? NO_OF_SLOT { get; set; }
        public int? BATCH_ID { get; set; }
        public int? BATCH_NO { get; set; }
        public DateTime? EXPIRY_DATE { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
    }
}
