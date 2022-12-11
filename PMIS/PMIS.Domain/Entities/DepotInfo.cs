using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class DepotInfo
    {
        public decimal? DepotId { get; set; }
        public string? DepotCode { get; set; }
        public string? DepotName { get; set; }
        public string? DepotShortName { get; set; }
        public string? DepotAddress { get; set; }
        public string? Status { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
