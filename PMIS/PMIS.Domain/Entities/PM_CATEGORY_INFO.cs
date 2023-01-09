﻿using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class PM_CATEGORY_INFO
    {
        public int PM_CATEGORY_ID { get; set; }
        public string? PM_CATEGORY_CODE { get; set; }
        public string? PM_CATEGORY_NAME { get; set; }
        public string? STATUS { get; set; }
        public string? REMARKS { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
