using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ChallanReturnDtl
    {
        public decimal? DtlId { get; set; }
        public decimal? MstId { get; set; }
        public string? PmCategoryCode { get; set; }
        public string? PmCode { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitVat { get; set; }
        public decimal? BatchId { get; set; }
        public string? BatchNo { get; set; }
        public decimal ChallanQty { get; set; }
        public decimal ReturnQty { get; set; }
        public decimal? ReturnAmount { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
