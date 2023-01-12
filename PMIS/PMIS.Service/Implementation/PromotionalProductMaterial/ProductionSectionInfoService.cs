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
    public class ProductionSectionInfoService : BaseService<PRODUCTION_SECTION_INFO>, IProductionSectionInfoService
    {

        private readonly ICommonServices _commonService;


        public ProductionSectionInfoService(IUnitOfWork unitOfWork, ICommonServices commonService) : base(unitOfWork)
        {
            _commonService = commonService;
        }


        public Task<string> GetProductionSectionCode()
        {
            return Task.FromResult(_commonService.GetMaximumNumber<string>("select FN_GENERATE_SECTION_CODE from dual", _commonService.AddParameter(new string[] { })));
        }

    }
}
