using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class MODULE_INFO
    {
        public MODULE_INFO()
        {
            MENU_CONFIGURATIONs = new HashSet<MENU_CONFIGURATION>();
        }

        public decimal MODULE_ID { get; set; }
        public string? MODULE_NAME { get; set; }
        public string? STATUS { get; set; }
        public decimal? ORDER_BY_NO { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }

        public virtual ICollection<MENU_CONFIGURATION> MENU_CONFIGURATIONs { get; set; }
    }
}
