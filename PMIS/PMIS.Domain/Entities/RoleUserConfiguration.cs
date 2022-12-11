using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class RoleUserConfiguration
    {
        public decimal Id { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? UserId { get; set; }
        public string? PermittedBy { get; set; }
        public DateTime? PermiteDate { get; set; }
        public decimal? CompanyId { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }

        public virtual RoleInfo? Role { get; set; }
        public virtual UserInfo? User { get; set; }
    }
}
