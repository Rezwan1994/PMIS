using PMIS.Domain.Entities;
using PMIS.Repository.Interface;
using PMIS.Repository.UnitOfWork;
using PMIS.Service.Interface.PromotionalProductMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Implementation.PromotionalProductMaterial
{
    public class SupplierInfoService : BaseService<SUPPLIER_INFO>, ISupplierInfoService
    {
        private readonly ICommonServices _commonService;
        public SupplierInfoService(IUnitOfWork unitOfWork, ICommonServices commonService) : base(unitOfWork)
        {
            //this._unitOfWork = unitOfWork;
            //this._categoryRepository = unitOfWork.ICategoryInfoRepository;
            _commonService = commonService;

        }
        public Task<string> GetSupplierCode()
        {
            return Task.FromResult(_commonService.GetMaximumNumber<string>("select FN_GENERATE_SUPPLIER_CODE from dual", _commonService.AddParameter(new string[] { })));
        }
    }
}
