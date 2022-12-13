using PMIS.Domain.Common;
using PMIS.Domain.Entities;
using PMIS.Domain.ViewModels.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.Security
{
    public interface IUserManager
    {
        Auth GetUserByEmailAndCompany(string Email, int CompanyId);

        Auth GetUserByEmail(string Email);
        int GetCompanyIdByUserId(int userId);

        bool IsValidUser(string Email, string password, int CompanyId, string HashPass);
        string GetUserByCompanyJsonList(string Company);
        Task<string> AddOrUpdate(USER_INFO model, string ServerPath);
        string GetUsers();
        string GetEmployeesWithoutAccount(int CompanyId);
        DataTable GetUsersByCompanyDataTable(int CompanyId);
        string GetUsersByCompany(int CompanyId);

        Task<string> LoadSearchableDefaultPages(int companyId, string defaultpage);
        Task<string> LoadDefaultPages(int companyId);
        Task<string> AddOrUpdateDefaultPage(USER_DEFAULT_PAGE model);
        Task<string> UpdateUserPassword(PasswordChangeModel changeModel);
        USER_INFO IsVerified(string UniquKey);
        Task<string> ForgetPasswordVerify(PasswordChangeModel changeModel);
    }
}
