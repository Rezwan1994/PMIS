using PMIS.Domain.Entities;

namespace PMIS.Service.Interface.Security.Security
{
    public interface IUserMenuConfigManager
    {
        Task<string> GetSearchableUsers(string db, int companyId, string user_name);

        Task<string> GetSearchableCentralUsers(string db, string user_Name);

        Task<string> UserMenuConfigSelectionList(string db, int companyId, int roleId);

        Task<string> AddUserMenuConfiguration(string db, List<MenuUserConfiguration> model);
    }
}