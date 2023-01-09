using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using PMIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repository.Implementation
{
    public partial class CommonServices
    {
        private string connectionStr;
        private readonly IConfiguration connString;
        public CommonServices(IConfiguration connstring)
        {
            connString = connstring;
            connectionStr = connString.GetConnectionString(nameof(Domain.Entities.PMISDbContext));
        }

        public Task<T> ProcedureCallAsyn<T>(string query, Dictionary<string, string> param = null)
        {
            return ProcedureCallAsyn<T>(connectionStr, query, param);
        }

        public Task<T> PreExecuteProcedureCallAsyn<T>(string query, Dictionary<string, string> param = null)
        {
            return PreExecuteProcedureCallAsyn<T>(connectionStr, query, param);
        }

        public DataRow GetDataRow(string query, Dictionary<string, string> param = null)
        {
            return GetDataRow(connectionStr, query, param);
        }

        public DataSet GetDataSet(string query, Dictionary<string, string> param)
        {
            return GetDataSet(connectionStr, query, param);
        }

        public DataTable GetDataTable(string query, Dictionary<string, string> param = null)
        {
            return GetDataTable(connectionStr, query, param);
        }

        public Task<DataTable> GetDataTableAsyn(string query, Dictionary<string, string> param = null)
        {
            return GetDataTableAsyn(connectionStr, query, param);
        }
        public Task<DataSet> GetDataSetAsyn(string query, Dictionary<string, string> param)
        {
            return GetDataSetAsyn(connectionStr, query, param);
        }

        public Task<DataRow> GetDataRowAsyn(string query, Dictionary<string, string> param = null)
        {
            return GetDataRowAsyn(connectionStr, query, param);
        }

        public Task<bool> SaveChangesAsyn(List<QueryPattern> queryPatterns)
        {
            return SaveChangesAsyn(connectionStr, queryPatterns);
        }

        public T GetMaxNumNonParaQuery<T>(string query)
        {
            return GetMaxNumNonParaQuery<T>(connectionStr, query);
        }

        public T GetMaximumNumber<T>(string query, Dictionary<string, string> param)
        {
            return GetMaximumNumber<T>(connectionStr, query, param);
        }

        public bool SaveChanges(List<QueryPattern> queryPatterns)
        {
            return SaveChanges(connectionStr, queryPatterns);
        }

        public Task<T> GetMaxNumNonParaQueryAsyn<T>(string query)
        {
            return GetMaxNumNonParaQueryAsyn<T>(connectionStr, query);
        }

        public Task<T> GetMaximumNumberAsyn<T>(string query, Dictionary<string, string> param)
        {
            return GetMaximumNumberAsyn<T>(connectionStr, query, param);
        }
    }
}
