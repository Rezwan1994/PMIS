using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Domain.Entities
{
    public partial class ROLE_USER_CONFIGURATION
    {
        [NotMapped]
        public string? ROLE_NAME { get; set; }
        [NotMapped]
        public string? IS_PERMITTED { get; set; }
        [NotMapped]
        public int USER_CONFIG_ID { get; set; }
        [NotMapped]
        public int ROW_NO { get; set; }
    }
}
