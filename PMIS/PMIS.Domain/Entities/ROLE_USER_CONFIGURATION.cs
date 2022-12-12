﻿using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ROLE_USER_CONFIGURATION
    {
        public decimal ID { get; set; }
        public decimal? ROLE_ID { get; set; }
        public decimal? USER_ID { get; set; }
        public string? PERMITTED_BY { get; set; }
        public DateTime? PERMITE_DATE { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }

        public virtual ROLE_INFO? ROLE { get; set; }
        public virtual USER_INFO? USER { get; set; }
    }
}
