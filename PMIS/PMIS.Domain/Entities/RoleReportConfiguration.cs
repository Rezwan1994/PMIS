using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class RoleReportConfiguration
    {
        public decimal? Id { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? ReportId { get; set; }
        public string? PreviewPermission { get; set; }
        public string? CsvPermission { get; set; }
        public string? PdfPermission { get; set; }
        public decimal? CompanyId { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
