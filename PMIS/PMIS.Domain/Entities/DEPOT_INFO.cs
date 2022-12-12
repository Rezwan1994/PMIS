using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class DEPOT_INFO
    {
        public decimal? DEPOT_ID { get; set; }
        public string? DEPOT_CODE { get; set; }
        public string? DEPOT_NAME { get; set; }
        public string? DEPOT_SHORT_NAME { get; set; }
        public string? DEPOT_ADDRESS { get; set; }
        public string? STATUS { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
