using PMIS.Domain.Common;
using PMIS.Domain.Entities;
using PMIS.Repository.Interface;
using PMIS.Service.Interface.Security;
using PMIS.Utility.Static;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Implementation.Security
{
    public class EmployeeService: IEmployeeService
    {
        private readonly ICommonServices _commonService;

        public EmployeeService(ICommonServices _commonService)
        {
            this._commonService = _commonService;
        }

        private string GetEmployeeListQuery() => "Select distinct EMPLOYEE_ID, EMPLOYEE_NAME, EMPLOYEE_CODE, EMPLOYEE_STATUS from EMPLOYEE_INFO where COMPANY_ID = :param1";

        private string GetNewEmployeeIdQuery() => "SELECT NVL(MAX(EMPLOYEE_ID),0) + 1 EMPLOYEE_ID  FROM EMPLOYEE_INFO";

        private string AddOrUpdateEmployeeInsertQuery() => @"INSERT INTO EMPLOYEE_INFO (
                                        EMPLOYEE_ID
                                        ,EMPLOYEE_CODE
                                        ,EMPLOYEE_NAME
                                        ,EMPLOYEE_STATUS
                                        ,COMPANY_ID
                                       )
                                       VALUES ( :param1, :param2, :param3, :param4, :param5 )";

        private string AddOrUpdateEmployeeUpdateQuery() => @"Update EMPLOYEE_INFO set
            EMPLOYEE_CODE  =:param2,
            EMPLOYEE_NAME = :param3,
            EMPLOYEE_STATUS = :param4
            WHERE EMPLOYEE_ID = :param1";

        public async Task<string> AddOrUpdate(EMPLOYEE_INFO model)
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
                    if (model.EMPLOYEE_ID == 0)
                    {
                        //model.EMPLOYEE_STATUS = Status.Active;
                        //model.ID = _commonService.GetMaximumNumber<int>(GetNewIdQuery(), _commonService.AddParameter(new string[] { }));
                        model.EMPLOYEE_ID = _commonService.GetMaximumNumber<int>(GetNewEmployeeIdQuery(), _commonService.AddParameter(new string[] { }));

                        //model.UNIT_ID = 0;

                        listOfQuery.Add(_commonService.AddQuery(AddOrUpdateEmployeeInsertQuery(), _commonService.AddParameter(new string[]
                        {model.EMPLOYEE_ID.ToString(), model.EMPLOYEE_CODE.ToString(), model.EMPLOYEE_NAME,
                            model.EMPLOYEE_STATUS, model.COMPANY_ID.ToString() })));
                    }
                    else
                    {
                        listOfQuery.Add(_commonService.AddQuery(AddOrUpdateEmployeeUpdateQuery(),
                            _commonService.AddParameter(new string[] { model.EMPLOYEE_ID.ToString(), model.EMPLOYEE_CODE,
                                model.EMPLOYEE_NAME, model.EMPLOYEE_STATUS
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

        public async Task<string> GetEmployeeList(int companyId)
        {
            return _commonService.DataTableToJSON(await _commonService.GetDataTableAsyn(GetEmployeeListQuery(), _commonService.AddParameter(new string[] { companyId.ToString() })));
        }
    }
}
