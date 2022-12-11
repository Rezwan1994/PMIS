using PMIS.Domain.ViewModels.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.Security.Security
{
    public interface IMenuPermissionManager
    {
        Task<MenuDistribution> LoadPermittedMenuByUserId(string db, int id, int companyId);
        Task<List<PermittedMenu>> LoadLoadPermittedMenus(string db,  int companyId);

        string LoadUserDefaultPageById(string db, int User_Id);
        string SearchableMenuLoad(string db, string comp_id, string User_Id, string menu_name);
    }
}
