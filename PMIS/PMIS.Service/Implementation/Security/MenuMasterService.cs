using Microsoft.Extensions.Configuration;
using PMIS.Domain.Common;
using PMIS.Domain.Entities;
using PMIS.Repository.Interface;
using PMIS.Utility.Static;
using PMIS.Service.Interface.Security;
using System.Data;

namespace PMIS.Service.Implementation.Security
{
    public class MenuMasterService : IMenuMasterService
    {
        private readonly ICommonServices _commonServices;

        public MenuMasterService(ICommonServices commonServices)
        {
            _commonServices = commonServices;
        }

        private string loadDataQuery() => @"SELECT ROW_NUMBER() OVER(ORDER BY M.MENU_ID ASC) AS ROW_NO,
                               M.MENU_ID, M.MENU_NAME, M.STATUS,M.ORDER_BY_SLNO, M.HREF, M.AREA,
                               M.CONTROLLER, M.ACTION, M.PARENT_MENU_ID,M.MENU_SHOW,
                               (SELECT N.MENU_NAME FROM MENU_CONFIGURATION N WHERE N.MENU_ID = M.PARENT_MENU_ID ) PARENT_MENU,
                               C.MODULE_NAME , M.MODULE_ID
                               FROM MENU_CONFIGURATION M, MODULE_INFO C WHERE  M.MODULE_ID = C.MODULE_ID  AND M.COMPANY_ID = :param1";

        private string AddOrUpdate_AddQuery() => @"INSERT INTO Menu_Configuration
                                      (Menu_ID, Menu_Name ,Module_ID, Controller  ,Action ,Href ,Status ,Parent_Menu_Id ,ORDER_BY_SLNO, Company_Id, Entered_BY, Entered_Date, Entered_Terminal,AREA,MENU_SHOW)
                                      VALUES(:param1 ,:param2  ,:param3  ,:param4,:param5  ,:param6,:param7, :param8,:param9,:param10,:param11,TO_DATE(:param12, 'DD/MM/YYYY HH:MI:SS AM'),:param13 ,:param14,:param15)";

        private string AddOrUpdate_UpdateQuery() => @"UPDATE Menu_Configuration SET
                                         Menu_Name = :param2 ,Module_Id = :param3 ,Controller = :param4 ,Action = :param5 ,
                                         Href = :param6 ,Parent_Menu_Id = :param7 ,ORDER_BY_SLNO = :param8,
                                         Updated_By= :param9, Updated_Date= TO_DATE(:param10, 'DD/MM/YYYY HH:MI:SS AM'), Updated_Terminal= :param11 , AREA = :param12, MENU_SHOW= :param13
                                         WHERE Menu_ID = :param1";

        private string ActivateMenuQuery() => "UPDATE Menu_Configuration SET  Status = '" + Status.Active + "' WHERE Menu_Id = :param1";

        private string DeactivateMenuQuery() => "UPDATE Menu_Configuration SET  Status = '" + Status.InActive + "' WHERE Menu_Id = :param1";

        private string IsParentMenuQuery() => "SELECT MENU_ID FROM MENU_CONFIGURATION WHERE PARENT_MENU_ID = :param1";

        private string DeleteMenuQuery() => "DELETE FROM MENU_CONFIGURATION WHERE MENU_ID = :param1";

        private string GetNewMenu_ConfigurationIdQuery() => "SELECT NVL(MAX(MENU_ID),0) + 1 MENU_ID  FROM MENU_CONFIGURATION";

        public string LoadData(int companyId) => _commonServices.DataTableToJSON(_commonServices.GetDataTable(loadDataQuery(), _commonServices.AddParameter(new string[] { companyId.ToString() })));

        public async Task<string> AddOrUpdate(MENU_CONFIGURATION model)
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
                    if (model.MENU_ID == 0)
                    {
                        model.STATUS = Status.InActive;
                        model.MENU_ID = _commonServices.GetMaximumNumber<int>(GetNewMenu_ConfigurationIdQuery(), _commonServices.AddParameter(new string[] { }));

                        listOfQuery.Add(_commonServices.AddQuery(AddOrUpdate_AddQuery(), _commonServices.AddParameter(new string[]
                        {model.MENU_ID.ToString(), model.MENU_NAME, model.MODULE_ID.ToString(), model.CONTROLLER, model.ACTION, model.HREF, model.STATUS, model.PARENT_MENU_ID.ToString(), model.ORDER_BY_SLNO.ToString(), model.COMPANY_ID.ToString(), model.ENTERED_BY, model.ENTERED_DATE?.ToString("dd/MM/yyyy"), model.ENTERED_TERMINAL, model.AREA, model.MENU_SHOW })));
                    }
                    else
                    {
                        listOfQuery.Add(_commonServices.AddQuery(AddOrUpdate_UpdateQuery(),
                            _commonServices.AddParameter(new string[] { model.MENU_ID.ToString(), model.MENU_NAME,
                                model.MODULE_ID.ToString(), model.CONTROLLER, model.ACTION, model.HREF,
                                model.PARENT_MENU_ID.ToString(), model.ORDER_BY_SLNO.ToString(),
                                model.UPDATED_BY, model.UPDATED_DATE?.ToString("dd/MM/yyyy"), model.UPDATED_TERMINAL, model.AREA, model.MENU_SHOW
                            })));
                    }

                    await _commonServices.SaveChangesAsyn(listOfQuery);
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public async Task<string> ActivateMenu(int id)
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
                    listOfQuery.Add(_commonServices.AddQuery(ActivateMenuQuery(), _commonServices.AddParameter(new string[] { id.ToString() })));

                    await _commonServices.SaveChangesAsyn(listOfQuery);
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public async Task<string> DeactivateMenu(int id)
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
                    listOfQuery.Add(_commonServices.AddQuery(DeactivateMenuQuery(), _commonServices.AddParameter(new string[] { id.ToString() })));

                    await _commonServices.SaveChangesAsyn(listOfQuery);
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public async Task<string> DeleteMenu(int id)
        {
            DataTable data = _commonServices.GetDataTable(IsParentMenuQuery(), _commonServices.AddParameter(new string[] { id.ToString() }));
            if (data != null && data.Rows.Count > 0)
            {
                return " Sorry!! You can't Delete this menu. Already Some Menu's are assigned under this Menu.";
            }
            else
            {
                List<QueryPattern> listOfQuery = new List<QueryPattern>();
                try
                {
                    listOfQuery.Add(_commonServices.AddQuery(DeleteMenuQuery(), _commonServices.AddParameter(new string[] { id.ToString() })));

                    await _commonServices.SaveChangesAsyn(listOfQuery);
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}