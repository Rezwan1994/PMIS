using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ReceiveMst
    {
        public decimal? MstId { get; set; }
        public string? ReceiveType { get; set; }
        public string? YearCode { get; set; }
        public string? MonthCode { get; set; }
        public string? BudgetNo { get; set; }
        public string? DepotCode { get; set; }
        public string? ReceiveNo { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string? SupplierCode { get; set; }
        public string? PoNo { get; set; }
        public DateTime? PoDate { get; set; }
        public string? ChallanNo { get; set; }
        public DateTime? ChallanDate { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
