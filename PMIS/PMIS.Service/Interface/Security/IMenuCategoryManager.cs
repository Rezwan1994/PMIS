using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesAndDistributionSystem.Services.Business.Security
{
    public interface IMenuCategoryManager
    {
        string LoadData(string db,int companyId);
        Task<string> AddOrUpdate(string db, ModuleInfo model);
        Task<string> ActivateMenuCategory(string db, int id);
        Task<string> DeactivateMenuCategory(string db, int id);
        Task<string> DeleteMenuCategory(string db, int id);

    }
}
