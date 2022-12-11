using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesAndDistributionSystem.Services.Business.Security
{
    public interface IRoleManager
    {
        string LoadData(string db, int companyId);
        Task<string> AddOrUpdate(string db, RoleInfo model);
        Task<string> ActivateRole(string db, int id);
        Task<string> DeactivateRole(string db, int id);
        Task<string> GetSearchableRoles(string db, int companyId, string roleName);

        Task<string> RoleMenuConfigSelectionList(string db, int companyId, int roleId);
        Task<string> AddRoleMenuConfiguration(string db, List<RoleMenuConfiguration> model);
        Task<string> RoleUserConfigSelectionList(string db, int companyId, int userId);
        Task<string> RoleCentralUserConfigSelectionList(string db, int userId);
        Task<string> AddRoleUserConfiguration(string db, List<RoleUserConfiguration> model);
    }
}
