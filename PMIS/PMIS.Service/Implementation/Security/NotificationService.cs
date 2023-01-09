using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PMIS.Domain.Common;
using PMIS.Domain.Entities;
using PMIS.Repository.Interface;
using PMIS.Service.Interface.Security;
using PMIS.Utility.Static;

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Implementation.Security
{
    public class NotificationService : INotificationService
    {
        private readonly IConfiguration connString;
        private readonly ICommonServices _commonService;
        private readonly IConfiguration _configuration;

        public NotificationService(IConfiguration connstring, ICommonServices commonServices, IConfiguration configuration)
        {
            connString = connstring;
            _commonService = commonServices;
            _configuration = configuration;
        }

        string NotificationLoad_Query() => @"SELECT 
   ROWNUM, N.NOTIFICATION_ID, N.NOTIFICATION_POLICY_ID, N.NOTIFICATION_TITLE, 
   N.NOTIFICATION_BODY,TO_CHAR( N.NOTIFICATION_DATE, 'DD/MM/YYYY HH:MI:SS AM') NOTIFICATION_DATE, N.STATUS, 
   N.COMPANY_ID, N.UNIT_ID , V.ID
FROM NOTIFICATION N
INNER JOIN NOTIFICATION_VIEW V on V.NOTIFICATION_ID = N.NOTIFICATION_ID and V.STATUS != 'Active'
WHERE V.USER_ID = :param1 ";
        string DataLoad_Query() => @"SELECT 
   ROWNUM, N.NOTIFICATION_ID, N.NOTIFICATION_POLICY_ID, N.NOTIFICATION_TITLE, 
   N.NOTIFICATION_BODY,TO_CHAR( N.NOTIFICATION_DATE, 'DD/MM/YYYY HH:MI:SS AM') NOTIFICATION_DATE, V.STATUS, 
   N.COMPANY_ID, N.UNIT_ID , V.ID
FROM NOTIFICATION N
INNER JOIN NOTIFICATION_VIEW V on V.NOTIFICATION_ID = N.NOTIFICATION_ID
WHERE V.USER_ID = :param1 Order By N.NOTIFICATION_ID DESC";
        string Notification_Policy_Permitted_User() => @"Select V.ID,  V.NOTIFICATION_POLICY_ID,  V.STATUS,  V.COMPANY_ID,  V.UNIT_ID,  V.USER_ID,  V.VIEW_PERMISSION , P.NOTIFICATION_TITLE
from NOTIFICATION_VIEW_POLICY V
LEFT OUTER JOIN NOTIFICATION_POLICY P on P.NOTIFICATION_POLICY_ID = V.NOTIFICATION_POLICY_ID Where V.STATUS = 'Active' and P.STATUS = 'Active'
And V.NOTIFICATION_POLICY_ID = :param1 AND V.UNIT_ID = :param2 AND V.COMPANY_ID=:param3";
        string AddOrUpdateNotificationInsertQuery() => @"INSERT INTO NOTIFICATION (
 
                                         NOTIFICATION_ID
                                        ,NOTIFICATION_POLICY_ID
                                        ,NOTIFICATION_TITLE
                                        ,NOTIFICATION_BODY
                                        ,NOTIFICATION_DATE
                                        ,COMPANY_ID
                                        ,UNIT_ID
                                        ,STATUS
                                       ) 
                                       VALUES ( :param1, :param2, :param3, :param4, TO_DATE( :param5, 'DD/MM/YYYY HH:MI:SS AM') , :param6, :param7, :param8 )";
        string AddOrUpdateNotificationViewInsertQuery() => @"INSERT INTO NOTIFICATION_VIEW (
                                        NOTIFICATION_ID
                                        ,USER_ID
                                        ,STATUS
                                        ,COMPANY_ID
                                        ,UNIT_ID
                                        ,VIEW_DATE
                                       ) 
                                       VALUES ( :param1, :param2, :param3, :param4, :param5, :param6, TO_DATE( :param7, 'DD/MM/YYYY HH:MI:SS AM') )";
        string UpdateNotificationViewStatus_Query() => @"Update NOTIFICATION_VIEW Set STATUS = 'Active' Where NOTIFICATION_ID = :param1";
        string UpdateNotificationViewStatusByUser_Query() => @"Update NOTIFICATION_VIEW Set STATUS = 'Active' Where USER_ID = :param1";

        string GetNewNotificationIdQuery() => "SELECT NVL(MAX(NOTIFICATION_ID),0) + 1 NOTIFICATION_ID  FROM NOTIFICATION";
        string GetNewNotificationViewIdQuery() => "SELECT NVL(MAX(ID),0) + 1 ID  FROM NOTIFICATION_VIEW";

        public async Task<DataTable> NotificationLoad_Datatable(int User_Id) => await _commonService.GetDataTableAsyn( NotificationLoad_Query(), _commonService.AddParameter(new string[] { User_Id.ToString() }));
        public async Task<DataTable> DataLoad_Datatable( int User_Id) => await _commonService.GetDataTableAsyn( DataLoad_Query(), _commonService.AddParameter(new string[] { User_Id.ToString() }));
        public async Task<DataTable> NotificationPermitted_Datatable(int Policy_Id, int Unit_Id, int Company_Id) => await _commonService.GetDataTableAsyn( Notification_Policy_Permitted_User(), _commonService.AddParameter(new string[] { Policy_Id.ToString(), Unit_Id.ToString(), Company_Id.ToString() }));
        public async Task<string> Notification_Permitted_Users(int Policy_Id, int Unit_Id, int Company_Id) => _commonService.DataTableToJSON(await NotificationPermitted_Datatable( Policy_Id, Unit_Id, Company_Id));

        public async Task<List<NOTIFICATION>> Notification_Permitted_User(int Policy_Id, int Unit_Id, int Company_Id)
        {
            DataTable dataTable = await NotificationPermitted_Datatable( Policy_Id, Unit_Id, Company_Id);
            List<NOTIFICATION> User_Ids = new List<NOTIFICATION>();
            foreach (DataRow row in dataTable.Rows)
            {
                NOTIFICATION notification = new NOTIFICATION();
                //notification.USERID = Convert.ToInt32(row["USER_ID"]);
                User_Ids.Add(notification);

            }
            User_Ids[0].NOTIFICATION_TITLE = dataTable.Rows[0]["NOTIFICATION_TITLE"].ToString();
            return User_Ids;
        }



        public async Task<string> NotificationLoad(NOTIFICATION model) => _commonService.DataTableToJSON(await NotificationLoad_Datatable(model.USER_ID));
        public async Task<string> LoadData(NOTIFICATION model) => _commonService.DataTableToJSON(await DataLoad_Datatable(model.USER_ID));

        public async Task<string> UpdateNotificationViewStatus(NOTIFICATION model)
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

                    if (model.NOTIFICATION_ID > 0)
                    {


                        listOfQuery.Add(_commonService.AddQuery(UpdateNotificationViewStatus_Query(), _commonService.AddParameter(new string[]
                        {  model.NOTIFICATION_ID.ToString() })));

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
        public async Task<string> UpdateNotificationViewStatusByUser(NOTIFICATION model)
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

                    if (model.USER_ID > 0)
                    {


                        listOfQuery.Add(_commonService.AddQuery(UpdateNotificationViewStatusByUser_Query(), _commonService.AddParameter(new string[]
                        {  model.USER_ID.ToString() })));

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

        public async Task<string> AddOrUpdateNotification(NOTIFICATION model)
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

                    if (model.NOTIFICATION_ID == 0)
                    {
                        model.STATUS = Status.Active;
                        model.NOTIFICATION_ID = _commonService.GetMaximumNumber<int>(GetNewNotificationIdQuery(), _commonService.AddParameter(new string[] { }));
                        //model.ID = _commonService.GetMaximumNumber<int>(GetNewNotificationViewIdQuery(), _commonService.AddParameter(new string[] { }));
                        List<NOTIFICATION> permitted_Users = new List<NOTIFICATION>();
                        permitted_Users = await Notification_Permitted_User( model.NOTIFICATION_POLICY_ID, model.UNIT_ID, model.COMPANY_ID);
                        model.NOTIFICATION_TITLE = permitted_Users[0].NOTIFICATION_TITLE;



                        listOfQuery.Add(_commonService.AddQuery(AddOrUpdateNotificationInsertQuery(), _commonService.AddParameter(new string[]
                                            {model.NOTIFICATION_ID.ToString(), model.NOTIFICATION_POLICY_ID.ToString(), model.NOTIFICATION_TITLE.ToString(), model.NOTIFICATION_BODY,
                            model.NOTIFICATION_DATE?.ToString("dd/MM/yyyy"), model.COMPANY_ID.ToString(), model.UNIT_ID.ToString(), model.STATUS.ToString() })));

                        foreach (var item in permitted_Users)
                        {
                            listOfQuery.Add(_commonService.AddQuery(AddOrUpdateNotificationViewInsertQuery(),
                                _commonService.AddParameter(new string[]
                                {
                                              model.NOTIFICATION_ID.ToString(), item.USER_ID.ToString(), Status.InActive, model.COMPANY_ID.ToString(),
                                            model.UNIT_ID.ToString(), model.NOTIFICATION_DATE?.ToString("dd/MM/yyyy")
                                 })));
                        }

                        await _commonService.SaveChangesAsyn(listOfQuery);


                    }
                    return "1";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }


        //-- Notification Part-------------

        public async Task<string> AddOrderNotification(string db_sales, int NotificationPolicyId, string NotificationBody, int CompanyId, int UnitId)
        {
            NOTIFICATION notification = new NOTIFICATION();
            notification.COMPANY_ID = CompanyId;
            notification.UNIT_ID = UnitId;
            notification.NOTIFICATION_DATE = DateTime.Now;

            notification.NOTIFICATION_POLICY_ID = NotificationPolicyId;
            notification.NOTIFICATION_BODY = NotificationBody;
            return await AddOrUpdateNotification( notification);

        }

     
    }
}
