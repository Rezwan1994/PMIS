using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class NotificationViewPolicy
    {
        public decimal Id { get; set; }
        public decimal? NotificationPolicyId { get; set; }
        public string? Status { get; set; }
        public decimal? CompanyId { get; set; }
        public decimal? UnitId { get; set; }
        public decimal? UserId { get; set; }
        public string? ViewPermission { get; set; }
    }
}
