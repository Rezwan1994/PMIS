using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class PromotionalMaterialInfo
    {
        public decimal? PmId { get; set; }
        public string PmCode { get; set; } = null!;
        public string? PmName { get; set; }
        public string? PackSize { get; set; }
        public string? PmCategoryCode { get; set; }
        public string? Status { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
