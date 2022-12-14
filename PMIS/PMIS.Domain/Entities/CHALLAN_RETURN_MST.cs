using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class CHALLAN_RETURN_MST
    {
        public int MST_ID { get; set; }
        public DateTime RETURN_DATE { get; set; }
        public string DEPOT_CODE { get; set; } = null!;
        public string? RETURN_TYPE { get; set; }
        public string CHALLAN_NO { get; set; } = null!;
        public string? ALLOCATION_TYPE { get; set; }
        public string? LOCATION_TYPE { get; set; }
        public string? LOCATION_CODE { get; set; }
        public string? LOCATION_ECODE { get; set; }
        public string? RETURN_CAUSE_CODE { get; set; }
        public string? REMARKS { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
