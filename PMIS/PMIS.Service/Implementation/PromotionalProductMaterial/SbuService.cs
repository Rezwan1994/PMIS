using PMIS.Domain.Entities;
using PMIS.Repository.UnitOfWork;
using PMIS.Service.Interface.PromotionalProductMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Implementation.PromotionalProductMaterial
{
    public class SbuService : BaseService<SBU_INFO>,ISbuService
    {
        public SbuService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            //this._unitOfWork = unitOfWork;
            //this._categoryRepository = unitOfWork.ICategoryInfoRepository;
      
        }
    }
}
