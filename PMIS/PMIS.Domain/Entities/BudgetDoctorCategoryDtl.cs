﻿using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class BudgetDoctorCategoryDtl
    {
        public decimal? Id { get; set; }
        public decimal? DtlId { get; set; }
        public decimal? MstId { get; set; }
        public decimal? DoctoryCategoryCode { get; set; }
        public decimal? BudgetQuantity { get; set; }
        public string? EnteredBy { get; set; }
        public DateTime? EnteredDate { get; set; }
        public string? EnteredTerminal { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedTerminal { get; set; }
    }
}