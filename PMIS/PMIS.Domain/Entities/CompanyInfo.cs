using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class CompanyInfo
    {
        public decimal? CompanyId { get; set; }
        public string? CompanyCode { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyShortName { get; set; }
        public string? CompanyAddress1 { get; set; }
        public string? CompanyAddress2 { get; set; }
        public string? Status { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
