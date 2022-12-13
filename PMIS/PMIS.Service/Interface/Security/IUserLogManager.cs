using PMIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.Security.Security
{
    public interface IUserLogManager
    {
        Task<string> LoadData( string companyId);
        Task<string> Search( int companyId, SearchModel model);
        Task<string> AddOrUpdate( string activity_type, string activity_table, int CompanyId, int UnitId, int UserId, string terminal, string page_link, int tran_id, string dtl);
    }
}
