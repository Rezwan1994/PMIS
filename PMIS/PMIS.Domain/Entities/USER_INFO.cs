using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class USER_INFO
    {
        public int USER_ID { get; set; }
        public string? EMAIL { get; set; }
        public string? USER_PASSWORD { get; set; }
        public string? USER_TYPE { get; set; }
        public int EMPLOYEE_ID { get; set; }
        public string? USER_NAME { get; set; }
        public string? UNIQUEACCESSKEY { get; set; }
        public decimal? DEPOT_ID { get; set; }
        public int? COMPANY_ID { get; set; }
        public string? STATUS { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }

        public virtual EMPLOYEE_INFO EMPLOYEE { get; set; } = null!;
    }
}
