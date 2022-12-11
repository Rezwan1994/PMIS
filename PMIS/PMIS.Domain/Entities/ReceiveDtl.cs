using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ReceiveDtl
    {
        public decimal? DtlId { get; set; }
        public decimal? MstId { get; set; }
        public string? DepotCode { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string? Sbu { get; set; }
        public string? PmCategoryCode { get; set; }
        public string? ProductionUnitCode { get; set; }
        public string? PmCode { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? BudgetQuantity { get; set; }
        public decimal? StockTransferOrderQuantity { get; set; }
        public decimal? ReceivedQuantity { get; set; }
        public decimal? ReceiveAmount { get; set; }
        public decimal? FromSurplusQuantity { get; set; }
        public decimal? DuePartDueExcessQuantity { get; set; }
        public string? NoOfSlot { get; set; }
        public decimal? BatchId { get; set; }
        public string? BatchNo { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
