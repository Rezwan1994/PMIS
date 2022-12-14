using PMIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Repository.Interface
{
    public interface ICommonServices
    {
        QueryPattern AddQuery(string query, Dictionary<string, string> parametes);

        string DataTableToJSON(DataTable table);

        string DataSetToJSON(DataSet ds);

        DataRow GetDataRow(string query, Dictionary<string, string> param = null);
        DataRow GetDataRow(string conString, string query, Dictionary<string, string> param = null);

        DataSet GetDataSet(string query, Dictionary<string, string> param);
        DataSet GetDataSet(string connString, string query, Dictionary<string, string> param);

        DataTable GetDataTable(string query, Dictionary<string, string> param = null);
        DataTable GetDataTable(string conString, string query, Dictionary<string, string> param = null);

        T GetMaxNumNonParaQuery<T>(string conneString, string query);
        T GetMaxNumNonParaQuery<T>(string query);

        T GetMaximumNumber<T>(string query, Dictionary<string, string> param);
        T GetMaximumNumber<T>(string conneString, string query, Dictionary<string, string> param);

        bool SaveChanges(List<QueryPattern> queryPatterns);
        bool SaveChanges(string conString, List<QueryPattern> queryPatterns);

        Dictionary<string, string> AddParameter(string[] values);

        Task<DataTable> GetDataTableAsyn(string query, Dictionary<string, string> param = null);
        Task<DataTable> GetDataTableAsyn(string connString, string query, Dictionary<string, string> param = null);

        Task<T> ProcedureCallAsyn<T>(string query, Dictionary<string, string> param = null);
        Task<T> ProcedureCallAsyn<T>(string connString, string query, Dictionary<string, string> param = null);

        Task<T> PreExecuteProcedureCallAsyn<T>(string query, Dictionary<string, string> param = null);
        Task<T> PreExecuteProcedureCallAsyn<T>(string connString, string query, Dictionary<string, string> param = null);

        Task<DataSet> GetDataSetAsyn(string query, Dictionary<string, string> param);
        Task<DataSet> GetDataSetAsyn(string connString, string query, Dictionary<string, string> param);

        Task<DataRow> GetDataRowAsyn(string query, Dictionary<string, string> param = null);
        Task<DataRow> GetDataRowAsyn(string connString, string query, Dictionary<string, string> param = null);

        Task<bool> SaveChangesAsyn(List<QueryPattern> queryPatterns);
        Task<bool> SaveChangesAsyn(string connString, List<QueryPattern> queryPatterns);

        Task<T> GetMaxNumNonParaQueryAsyn<T>(string query);
        Task<T> GetMaxNumNonParaQueryAsyn<T>(string connString, string query);

        Task<T> GetMaximumNumberAsyn<T>(string query, Dictionary<string, string> param);
        Task<T> GetMaximumNumberAsyn<T>(string connString, string query, Dictionary<string, string> param);

        string ReturnExtension(string fileExtension);
        bool DataSave(string connString, string query, Dictionary<string, string> param = null);
        string Encrypt(string pstrText);
        string Decrypt(string pstrText);
        List<T> ConvertDataTableToList<T>(DataTable dt);
        DataTable ListToDataTable<T>(List<T> items);
    }
}
