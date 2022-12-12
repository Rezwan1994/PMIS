using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class PRODUCTION_UNIT_INFO
    {
        public decimal? PRODUCTION_UNIT_ID { get; set; }
        public string? PRODUCTION_UNIT_CODE { get; set; }
        public string? PRODUCTION_UNIT_NAME { get; set; }
        public string? UNIT_CODE { get; set; }
        public string? STATUS { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
