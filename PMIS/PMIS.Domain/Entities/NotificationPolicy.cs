using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class NotificationPolicy
    {
        public decimal NotificationPolicyId { get; set; }
        public string? NotificationTitle { get; set; }
        public string? Status { get; set; }
        public decimal? CompanyId { get; set; }
        public decimal? UnitId { get; set; }
    }
}
