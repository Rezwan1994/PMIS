using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class TransferMst
    {
        public decimal? MstId { get; set; }
        public string? RefNo { get; set; }
        public DateTime? RefDate { get; set; }
        public string? TransferDepotCode { get; set; }
        public string? TransferNo { get; set; }
        public DateTime? TransferDate { get; set; }
        public string? ReceiveDepotCode { get; set; }
        public string? PmCategoryCode { get; set; }
        public string? Remarks { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
