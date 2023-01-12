using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.PromotionalProductMaterial
{
    public interface ISupplierInfoService:IBaseService<SUPPLIER_INFO>
    {
        public Task<string> GetSupplierCode();
    }
}
