using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class TRANSFER_RECEIVE_MST
    {
        public decimal? MST_ID { get; set; }
        public string? REF_NO { get; set; }
        public DateTime? REF_DATE { get; set; }
        public string? TRANSFER_DEPOT_CODE { get; set; }
        public string? TRANSFER_NO { get; set; }
        public DateTime? TRANSFER_DATE { get; set; }
        public string? RECEIVE_DEPOT_CODE { get; set; }
        public string? RECEIVE_NO { get; set; }
        public DateTime? RECEIVE_DATE { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
    }
}
