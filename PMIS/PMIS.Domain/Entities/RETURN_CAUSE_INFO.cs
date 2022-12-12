using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class RETURN_CAUSE_INFO
    {
        public decimal RETURN_CAUSE_ID { get; set; }
        public string? RETURN_CAUSE_CODE { get; set; }
        public string? RETURN_CAUSE_NAME { get; set; }
        public string? STATUS { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
