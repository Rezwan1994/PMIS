using System;
using System.Collections.Generic;

namespace PMIS.Domain.Entities
{
    public partial class EMPLOYEE_INFO
    {
        public EMPLOYEE_INFO()
        {
            USER_INFOs = new HashSet<USER_INFO>();
        }

        public int EMPLOYEE_ID { get; set; }
        public string? EMPLOYEE_CODE { get; set; }
        public string EMPLOYEE_NAME { get; set; } = null!;
        public string? EMPLOYEE_STATUS { get; set; }
        public int? COMPANY_ID { get; set; }

        public virtual ICollection<USER_INFO> USER_INFOs { get; set; }
    }
}
