using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PMIS.Domain.Common;
using PMIS.Domain.Entities;
using PMIS.Repository.Interface;
using PMIS.Service.Interface.Security;
using PMIS.Utility.Static;
using System.ComponentModel.Design;
using System.Data;

namespace PMIS.Service.Implementation.Security
{
    public class CompanyService : ICompanyService
    {
        private readonly IConfiguration connString;
        private readonly ICommonServices _commonService;
        private readonly IConfiguration _configuration;

        public CompanyService(IConfiguration connstring, ICommonServices commonServices, IConfiguration configuration)
        {
            connString = connstring;
            _commonService = commonServices;
            _configuration = configuration;
        }

        private string GetCompanyListQuery() => "Select distinct  COMPANY_ADDRESS1,COMPANY_ADDRESS2,COMPANY_ID,COMPANY_NAME,COMPANY_SHORT_NAME from COMPANY_INFO";

        private string GetCompanyByIdQuery() => "Select distinct  COMPANY_ADDRESS1,COMPANY_ADDRESS2,COMPANY_ID,COMPANY_NAME,COMPANY_SHORT_NAME from COMPANY_INFO Where Company_ID = :param1";

        private string AddOrUpdateCompanyInsertQuery() => @"INSERT INTO COMPANY_INFO (
                                        COMPANY_ID
                                        ,COMPANY_NAME
                                        ,COMPANY_SHORT_NAME
                                        ,COMPANY_ADDRESS1
                                        ,COMPANY_ADDRESS2
                                       )
                                       VALUES ( :param1, :param2, :param3, :param4, :param5 )";

        private string AddOrUpdateCompanyUpdateQuery() => @"Update COMPANY_INFO Set COMPANY_NAME = :param1,COMPANY_SHORT_NAME  =:param2, COMPANY_ADDRESS1 =  :param3, COMPANY_ADDRESS2 = :param4 Where COMPANY_ID = :param5";

        private string GetNewCompanyIdQuery() => "SELECT NVL(MAX(COMPANY_ID),0) + 1 COMPANY_ID  FROM COMPANY_INFO";

        private string GetNewIdQuery() => "SELECT NVL(MAX(ID),0) + 1 ID  FROM COMPANY_INFO";

        public async Task<DataTable> GetCompanyListDataTable() => await _commonService.GetDataTableAsyn(GetCompanyListQuery(), _commonService.AddParameter(new string[] { }));

        public async Task<DataTable> GetCompanyByIdDataTable(int id) => await _commonService.GetDataTableAsyn(GetCompanyByIdQuery(), _commonService.AddParameter(new string[] { id.ToString() }));

        public async Task<string> GetCompanyJsonList() => _commonService.DataTableToJSON(await GetCompanyListDataTable());

        public async Task<List<COMPANY_INFO>> GetCompanyList()
        {
            DataTable companyData = await GetCompanyListDataTable();

            if (companyData != null && companyData.Rows.Count > 0)
            {
                List<COMPANY_INFO> company_Infos = new List<COMPANY_INFO>();
                foreach (DataRow row in companyData.Rows)
                {
                    COMPANY_INFO company = new COMPANY_INFO
                    {
                        COMPANY_ID = Convert.ToInt32(row["COMPANY_ID"]),
                        COMPANY_NAME = row["COMPANY_NAME"].ToString(),
                        COMPANY_SHORT_NAME = row["COMPANY_SHORT_NAME"].ToString(),
                        COMPANY_ADDRESS1 = row["COMPANY_ADDRESS1"].ToString(),
                        COMPANY_ADDRESS2 = row["COMPANY_ADDRESS2"].ToString()
                    };
                    company_Infos.Add(company);
                }

                return company_Infos;
            }
            return null;
        }

        public async Task<COMPANY_INFO> GetCompanyById(int id)
        {
            DataTable companyData = await GetCompanyByIdDataTable(id);

            if (companyData != null && companyData.Rows.Count > 0)
            {
                COMPANY_INFO company = new COMPANY_INFO
                {
                    COMPANY_ID = Convert.ToInt32(companyData.Rows[0]["COMPANY_ID"]),
                    COMPANY_NAME = companyData.Rows[0]["COMPANY_NAME"].ToString(),
                    COMPANY_SHORT_NAME = companyData.Rows[0]["COMPANY_SHORT_NAME"].ToString(),
                    COMPANY_ADDRESS1 = companyData.Rows[0]["COMPANY_ADDRESS1"].ToString(),
                    COMPANY_ADDRESS2 = companyData.Rows[0]["COMPANY_ADDRESS2"].ToString()
                };

                return company;
            }
            return null;
        }

        public async Task<string> AddOrUpdate(COMPANY_INFO model)
        {
            if (model == null)
            {
                return "No data provided to insert!!!!";
            }
            else
            {
                List<QueryPattern> listOfQuery = new List<QueryPattern>();
                try
                {
                    if (model.COMPANY_ID == 0)
                    {
                        model.STATUS = Status.InActive;
                        //model.ID = _commonService.GetMaximumNumber<int>(GetNewIdQuery(), _commonService.AddParameter(new string[] { }));
                        model.COMPANY_ID = _commonService.GetMaximumNumber<int>(GetNewCompanyIdQuery(), _commonService.AddParameter(new string[] { }));

                        //model.UNIT_ID = 0;

                        listOfQuery.Add(_commonService.AddQuery(AddOrUpdateCompanyInsertQuery(), _commonService.AddParameter(new string[]
                        {model.COMPANY_ID.ToString(), model.COMPANY_NAME.ToString(), model.COMPANY_SHORT_NAME,
                            model.COMPANY_ADDRESS1, model.COMPANY_ADDRESS2 })));
                    }
                    else
                    {
                        listOfQuery.Add(_commonService.AddQuery(AddOrUpdateCompanyUpdateQuery(),
                            _commonService.AddParameter(new string[] { model.COMPANY_NAME, model.COMPANY_SHORT_NAME,
                                model.COMPANY_ADDRESS1.ToString(), model.COMPANY_ADDRESS2, model.COMPANY_ID.ToString()
                            })));
                    }

                    await _commonService.SaveChangesAsyn(listOfQuery);
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        //-------------------------- Unit ---------------------------------------

        private string GetUnitListQuery() => @"SELECT DISTINCT DEPOT_ID, DEPOT_CODE, DEPOT_NAME, DEPOT_SHORT_NAME,DEPOT_ADDRESS,STATUS 
            FROM DEPOT_INFO
       ";

        private string GetUnitListByCompanyIdQuery() => "Select distinct ID, UNIT_ID, UNIT_ADDRESS1, UNIT_ADDRESS2, COMPANY_ID,COMPANY_NAME,UNIT_TYPE, UNIT_SHORT_NAME, UNIT_NAME,STATUS from COMPANY_INFO Where UNIT_ID!=0 AND COMPANY_ID = :param1";

        private string GetCompanyInfoByUnitIdQuery() => "SELECT * FROM COMPANY_INFO WHERE COMPANY_ID=:param1 and UNIT_ID=:param2";

        private string AddOrUpdateUnitInsertQuery() => @"INSERT INTO DEPOT_INFO (
                                         DEPOT_ID
                                        ,DEPOT_CODE
                                        ,DEPOT_NAME
                                        ,DEPOT_SHORT_NAME
                                        ,DEPOT_ADDRESS
                                        ,STATUS
                                        ,ENTERED_BY
                                        ,ENTERED_DATE
                                        ,ENTERED_TERMINAL
                                    
                                       )
                                       VALUES ( :param1, :param2, :param3, :param4, :param5 , :param6, :param7 ,TO_DATE(:param8, 'DD/MM/YYYY HH:MI:SS AM'), :param9 )";

        private string AddOrUpdateUnitUpdateLikeQuery() => @"Update DEPOT_INFO Set DEPOT_CODE = :param2,DEPOT_NAME  =:param3, DEPOT_SHORT_NAME =  :param4, DEPOT_ADDRESS = :param5, STATUS = :param6 Where  DEPOT_ID = :param1";

        private string AddOrUpdateUnitUpdateQuery() => @"Update DEPOT_INFO Set DEPOT_CODE = :param2,DEPOT_NAME  =:param3, DEPOT_SHORT_NAME =  :param4, DEPOT_ADDRESS = :param5, STATUS = :param6, ENTERED_BY = :param7, ENTERED_DATE = TO_DATE(:param8, 'DD/MM/YYYY HH:MI:SS AM'), ENTERED_TERMINAL = :param9 Where  DEPOT_ID = :param1";

        private string GetUpdatableCompanyQuery() => "Select distinct ID,  COMPANY_ADDRESS1,COMPANY_ADDRESS2,COMPANY_ID,COMPANY_NAME,COMPANY_SHORT_NAME from COMPANY_INFO Where Unit_ID = 0 AND COMPANY_ID = :param1";

        private string GetNewUnitIdQuery() => "SELECT NVL(MAX(DEPOT_ID),0) + 1 DEPOT_ID  FROM DEPOT_INFO";

        private string ActivateUnitQuery() => "Update DEPOT_INFO Set STATUS = 'Active' WHERE DEPOT_ID =  :param1";

        private string DeActivateUnitQuery() => "Update DEPOT_INFO Set STATUS = 'InActive' WHERE DEPOT_ID =  :param1";

        public async Task<DataTable> GetUnitListDataTable(int companyId) => await _commonService.GetDataTableAsyn(GetUnitListQuery(), _commonService.AddParameter(new string[] { companyId.ToString() }));

        public async Task<string> GetUnitJsonList(int companyId) => _commonService.DataTableToJSON(await GetUnitListDataTable(companyId));

        public async Task<string> GetUnitByCompanyId(int Company_Id)
        {
            DataTable dataTable = await _commonService.GetDataTableAsyn(GetUnitListByCompanyIdQuery(), _commonService.AddParameter(new string[] { Company_Id.ToString() }));

            return _commonService.DataTableToJSON(dataTable);
        }

        public async Task<string> GetUnitInfo(int companyId, int unitId)
        {
            var dt = await _commonService.GetDataTableAsyn(GetCompanyInfoByUnitIdQuery(), _commonService.AddParameter(new string[] { companyId.ToString(), unitId.ToString() }));
            return JsonConvert.SerializeObject(dt);
        }

        public async Task<DataTable> GetCompUpdatableDataTable(int companyId) => await _commonService.GetDataTableAsyn(GetUpdatableCompanyQuery(), _commonService.AddParameter(new string[] { companyId.ToString() }));

        public async Task<string> AddOrUpdateUnit(DEPOT_INFO model)
        {
            if (model == null)
            {
                return "No data provided to insert!!!!";

            }
            else
            {
                List<QueryPattern> listOfQuery = new List<QueryPattern>();
                try
                {
                   
                    if (model.DEPOT_ID == 0)
                    {
                            model.DEPOT_ID = _commonService.GetMaximumNumber<int>(GetNewUnitIdQuery(), _commonService.AddParameter(new string[] {  }));
                           
                            listOfQuery.Add((_commonService.AddQuery(AddOrUpdateUnitInsertQuery(), _commonService.AddParameter(new string[]
                            {
                             model.DEPOT_ID.ToString(),model.DEPOT_CODE,model.DEPOT_NAME.ToString(), model.DEPOT_SHORT_NAME.ToString(), model.DEPOT_ADDRESS,
                            model.STATUS, model.ENTERED_BY.ToString(), model.ENTERED_DATE.ToString(), model.ENTERED_TERMINAL.ToString()  }))));
                      

                    }
                    else
                    {
                        listOfQuery.Add(_commonService.AddQuery(AddOrUpdateUnitUpdateQuery(),
                            _commonService.AddParameter(new string[] {  model.DEPOT_ID.ToString(),model.DEPOT_CODE,model.DEPOT_NAME.ToString(), model.DEPOT_SHORT_NAME.ToString(), model.DEPOT_ADDRESS,
                            model.STATUS, model.UPDATED_BY.ToString(), model.UPDATED_DATE.ToString(), model.UPDATED_TERMINAL.ToString()
                            })));

                    }

                    await _commonService.SaveChangesAsyn(listOfQuery);
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public async Task<string> ActivateUnit(int id)
        {
            if (id < 1)
            {
                return "No data provided !!!!";
            }
            else
            {
                List<QueryPattern> listOfQuery = new List<QueryPattern>();
                try
                {
                    listOfQuery.Add(_commonService.AddQuery(ActivateUnitQuery(), _commonService.AddParameter(new string[] { id.ToString() })));

                    await _commonService.SaveChangesAsyn(listOfQuery);
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public async Task<string> DeactivateUnit(int id)
        {
            if (id < 1)
            {
                return "No data provided !!!!";
            }
            else
            {
                List<QueryPattern> listOfQuery = new List<QueryPattern>();
                try
                {
                    listOfQuery.Add(_commonService.AddQuery(DeActivateUnitQuery(), _commonService.AddParameter(new string[] { id.ToString() })));

                    await _commonService.SaveChangesAsyn(listOfQuery);
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public Task<string> AddOrUpdateUnit(COMPANY_INFO model)
        {
            throw new NotImplementedException();
        }

        //Task<List<CompanyInfo>> ICompanyManager.GetCompanyList()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<CompanyInfo> ICompanyManager.GetCompanyById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<string> AddOrUpdate(CompanyInfo model)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<string> AddOrUpdateUnit(CompanyInfo model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}