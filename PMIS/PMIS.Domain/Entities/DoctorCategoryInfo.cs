using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class DoctorCategoryInfo
    {
        public decimal? DoctorCategoryId { get; set; }
        public string? DoctorCategoryCode { get; set; }
        public string? DoctorCategoryName { get; set; }
        public string? Status { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}
