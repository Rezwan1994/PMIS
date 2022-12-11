using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class BudgetMst
    {
        public decimal? MstId { get; set; }
        public string? BudgetNo { get; set; }
        public DateTime? BudgetDate { get; set; }
        public string? YearCode { get; set; }
        public string? MonthCode { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
