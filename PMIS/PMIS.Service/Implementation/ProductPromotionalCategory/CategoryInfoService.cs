using PMIS.Domain.Entities;
using PMIS.Repository;
using PMIS.Repository.Interface;
using PMIS.Repository.Interface.ProductPromotionalMaterial;
using PMIS.Repository.UnitOfWork;
using PMIS.Service.Interface;
using PMIS.Service.Interface.ProductPromotionalCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Implementation.ProductPromotionalCategory
{
    internal class CategoryInfoService : BaseService<PM_CATEGORY_INFO>, ICategoryInfoService
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
