using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class RoleMenuConfiguration
    {
        public decimal Id { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? MenuId { get; set; }
        public string? ListView { get; set; }
        public string? AddPermission { get; set; }
        public string? EditPermission { get; set; }
        public string? DeletePermission { get; set; }
        public string? DetailView { get; set; }
        public string? DownloadPermission { get; set; }
        public decimal? CompanyId { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
        public string? ConfirmPermission { get; set; }

        public virtual MenuConfiguration? Menu { get; set; }
        public virtual RoleInfo? Role { get; set; }
    }
}
