using PMIS.Domain.Entities;
using PMIS.Repository.Interface;
using PMIS.Repository.UnitOfWork;
using PMIS.Service.Interface.PromotionalProductMaterial;

namespace PMIS.Service.Implementation.PromotionalProductMaterial
{
    public class ReturnCauseService: BaseService<RETURN_CAUSE_INFO>, IReturnCauseService
    {
        private readonly ICommonServices _commonService;
        public ReturnCauseService(IUnitOfWork unitOfWork, ICommonServices commonService) : base(unitOfWork)
        {
            _commonService = commonService;
        }

        public Task<string> GetCode()
        {
            return Task.FromResult(_commonService.GetMaximumNumber<string>("select FN_GENERATE_RET_CAUSE_CODE from dual", _commonService.AddParameter(new string[] { })));
        }
    }
}
