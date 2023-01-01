using PMIS.Domain.Common;
using PMIS.Domain.Entities;
using PMIS.Domain.ViewModels.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.Security
{
    public interface IReportConfigurationService
    {
        Task<string> LoadData(int companyId);
        Task<string> GetReturnInvoiceNumbers(ReportParams reportParams);
        Task<string> AddOrUpdate(REPORT_CONFIGURATION model);
        Task<string> ActivateReport(int id);
        Task<string> DeactivateReport(int id);

        //Role Report Configuration-----------------------------------------------------------
        Task<string> GetSearchableRoles(int companyId, string role_name);

        Task<string> RoleReportConfigSelectionList(int companyId, int roleId);
        Task<string> AddRoleReportConfiguration(List<ROLE_REPORT_CONFIGURATION> model);
      
        
        //Report User Configuration-----------------------------
        Task<string> GetSearchableUsers(int companyId, string user_name);
        Task<string> GetSearchableCentralUsers(string user_Name);
        Task<string> UserReportConfigSelectionList(int companyId, int roleId);
        Task<string> AddUserReportConfiguration(List<REPORT_USER_CONFIGURATION> model);

        //Report Permission----------------------------------------
        Task<List<ReportPermission>> LoadReportPermissionData(int Company_Id, int User_Id);
        ReportPermission IsReportPermitted(int reportId, List<ReportPermission> permissions);
    }
}
