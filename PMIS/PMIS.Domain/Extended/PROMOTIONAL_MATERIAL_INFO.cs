using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Domain.Extended
{
    public partial class PROMOTIONAL_MATERIAL_INFO
    {
        [NotMapped]
        public string? PM_CATEGORY_NAME { get; set; }
    }
}
