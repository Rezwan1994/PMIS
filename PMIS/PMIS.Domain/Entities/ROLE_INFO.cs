﻿using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ROLE_INFO
    {
        public ROLE_INFO()
        {
            ROLE_MENU_CONFIGURATIONs = new HashSet<ROLE_MENU_CONFIGURATION>();
            ROLE_USER_CONFIGURATIONs = new HashSet<ROLE_USER_CONFIGURATION>();
        }

        public decimal ROLE_ID { get; set; }
        public string? ROLE_NAME { get; set; }
        public string? STATUS { get; set; }
        public decimal? COMPANY_ID { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
        public decimal? UNIT_ID { get; set; }

        public virtual ICollection<ROLE_MENU_CONFIGURATION> ROLE_MENU_CONFIGURATIONs { get; set; }
        public virtual ICollection<ROLE_USER_CONFIGURATION> ROLE_USER_CONFIGURATIONs { get; set; }
    }
}