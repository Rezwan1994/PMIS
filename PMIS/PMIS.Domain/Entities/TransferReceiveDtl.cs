using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class TransferReceiveDtl
    {
        public decimal? DtlId { get; set; }
        public decimal? MstId { get; set; }
        public decimal? ReceiveDepotCode { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public decimal? PmCategoryCode { get; set; }
        public decimal? PmCode { get; set; }
        public decimal? BatchId { get; set; }
        public string? BatchNo { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TransferQty { get; set; }
        public decimal? TransferAmount { get; set; }
        public decimal? ReceiveQty { get; set; }
        public decimal? ReceiveAmount { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
