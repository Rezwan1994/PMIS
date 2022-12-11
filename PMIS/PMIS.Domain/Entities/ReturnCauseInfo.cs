using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ReturnCauseInfo
    {
        public decimal ReturnCauseId { get; set; }
        public string? ReturnCauseCode { get; set; }
        public string? ReturnCauseName { get; set; }
        public string? Status { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
