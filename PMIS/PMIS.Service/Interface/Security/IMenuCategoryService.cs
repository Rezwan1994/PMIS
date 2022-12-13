using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.Security
{
    public interface IMenuCategoryService
    {
        string LoadData(int companyId);
        Task<string> AddOrUpdate(MODULE_INFO model);
        Task<string> ActivateMenuCategory(int id);
        Task<string> DeactivateMenuCategory(int id);
        Task<string> DeleteMenuCategory(int id);
    }
}
