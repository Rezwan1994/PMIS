using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class MENU_USER_CONFIGURATION
    {
        public int ID { get; set; }
        public int MENU_ID { get; set; }
        public int USER_ID { get; set; }
        public string? LIST_VIEW { get; set; }
        public string? ADD_PERMISSION { get; set; }
        public string? EDIT_PERMISSION { get; set; }
        public string? DELETE_PERMISSION { get; set; }
        public string? DETAIL_VIEW { get; set; }
        public string? DOWNLOAD_PERMISSION { get; set; }
        public int? COMPANY_ID { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
        public string? CONFIRM_PERMISSION { get; set; }

        public virtual MENU_CONFIGURATION MENU { get; set; } = null!;
    }
}
