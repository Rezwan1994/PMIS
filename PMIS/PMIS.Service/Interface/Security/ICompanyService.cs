using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.Security
{
    public interface ICompanyService
    {
        Task<List<COMPANY_INFO>> GetCompanyList();
        Task<COMPANY_INFO> GetCompanyById(int id);
        Task<string> GetUnitInfo(int companyId, int unitId);
        Task<string> AddOrUpdate(COMPANY_INFO model);
        Task<string> GetCompanyJsonList();
        Task<string> GetUnitJsonList(int companyId);
        Task<string> GetUnitByCompanyId(int Company_Id);
        Task<string> AddOrUpdateUnit(DEPOT_INFO model);
        Task<string> ActivateUnit(int id);
        Task<string> DeactivateUnit(int id);
    }
}
