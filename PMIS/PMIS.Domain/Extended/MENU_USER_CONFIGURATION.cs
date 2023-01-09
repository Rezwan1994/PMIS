using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Domain.Entities
{
    public partial class MENU_USER_CONFIGURATION
    {
        [NotMapped]
        public int USER_CONFIG_ID { get; set; }
    }
}
