using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class RoleInfo
    {
        public RoleInfo()
        {
            RoleMenuConfigurations = new HashSet<RoleMenuConfiguration>();
            RoleUserConfigurations = new HashSet<RoleUserConfiguration>();
        }

        public decimal RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Status { get; set; }
        public decimal? CompanyId { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
        public decimal? UnitId { get; set; }

        public virtual ICollection<RoleMenuConfiguration> RoleMenuConfigurations { get; set; }
        public virtual ICollection<RoleUserConfiguration> RoleUserConfigurations { get; set; }
    }
}
