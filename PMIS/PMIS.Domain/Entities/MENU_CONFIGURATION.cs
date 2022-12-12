using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class MENU_CONFIGURATION
    {
        public MENU_CONFIGURATION()
        {
            MENU_USER_CONFIGURATIONs = new HashSet<MENU_USER_CONFIGURATION>();
            ROLE_MENU_CONFIGURATIONs = new HashSet<ROLE_MENU_CONFIGURATION>();
        }

        public decimal MENU_ID { get; set; }
        public string? MENU_NAME { get; set; }
        public decimal? PARENT_MENU_ID { get; set; }
        public decimal? MODULE_ID { get; set; }
        public string? CONTROLLER { get; set; }
        public string? ACTION { get; set; }
        public string? HREF { get; set; }
        public decimal? ORDER_BY_SLNO { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public string? STATUS { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
        public string? AREA { get; set; }
        public string? MENU_SHOW { get; set; }

        public virtual MODULE_INFO? MODULE { get; set; }
        public virtual ICollection<MENU_USER_CONFIGURATION> MENU_USER_CONFIGURATIONs { get; set; }
        public virtual ICollection<ROLE_MENU_CONFIGURATION> ROLE_MENU_CONFIGURATIONs { get; set; }
    }
}
