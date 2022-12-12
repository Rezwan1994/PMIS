using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class USER_INFO
    {
        public USER_INFO()
        {
            MENU_USER_CONFIGURATIONs = new HashSet<MENU_USER_CONFIGURATION>();
            ROLE_USER_CONFIGURATIONs = new HashSet<ROLE_USER_CONFIGURATION>();
            USER_LOGs = new HashSet<USER_LOG>();
        }

        public decimal USER_ID { get; set; }
        public string? USER_NAME { get; set; }
        public string? USER_TYPE { get; set; }
        public string? USER_PASSWORD { get; set; }
        public string? EMAIL { get; set; }
        public decimal EMPLOYEE_ID { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public decimal? UNIT_ID { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
        public string? UNIQUEACCESSKEY { get; set; }
        public string? STATUS { get; set; }

        public virtual EMPLOYEE_INFO EMPLOYEE { get; set; } = null!;
        public virtual ICollection<MENU_USER_CONFIGURATION> MENU_USER_CONFIGURATIONs { get; set; }
        public virtual ICollection<ROLE_USER_CONFIGURATION> ROLE_USER_CONFIGURATIONs { get; set; }
        public virtual ICollection<USER_LOG> USER_LOGs { get; set; }
    }
}
