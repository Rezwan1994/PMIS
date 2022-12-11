using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class MenuConfiguration
    {
        public MenuConfiguration()
        {
            MenuUserConfigurations = new HashSet<MenuUserConfiguration>();
            RoleMenuConfigurations = new HashSet<RoleMenuConfiguration>();
        }

        public decimal MenuId { get; set; }
        public string? MenuName { get; set; }
        public decimal? ParentMenuId { get; set; }
        public decimal? ModuleId { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? Href { get; set; }
        public decimal? OrderBySlno { get; set; }
        public decimal? CompanyId { get; set; }
        public string? Status { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
        public string? Area { get; set; }
        public string? MenuShow { get; set; }

        public virtual ModuleInfo? Module { get; set; }
        public virtual ICollection<MenuUserConfiguration> MenuUserConfigurations { get; set; }
        public virtual ICollection<RoleMenuConfiguration> RoleMenuConfigurations { get; set; }
    }
}
