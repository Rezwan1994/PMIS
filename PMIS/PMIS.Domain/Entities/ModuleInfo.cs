using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class ModuleInfo
    {
        public ModuleInfo()
        {
            MenuConfigurations = new HashSet<MenuConfiguration>();
        }

        public decimal ModuleId { get; set; }
        public string? ModuleName { get; set; }
        public string? Status { get; set; }
        public decimal? OrderByNo { get; set; }
        public decimal? CompanyId { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }

        public virtual ICollection<MenuConfiguration> MenuConfigurations { get; set; }
    }
}
