using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Domain.Entities
{
    public class SUPPLIER_INFO
    {
        public int SUPPLIER_ID { get; set; }
        public string? SUPPLIER_CODE { get; set; }
        public string? SUPPLIER_NAME { get; set; }
        public string? STATUS { get; set; }
        public string? REMARKS { get; set; }
        public string? ENTERED_BY { get; set; }
        public DateTime? ENTERED_DATE { get; set; }
        public string? ENTERED_TERMINAL { get; set; }
        public string? UPDATED_BY { get; set; }
        public DateTime? UPDATED_DATE { get; set; }
        public string? UPDATED_TERMINAL { get; set; }
    }
}
