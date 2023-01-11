ngApp.controller('ngGridCtrl', ['$scope', 'ReportService', 'permissionProvider', 'notificationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, ReportService, permissionProvider, notificationservice, $http, $log, $filter, $timeout, $interval, $q) {

    'use strict'
    $scope.model = {
        COMPANY_ID: 0, REPORT_ID: ''
    }
    $scope.model.DATE_FROM = $filter("date")(Date.now(), 'dd/MM/yyyy');
    $scope.model.DATE_TO = $filter("date")(Date.now(), 'dd/MM/yyyy');
    $scope.Categories = [];

    $scope.GetCategories = function () {
        ReportService.GetCategories().then(response => {
            $scope.Categories = response.data.Data;
        })
    }
    $scope.GetCategories();

    $scope.LoadReportParamters = function (reportId, id_serial) {
        $scope.model.REPORT_ID = reportId;
        debugger
        $scope.showLoader = true;
        ReportService.IsReportPermitted(reportId).then(function (data) {
            $scope.model.CSV_PERMISSION = data.data.CSV_PERMISSION;
            $scope.model.PREVIEW_PERMISSION = data.data.PREVIEW_PERMISSION;
            $scope.model.PDF_PERMISSION = data.data.PDF_PERMISSION;
            var _id = 'selection[' + id_serial + ']';
            var _id_selected = 'ReportIdEncrypt[' + id_serial + ']';
            let checkboxes = document.getElementsByClassName('checkbox-inline');
            for (var i = 0; i < checkboxes.length; i++) {
                let checkbox = document.getElementById(checkboxes[i].id);
                checkbox.checked = false;
            }
            let checkbox = document.getElementById(_id);
            $scope.model.reportIdEncryptedSelected = document.getElementById(_id_selected).value;
            checkbox.checked = true;

            $scope.showLoader = false;
        }, function (error) {
            $scope.showLoader = false;
        });
    }



    $scope.GetPermissionData = function () {
        $scope.showLoader = true;
        permissionProvider.GetPermissionData($scope.model, "Report", "Index");
        $scope.showLoader = false;
    }

    $scope.GetPdfView = function () {
        var href = "/PromotionalProductMaterial/Report/GenerateReport?ReportId=" + $scope.model.reportIdEncryptedSelected
            + "&PM_CATEGORY_CODE=" + $scope.model.PM_CATEGORY_CODE + "&REPORT_EXTENSION=" + 'Pdf';
        window.open(href, '_blank');
    }

    $scope.GetPermissionData();
}]);