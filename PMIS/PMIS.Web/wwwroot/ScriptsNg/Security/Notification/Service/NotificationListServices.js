ngApp.service("NotificationListServices", function($http) {
    this.GetNotificationList = function (date_from, date_to) {
        return $http.get('/Security/Notification/LoadData', { COMPANY_ID: parseInt('0'), DATE_FROM: date_from, DATE_TO: date_to  })
    }

})