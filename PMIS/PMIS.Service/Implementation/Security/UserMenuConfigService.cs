using Microsoft.Extensions.Configuration;
using PMIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using PMIS.Service.Interface.Security;
using PMIS.Repository.Interface;
using PMIS.Domain.ViewModels.Security;
using PMIS.Domain.Entities;
using PMIS.Utility.Static;

namespace PMIS.Service.Implementation.Security
{
    public class UserMenuConfigService : IUserMenuConfigService
    {
        private readonly ICommonServices _commonServices;
        private readonly IConfiguration _configuration;

        public UserMenuConfigService(ICommonServices commonServices, IConfiguration configuration)
        {
            _commonServices = commonServices;
            _configuration = configuration;
        }

        private string GetSearchableUserQuery() => @"Select ROW_NUMBER() OVER(ORDER BY USER_ID ASC) AS ROW_NO, USER_ID, EMAIL, EMPLOYEE_ID,  ( USER_NAME || ' (' || EMPLOYEE_ID || ') ' )  USER_NAME from User_Info Where COMPANY_ID = :param1 AND upper(USER_NAME) like '%' || upper(:param2) || '%'";

        private string GetSearchableCentralUserQuery() => @"Select ROW_NUMBER() OVER(ORDER BY USER_ID ASC) AS ROW_NO, USER_ID, EMAIL, EMPLOYEE_ID,  ( USER_NAME || ' (' || EMPLOYEE_ID || ') ' )  USER_NAME from User_Info Where upper(USER_NAME) like '%' || upper(:param1) || '%'";

        private string UserMenuQuery() => @"SELECT M.MENU_ID, M.MENU_NAME, M.HREF HREF, SM.MENU_ID PARENT_MENU_ID, SM.MENU_NAME PARENT_MENU_NAME, SM.HREF PARENT_MENU_HREF, M.MODULE_ID, MI.MODULE_NAME FROM MENU_CONFIGURATION M
                                  LEFT OUTER JOIN MENU_CONFIGURATION SM ON SM.MENU_ID = M.PARENT_MENU_ID
                                  LEFT OUTER JOIN MODULE_INFO MI ON MI.MODULE_ID = M.MODULE_ID
                                  WHERE M.STATUS = 'Active' AND M.COMPANY_ID = :param1";

        private string UserMenuConfigQuery() => @"SELECT R.ID USER_CONFIG_ID, R.USER_ID, R.MENU_ID, R.LIST_VIEW,R.ADD_PERMISSION, R.EDIT_PERMISSION, R.DELETE_PERMISSION, R.DETAIL_VIEW, R.DOWNLOAD_PERMISSION, R.CONFIRM_PERMISSION FROM MENU_CONFIGURATION M
                                    LEFT OUTER JOIN MENU_USER_CONFIGURATION R ON R.MENU_ID = M.MENU_ID
                                    WHERE  M.COMPANY_ID = :param1 AND R.USER_ID = :param2";

        private string AddRoleMenuConfigQuery() => @"Insert Into MENU_USER_CONFIGURATION (ID,COMPANY_ID,USER_ID,MENU_ID,LIST_VIEW,ADD_PERMISSION,EDIT_PERMISSION, DETAIL_VIEW, DELETE_PERMISSION,
             DOWNLOAD_PERMISSION, ENTERED_BY, ENTERED_DATE, ENTERED_TERMINAL, CONFIRM_PERMISSION)
                                          Values (:param1,:param2,:param3,:param4,:param5,:param6,:param7,:param8,:param9,:param10,:param11, TO_DATE(:param12, 'DD/MM/YYYY HH:MI:SS AM'), :param13, :param14)";

        private string AccRoleMenuConfigUpdateQuery() => @"UPDATE MENU_USER_CONFIGURATION SET LIST_VIEW =:param1 ,ADD_PERMISSION = :param2,EDIT_PERMISSION =  :param3,
                                            DETAIL_VIEW = :param4,DELETE_PERMISSION = :param5, DOWNLOAD_PERMISSION = :param6 , UPDATED_BY = :param7, UPDATED_DATE = TO_DATE(:param8, 'DD/MM/YYYY HH:MI:SS AM'),UPDATED_TERMINAL = :param9, CONFIRM_PERMISSION = :param11 WHERE ID = :param10";

        private string GetNewUserMenuConfigIdQuery() => "SELECT NVL(MAX(ID),0) + 1 ID  FROM MENU_USER_CONFIGURATION";

        public async Task<string> GetSearchableUsers(int companyId, string user_Name) => _commonServices.DataTableToJSON(await _commonServices.GetDataTableAsyn(GetSearchableUserQuery(), _commonServices.AddParameter(new string[] { companyId.ToString(), user_Name })));

        public async Task<string> GetSearchableCentralUsers(string user_Name) => _commonServices.DataTableToJSON(await _commonServices.GetDataTableAsyn(GetSearchableCentralUserQuery(), _commonServices.AddParameter(new string[] { user_Name })));

        public async Task<string> UserMenuConfigSelectionList(int companyId, int userId)
        {
            DataTable MenuLoad = await _commonServices.GetDataTableAsyn(UserMenuQuery(), _commonServices.AddParameter(new string[] { companyId.ToString() }));
            DataTable ConfigDataLoad = await _commonServices.GetDataTableAsyn(UserMenuConfigQuery(), _commonServices.AddParameter(new string[] { companyId.ToString(), userId.ToString() }));
            List<UserMenuConfigView> roleMenuConfigView = new List<UserMenuConfigView>();

            for (int i = 0; i < MenuLoad.Rows.Count; i++)
            {
                UserMenuConfigView model = new UserMenuConfigView
                {
                    ROW_NO = i + 1,

                    MENU_ID = Convert.ToInt32(MenuLoad.Rows[i]["MENU_ID"]),
                    MENU_NAME = MenuLoad.Rows[i]["MENU_NAME"].ToString(),
                    HREF = MenuLoad.Rows[i]["HREF"].ToString()
                };
                if (MenuLoad.Rows[i]["PARENT_MENU_ID"] != null && MenuLoad.Rows[i]["PARENT_MENU_ID"].ToString() != "")
                {
                    model.PARENT_MENU_ID = Convert.ToInt32(MenuLoad.Rows[i]["PARENT_MENU_ID"]);
                    model.PARENT_MENU_NAME = MenuLoad.Rows[i]["PARENT_MENU_NAME"].ToString();
                    model.PARENT_MENU_HREF = MenuLoad.Rows[i]["PARENT_MENU_HREF"].ToString();
                }

                model.MODULE_NAME = MenuLoad.Rows[i]["MODULE_NAME"].ToString();

                roleMenuConfigView.Add(model);
            }

            for (int i = 0; i < ConfigDataLoad.Rows.Count; i++)
            {
                UserMenuConfigView configView = roleMenuConfigView.Where(x => x.MENU_ID == Convert.ToInt32(ConfigDataLoad.Rows[i]["MENU_ID"])).FirstOrDefault();
                if (configView != null)
                {
                    configView.USER_CONFIG_ID = Convert.ToInt32(ConfigDataLoad.Rows[i]["USER_CONFIG_ID"]);
                    configView.USER_ID = Convert.ToInt32(ConfigDataLoad.Rows[i]["USER_ID"]);
                    configView.LIST_VIEW = ConfigDataLoad.Rows[i]["LIST_VIEW"].ToString();
                    configView.ADD_PERMISSION = ConfigDataLoad.Rows[i]["ADD_PERMISSION"].ToString();

                    configView.EDIT_PERMISSION = ConfigDataLoad.Rows[i]["EDIT_PERMISSION"].ToString();
                    configView.DELETE_PERMISSION = ConfigDataLoad.Rows[i]["DELETE_PERMISSION"].ToString();
                    configView.DETAIL_VIEW = ConfigDataLoad.Rows[i]["DETAIL_VIEW"].ToString();
                    configView.DOWNLOAD_PERMISSION = ConfigDataLoad.Rows[i]["DOWNLOAD_PERMISSION"].ToString();
                    configView.CONFIRM_PERMISSION = ConfigDataLoad.Rows[i]["CONFIRM_PERMISSION"].ToString();
                }
            }
            if (roleMenuConfigView.Count == 0)
            {
                return "1";
            }
            return JsonSerializer.Serialize(roleMenuConfigView);
        }

        public async Task<string> AddUserMenuConfiguration(List<MENU_USER_CONFIGURATION> roleMenuConfig)
        {
            List<QueryPattern> listOfQuery = new List<QueryPattern>();
            try
            {
                BindRoleMenuConfig(roleMenuConfig);
                int new_ID = _commonServices.GetMaximumNumber<int>(GetNewUserMenuConfigIdQuery(), _commonServices.AddParameter(new string[] { }));
                foreach (var model in roleMenuConfig)
                {
                    if (model.USER_CONFIG_ID == 0)
                    {
                        model.ID = new_ID;

                        listOfQuery.Add(_commonServices.AddQuery(AddRoleMenuConfigQuery(),
                        _commonServices.AddParameter(new string[] { model.ID.ToString(),  model.COMPANY_ID.ToString(), model.USER_ID.ToString(), model.MENU_ID.ToString()
                        , model.LIST_VIEW, model.ADD_PERMISSION,model.EDIT_PERMISSION, model.DETAIL_VIEW, model.DELETE_PERMISSION, model.DOWNLOAD_PERMISSION
                        , model.ENTERED_BY.ToString(), model.ENTERED_DATE?.ToString("dd/MM/yyyy hh:mm:ss tt"), model.ENTERED_TERMINAL, model.CONFIRM_PERMISSION
                         })));
                    }
                    else
                    {
                        listOfQuery.Add(_commonServices.AddQuery(AccRoleMenuConfigUpdateQuery(),
                         _commonServices.AddParameter(new string[] {  model.LIST_VIEW, model.ADD_PERMISSION,
                             model.EDIT_PERMISSION, model.DETAIL_VIEW, model.DELETE_PERMISSION, model.DOWNLOAD_PERMISSION
                        , model.UPDATED_BY.ToString(), model.UPDATED_DATE?.ToString("dd/MM/yyyy hh:mm:ss tt"), model.UPDATED_TERMINAL, model.USER_CONFIG_ID.ToString(),
                             model.CONFIRM_PERMISSION
                          })));
                    }

                    new_ID++;
                }
                await _commonServices.SaveChangesAsyn(listOfQuery);

                return "1";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<MENU_USER_CONFIGURATION> BindRoleMenuConfig(List<MENU_USER_CONFIGURATION> model)
        {
            foreach (var item in model)
            {
                item.ADD_PERMISSION = item.ADD_PERMISSION != Status.Active ? Status.InActive : Status.Active;
                item.EDIT_PERMISSION = item.EDIT_PERMISSION != Status.Active ? Status.InActive : Status.Active;
                item.DELETE_PERMISSION = item.DELETE_PERMISSION != Status.Active ? Status.InActive : Status.Active;
                item.DETAIL_VIEW = item.DETAIL_VIEW != Status.Active ? Status.InActive : Status.Active;
                item.LIST_VIEW = item.LIST_VIEW != Status.Active ? Status.InActive : Status.Active;
                item.DOWNLOAD_PERMISSION = item.DOWNLOAD_PERMISSION != Status.Active ? Status.InActive : Status.Active;
            }

            return model;
        }
    }
}