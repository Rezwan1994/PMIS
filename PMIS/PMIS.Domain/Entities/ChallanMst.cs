using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ChallanMst
    {
        public decimal? MstId { get; set; }
        public string? DepotCode { get; set; }
        public string? YearCode { get; set; }
        public string? MonthCode { get; set; }
        public string? AllocationNo { get; set; }
        public string? ChallanNo { get; set; }
        public DateTime? ChallanDate { get; set; }
        public string? AllocationType { get; set; }
        public string? LocationType { get; set; }
        public string? LocationCode { get; set; }
        public string? LocationEcode { get; set; }
        public string? Remarks { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
