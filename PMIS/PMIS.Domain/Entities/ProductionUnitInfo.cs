using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ProductionUnitInfo
    {
        public decimal? ProductionUnitId { get; set; }
        public string? ProductionUnitCode { get; set; }
        public string? ProductionUnitName { get; set; }
        public string? UnitCode { get; set; }
        public string? Status { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
