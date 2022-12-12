using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class NOTIFICATION_VIEW
    {
        public decimal ID { get; set; }
        public decimal? NOTIFICATION_ID { get; set; }
        public string? USER_ID { get; set; }
        public string? STATUS { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public decimal? UNIT_ID { get; set; }
        public DateTime? VIEW_DATE { get; set; }
    }
}
