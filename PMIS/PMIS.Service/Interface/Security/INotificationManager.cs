using PMIS.Domain.Common;
using PMIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Service.Interface.Security
{
    public interface INotificationManager
    {
        Task<string> NotificationLoad(NOTIFICATION model);
        Task<string> LoadData(NOTIFICATION model);
        Task<string> UpdateNotificationViewStatus(NOTIFICATION model);
        Task<string> UpdateNotificationViewStatusByUser(NOTIFICATION model);

        Task<string> AddOrUpdateNotification(NOTIFICATION model);
        Task<string> AddOrderNotification(string db_sales, int NotificationPolicyId, string NotificationBody, int CompanyId, int UnitId);
        Task<string> Notification_Permitted_Users(int Policy_Id, int Unit_Id, int Company_Id);
    }
}
