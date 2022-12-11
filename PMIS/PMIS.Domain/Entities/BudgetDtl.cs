using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class BudgetDtl
    {
        public decimal? DtlId { get; set; }
        public decimal? MstId { get; set; }
        public string? Sbu { get; set; }
        public string? PmCategoryCode { get; set; }
        public string? DepotCode { get; set; }
        public string? UnitCode { get; set; }
        public string? ProductionUnitCode { get; set; }
        public string? PmCode { get; set; }
        public decimal? BudgetQuantity { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
