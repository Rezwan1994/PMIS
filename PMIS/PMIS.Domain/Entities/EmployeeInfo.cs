using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class EmployeeInfo
    {
        public EmployeeInfo()
        {
            UserInfos = new HashSet<UserInfo>();
        }

        public decimal? Id { get; set; }
        public decimal EmployeeId { get; set; }
        public string? EmployeeCode { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string? EmployeeStatus { get; set; }
        public decimal? CompanyId { get; set; }
        public decimal? UnitId { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
