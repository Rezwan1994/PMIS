using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class TransferDtl
    {
        public decimal? DtlId { get; set; }
        public decimal? MstId { get; set; }
        public string? TransferDepotCode { get; set; }
        public DateTime? TransferDate { get; set; }
        public string? PmCategoryCode { get; set; }
        public string? PmCode { get; set; }
        public decimal? BatchId { get; set; }
        public string? BatchNo { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TransferQty { get; set; }
        public decimal? TransferAmount { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
