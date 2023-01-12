using PMIS.Domain.Entities;
using PMIS.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.PromotionalProductMaterial
{
    public interface IReturnCauseService: IBaseService<RETURN_CAUSE_INFO>
    {
        public Task<string> GetCode();
    }
}
