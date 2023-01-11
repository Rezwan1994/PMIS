ngApp.service("ReportService", function ($http) {
    this.GetCategories = function () {
        return $http.get('/PromotionalProductMaterial/CategoryInfo/Get');
    }


    this.IsReportPermitted = function (reportId) {
        return $http.post('/PromotionalProductMaterial/Report/IsReportPermitted', { REPORT_ID: parseInt(reportId) });
    }
});