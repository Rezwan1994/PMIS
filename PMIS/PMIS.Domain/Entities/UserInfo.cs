using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            MenuUserConfigurations = new HashSet<MenuUserConfiguration>();
            RoleUserConfigurations = new HashSet<RoleUserConfiguration>();
            UserLogs = new HashSet<UserLog>();
        }

        public decimal UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserType { get; set; }
        public string? UserPassword { get; set; }
        public string? Email { get; set; }
        public decimal EmployeeId { get; set; }
        public decimal? CompanyId { get; set; }
        public decimal? UnitId { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
        public string? Uniqueaccesskey { get; set; }
        public string? Status { get; set; }

        public virtual EmployeeInfo Employee { get; set; } = null!;
        public virtual ICollection<MenuUserConfiguration> MenuUserConfigurations { get; set; }
        public virtual ICollection<RoleUserConfiguration> RoleUserConfigurations { get; set; }
        public virtual ICollection<UserLog> UserLogs { get; set; }
    }
}
