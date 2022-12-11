using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class AllocationMst
    {
        public decimal? MstId { get; set; }
        public string? YearCode { get; set; }
        public string? MonthCode { get; set; }
        public string? ProductGroup { get; set; }
        public string? MarketGroup { get; set; }
        public string? MarketCode { get; set; }
        public string? TerritoryCode { get; set; }
        public string? RegionCode { get; set; }
        public string? DivisionCode { get; set; }
        public string? DepotCode { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
