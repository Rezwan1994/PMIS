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
    public class DoctorCategoryService: BaseService<DOCTOR_CATEGORY_INFO>, IDoctorCategoryService
    {
        private readonly ICommonServices _commonService;
        public DoctorCategoryService(IUnitOfWork unitOfWork, ICommonServices commonService):base(unitOfWork)
        {
            _commonService = commonService;
        }

        public Task<string> GetCatCode()
        {
            return Task.FromResult(_commonService.GetMaximumNumber<string>("select FN_GENERATE_DOC_CAT_CODE from dual", _commonService.AddParameter(new string[] { })));
        }
    }
}
