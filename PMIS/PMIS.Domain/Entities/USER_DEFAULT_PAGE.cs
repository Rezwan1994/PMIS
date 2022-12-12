using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class USER_DEFAULT_PAGE
    {
        public decimal ID { get; set; }
        public decimal? MENU_ID { get; set; }
        public decimal? USER_ID { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
