using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class AllocationDtl
    {
        public decimal? DtlId { get; set; }
        public decimal? MstId { get; set; }
        public string? PmCategoryCode { get; set; }
        public string? PmCode { get; set; }
        public decimal? AllocationQty { get; set; }
        public string? Status { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
