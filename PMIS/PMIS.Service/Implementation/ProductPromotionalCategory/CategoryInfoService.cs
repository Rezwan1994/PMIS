using PMIS.Domain.Entities;
using PMIS.Repository;
using PMIS.Repository.Interface;
using PMIS.Repository.Interface.ProductPromotionalMaterial;
using PMIS.Repository.UnitOfWork;
using PMIS.Service.Interface.ProductPromotionalCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Implementation.ProductPromotionalCategory
{
    internal class CategoryInfoService : ICategoryInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryInfoRepository _categoryRepository;
        public CategoryInfoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._categoryRepository = unitOfWork.ICategoryInfoRepository;
        }
        public void AddOrUpdate(PM_CATEGORY_INFO model)
        {
            _categoryRepository.Add(model);
        }

        public Task<string> AddOrUpdate(EMPLOYEE_INFO model)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmployeeList()
        {
            throw new NotImplementedException();
        }
    }
}
