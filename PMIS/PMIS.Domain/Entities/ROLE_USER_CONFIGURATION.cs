using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ROLE_USER_CONFIGURATION
    {
        public int ID { get; set; }
        public int ROLE_ID { get; set; }
        public int USER_ID { get; set; }
        public string? PERMITTED_BY { get; set; }
        public DateTime? PERMITE_DATE { get; set; }
        public int? COMPANY_ID { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }

        public virtual ROLE_INFO ROLE { get; set; } = null!;
    }
}
