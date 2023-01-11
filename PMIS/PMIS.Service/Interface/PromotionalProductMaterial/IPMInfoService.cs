using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.PromotionalProductMaterial
{
    public interface IPMInfoService : IBaseService<PROMOTIONAL_MATERIAL_INFO>
    {
        Task<string> GetPMCode();
    }
}
