using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class NOTIFICATION_VIEW
    {
        public int ID { get; set; }
        public int? NOTIFICATION_ID { get; set; }
        public string? USER_ID { get; set; }
        public string? STATUS { get; set; }
        public int? COMPANY_ID { get; set; }
        public int? UNIT_ID { get; set; }
        public DateTime? VIEW_DATE { get; set; }
    }
}
