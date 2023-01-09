using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class NOTIFICATION_VIEW_POLICY
    {
        public int ID { get; set; }
        public int? NOTIFICATION_POLICY_ID { get; set; }
        public string? STATUS { get; set; }
        public int? COMPANY_ID { get; set; }
        public int? UNIT_ID { get; set; }
        public int? USER_ID { get; set; }
        public string? VIEW_PERMISSION { get; set; }
    }
}
