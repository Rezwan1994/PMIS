using PMIS.Domain.Entities;

namespace PMIS.Service.Interface.Security
{
    public interface IUserMenuConfigService
    {
        Task<string> GetSearchableUsers(int companyId, string user_name);

        Task<string> GetSearchableCentralUsers( string user_Name);

        Task<string> UserMenuConfigSelectionList( int companyId, int roleId);

        Task<string> AddUserMenuConfiguration( List<MENU_USER_CONFIGURATION> model);
    }
}