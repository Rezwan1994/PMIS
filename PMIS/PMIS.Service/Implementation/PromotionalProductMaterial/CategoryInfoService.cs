using PMIS.Domain.Entities;
using PMIS.Repository;
using PMIS.Repository.Interface;
using PMIS.Repository.Interface.PromotionalProductMaterial;
using PMIS.Repository.UnitOfWork;
using PMIS.Service.Interface.PromotionalProductMaterial;
using PMIS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Implementation.PromotionalProductMaterial
{
    public class CategoryInfoService : BaseService<PM_CATEGORY_INFO>, ICategoryInfoService
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly ICategoryInfoRepository _categoryRepository;
        public CategoryInfoService(IUnitOfWork unitOfWork): base(unitOfWork)
        {
            //this._unitOfWork = unitOfWork;
            //this._categoryRepository = unitOfWork.ICategoryInfoRepository;
        }
    }
}
