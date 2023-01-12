ngApp.controller('ngGridCtrl', ['$scope', 'ReturnCauseService', 'permissionProvider', 'notificationservice', 'gridregistrationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, ReturnCauseService, permissionProvider, notificationservice, gridregistrationservice, $http, $log, $filter, $timeout, $interval, $q) {
    $scope.model = { RETURN_CAUSE_ID: 0, RETURN_CAUSE_CODE: '', RETURN_CAUSE_NAME: '', STATUS: '' }

    $scope.gridOptionsList = (gridregistrationservice.GridRegistration("Retrun Cause"));

    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    }

    $scope.DataLoad = function () {
        $scope.showLoader = true;
        ReturnCauseService.GetCategoryList().then(function (data) {
            $scope.gridOptionsList.data = data.data.Data;
            for (var i = 0; i < $scope.gridOptionsList.data.length; i++) {
                $scope.gridOptionsList.data[i].ROW_NO = i + 1;
            }
            $scope.showLoader = false;
        }, function (error) {
            alert(error);

            $scope.showLoader = false;
        });
    }

    $scope.ClearForm = function () {
        $scope.model.RETURN_CAUSE_ID = 0;
        $scope.model.RETURN_CAUSE_CODE = "";
        $scope.model.RETURN_CAUSE_NAME = "";
        $scope.model.STATUS = "Active";
    }

    $scope.Statuses = ["Active", "Inactive"]

    permissionProvider.GetPermissionData($scope.model, "ReturnCause", "Index");

    $scope.DataLoad();

    $scope.gridOptionsList.columnDefs = [
        {
            name: 'Sl.No.', field: 'ROW_NO', enableFiltering: false, width: 60
        },
        {
            name: 'RETURN_CAUSE_ID', field: 'RETURN_CAUSE_ID', visible: false
        },
        {
            name: 'RETURN_CAUSE_CODE', field: 'RETURN_CAUSE_CODE', displayName: 'Retrun Cause Code', enableFiltering: true, width: '20%'
        },

        {
            name: 'RETURN_CAUSE_NAME', field: 'RETURN_CAUSE_NAME', displayName: 'Retrun Cause Name', enableFiltering: true, width: '35%'
        },
        {
            name: 'STATUS', field: 'STATUS', displayName: 'Status', enableFiltering: true, width: '34%'
        }
    ];

    $scope.gridOptionsList.rowTemplate = "<div ng-dblclick=\"grid.appScope.EditData(row.entity)\" title=\"Please double click to update. \" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name\" class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" ui-grid-cell></div>"

    $scope.EditData = function (entity) {
        $scope.model.RETURN_CAUSE_ID = entity.RETURN_CAUSE_ID;
        $scope.model.RETURN_CAUSE_CODE = entity.RETURN_CAUSE_CODE;
        $scope.model.RETURN_CAUSE_NAME = entity.RETURN_CAUSE_NAME;
        $scope.model.STATUS = entity.STATUS;
    }

    $scope.SaveData = function (model) {
        $scope.showLoader = true;

        ReturnCauseService.AddOrUpdate(model).then(function (data) {
            notificationservice.Notification(data.data.Message, data.data.Success, data.data.Message);
            if (data.data.Success == true) {
                $scope.showLoader = false;
                $scope.DataLoad();
                $scope.ClearForm();
            }
            else {
                $scope.showLoader = false;
                notificationservice.Notification(data.data.Message, data.data.Success, data.data.Message);
            }
        });
    }
}]);