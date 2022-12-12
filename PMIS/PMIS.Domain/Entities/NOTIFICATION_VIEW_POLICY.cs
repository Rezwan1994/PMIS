using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class NOTIFICATION_VIEW_POLICY
    {
        public decimal ID { get; set; }
        public decimal? NOTIFICATION_POLICY_ID { get; set; }
        public string? STATUS { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public decimal? UNIT_ID { get; set; }
        public decimal? USER_ID { get; set; }
        public string? VIEW_PERMISSION { get; set; }
    }
}
