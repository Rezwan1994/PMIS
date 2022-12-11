using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class UnitInfo
    {
        public decimal UnitId { get; set; }
        public string? UnitCode { get; set; }
        public string? UnitName { get; set; }
        public string? UnitShortName { get; set; }
        public decimal? CompanyId { get; set; }
        public string? Status { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
