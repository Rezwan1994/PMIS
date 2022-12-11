using PMIS.Domain.Entities;
using PMIS.Repository.UnitOfWork;
using PMIS.Service.Interface.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Implementation.Security
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _UnitOfWork;


        //public PatientService(IPatientUnitOfWork patientUnitOfWork)
        //{
        //    _patientUnitOfWork = patientUnitOfWork;

        //}
        public Task<string> ActivateUnit(string db, int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddOrUpdate(string db, CompanyInfo model)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddOrUpdateUnit(string db, CompanyInfo model)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeactivateUnit(string db, int id)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyInfo> GetCompanyById(string db, int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCompanyJsonList(string db)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyInfo>> GetCompanyList(string db)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUnitByCompanyId(string db, int Company_Id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUnitInfo(string db, int companyId, int unitId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUnitJsonList(string db)
        {
            throw new NotImplementedException();
        }
    }
}
