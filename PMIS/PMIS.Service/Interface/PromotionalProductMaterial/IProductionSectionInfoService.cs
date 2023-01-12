using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.PromotionalProductMaterial
{

    public interface IProductionSectionInfoService : IBaseService<PRODUCTION_SECTION_INFO>
    {
        Task<string> GetProductionSectionCode();
    }


}
