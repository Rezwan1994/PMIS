using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class RECEIVE_MST
    {
        public int MST_ID { get; set; }
        public string? RECEIVE_TYPE { get; set; }
        public string? YEAR_CODE { get; set; }
        public string? MONTH_CODE { get; set; }
        public string? BUDGET_NO { get; set; }
        public string? DEPOT_CODE { get; set; }
        public string? RECEIVE_NO { get; set; }
        public DateTime? RECEIVE_DATE { get; set; }
        public string? SUPPLIER_CODE { get; set; }
        public string? PO_NO { get; set; }
        public DateTime? PO_DATE { get; set; }
        public string? CHALLAN_NO { get; set; }
        public DateTime? CHALLAN_DATE { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
    }
}
