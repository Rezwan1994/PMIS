using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class FIELD_FORCE
    {
        public int ID { get; set; }
        public string? EMPLOYEE_CODE { get; set; }
        public string? EMPLOYEE_NAME { get; set; }
        public string? DESIGNATION { get; set; }
        public string? PHONE_NO { get; set; }
        public string? EMAIL { get; set; }
        public DateTime? JOINING_DATE { get; set; }
        public string? JOINING_PLACE { get; set; }
        public string? DEPARTMENT_NAME { get; set; }
        public string? PRODUCT_GROUP_CODE { get; set; }
        public string? PRODUCT_GROUP_NAME { get; set; }
        public string? MARKET_GROUP_CODE { get; set; }
        public string? MARKET_GROUP_NAME { get; set; }
        public string? MARKET_CODE { get; set; }
        public string? MARKET_NAME { get; set; }
        public string? TERRITORY_CODE { get; set; }
        public string? TERRITORY_NAME { get; set; }
        public string? REGION_CODE { get; set; }
        public string? REGION_NAME { get; set; }
        public string? DIVISION_CODE { get; set; }
        public string? DIVISION_NAME { get; set; }
        public string? DEPOT_CODE { get; set; }
        public string? DEPOT_NAME { get; set; }
        public string? COMPANY_CODE { get; set; }
        public string? COMPANY_NAME { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
    }
}
