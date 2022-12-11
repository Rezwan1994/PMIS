using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repository.Interface.Security
{
    public interface ICompanyRepository 
    {
        Task<List<CompanyInfo>> GetCompanyList(string db);
        Task<CompanyInfo> GetCompanyById(string db, int id);
        Task<string> GetUnitInfo(string db, int companyId, int unitId);
        Task<string> AddOrUpdate(string db, CompanyInfo model);
        Task<string> GetCompanyJsonList(string db);
        Task<string> GetUnitJsonList(string db);
        Task<string> GetUnitByCompanyId(string db, int Company_Id);
        Task<string> AddOrUpdateUnit(string db, CompanyInfo model);
        Task<string> ActivateUnit(string db, int id);
        Task<string> DeactivateUnit(string db, int id);
    }
}
