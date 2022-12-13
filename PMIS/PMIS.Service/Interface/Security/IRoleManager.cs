using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.Security
{
    public interface IRoleManager
    {
        string LoadData(int companyId);
        Task<string> AddOrUpdate(ROLE_INFO model);
        Task<string> ActivateRole(int id);
        Task<string> DeactivateRole(int id);
        Task<string> GetSearchableRoles(int companyId, string roleName);

        Task<string> RoleMenuConfigSelectionList(int companyId, int roleId);
        Task<string> AddRoleMenuConfiguration(List<ROLE_MENU_CONFIGURATION> model);
        Task<string> RoleUserConfigSelectionList(int companyId, int userId);
        Task<string> RoleCentralUserConfigSelectionList(int userId);
        Task<string> AddRoleUserConfiguration(List<ROLE_USER_CONFIGURATION> model);
    }
}
