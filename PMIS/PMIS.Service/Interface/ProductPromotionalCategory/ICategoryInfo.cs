using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.ProductPromotionalCategory
{
    public interface ICategoryInfo
    {
        Task<string> AddOrUpdate(EMPLOYEE_INFO model);
        Task<string> GetEmployeeList();
    }
}
