using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class UserLog
    {
        public decimal LogId { get; set; }
        public DateTime? LogDate { get; set; }
        public decimal? UserId { get; set; }
        public string? UserTerminal { get; set; }
        public string? ActivityType { get; set; }
        public string? ActivityTable { get; set; }
        public decimal? TransactionId { get; set; }
        public string? PageRef { get; set; }
        public string? Location { get; set; }
        public string? Dtl { get; set; }
        public decimal? CompanyId { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
        public decimal? UnitId { get; set; }

        public virtual UserInfo? User { get; set; }
    }
}
