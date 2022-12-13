using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class NOTIFICATION
    {
        public int USER_ID { get; set; }
        public int ID { get; set; }
        public decimal NOTIFICATION_ID { get; set; }
        public int NOTIFICATION_POLICY_ID { get; set; }
        public string? NOTIFICATION_TITLE { get; set; }
        public string? NOTIFICATION_BODY { get; set; }
        public DateTime? NOTIFICATION_DATE { get; set; }
        public string? STATUS { get; set; }
        public int COMPANY_ID { get; set; }
        public int UNIT_ID { get; set; }
    }
}
