﻿using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class NOTIFICATION
    {
        public decimal NOTIFICATION_ID { get; set; }
        public decimal? NOTIFICATION_POLICY_ID { get; set; }
        public string? NOTIFICATION_TITLE { get; set; }
        public string? NOTIFICATION_BODY { get; set; }
        public DateTime? NOTIFICATION_DATE { get; set; }
        public string? STATUS { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public decimal? UNIT_ID { get; set; }
    }
}
