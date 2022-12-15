using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.Security
{
    public interface IMenuMasterService
    {
        string LoadData(int companyId);
        Task<string> AddOrUpdate(MENU_CONFIGURATION model);
        Task<string> ActivateMenu( int id);
        Task<string> DeactivateMenu(int id);
        Task<string> DeleteMenu(int id);
    }
}
