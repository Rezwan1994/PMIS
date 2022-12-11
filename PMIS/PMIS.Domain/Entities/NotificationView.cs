using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class NotificationView
    {
        public decimal Id { get; set; }
        public decimal? NotificationId { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }
        public decimal? CompanyId { get; set; }
        public decimal? UnitId { get; set; }
        public DateTime? ViewDate { get; set; }
    }
}
