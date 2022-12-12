﻿using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class USER_LOG
    {
        public decimal LOG_ID { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public decimal? USER_ID { get; set; }
        public string? USER_TERMINAL { get; set; }
        public string? ACTIVITY_TYPE { get; set; }
        public string? ACTIVITY_TABLE { get; set; }
        public decimal? TRANSACTION_ID { get; set; }
        public string? PAGE_REF { get; set; }
        public string? LOCATION { get; set; }
        public string? DTL { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
        public decimal? UNIT_ID { get; set; }

        public virtual USER_INFO? USER { get; set; }
    }
}
