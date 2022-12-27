using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ROLE_MENU_CONFIGURATION
    {
        public decimal ID { get; set; }
        public decimal? ROLE_ID { get; set; }
        public decimal? MENU_ID { get; set; }
        public string? LIST_VIEW { get; set; }
        public string? ADD_PERMISSION { get; set; }
        public string? EDIT_PERMISSION { get; set; }
        public string? DELETE_PERMISSION { get; set; }
        public string? DETAIL_VIEW { get; set; }
        public string? DOWNLOAD_PERMISSION { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
        public string? CONFIRM_PERMISSION { get; set; }

        public virtual MENU_CONFIGURATION? MENU { get; set; }
        public virtual ROLE_INFO? ROLE { get; set; }

        public int ROLE_CONFIG_ID { get; set; }
    }
}
