using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ReportConfiguration
    {
        public decimal? ReportId { get; set; }
        public string? ReportName { get; set; }
        public decimal? MenuId { get; set; }
        public decimal? OrderBySlno { get; set; }
        public decimal? CompanyId { get; set; }
        public string? Status { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
        public string? ReportTitle { get; set; }
        public string? HasPreview { get; set; }
        public string? HasPdf { get; set; }
        public string? HasCsv { get; set; }
    }
}
