ngApp.controller('ngGridCtrl', ['$scope', 'DoctorCategoryService', 'permissionProvider', 'notificationservice', 'gridregistrationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, DoctorCategoryService, permissionProvider, notificationservice, gridregistrationservice, $http, $log, $filter, $timeout, $interval, $q) {
    $scope.model = { DOCTOR_CATEGORY_ID: 0, DOCTOR_CATEGORY_CODE: '', DOCTOR_CATEGORY_NAME: '', STATUS: '' }

    $scope.gridOptionsList = (gridregistrationservice.GridRegistration("Doctor Category"));

    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    }

    $scope.DataLoad = function () {
        $scope.showLoader = true;
        DoctorCategoryService.GetCategoryList().then(function (data) {
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
        $scope.model.DOCTOR_CATEGORY_ID = 0;
        $scope.model.DOCTOR_CATEGORY_CODE = "";
        $scope.model.DOCTOR_CATEGORY_NAME = "";
        $scope.model.STATUS = "Active";
    }

    $scope.Statuses = ["Active", "Inactive"]

    permissionProvider.GetPermissionData($scope.model, "DoctorCategory", "Index");

    $scope.DataLoad();

    $scope.gridOptionsList.columnDefs = [
        {
            name: 'Sl.No.', field: 'ROW_NO', enableFiltering: false, width: 60
        },
        {
            name: 'DOCTOR_CATEGORY_ID', field: 'DOCTOR_CATEGORY_ID', visible: false
        },
        {
            name: 'DOCTOR_CATEGORY_CODE', field: 'DOCTOR_CATEGORY_CODE', displayName: 'Doctor Category Code', enableFiltering: true, width: '20%'
        },

        {
            name: 'DOCTOR_CATEGORY_NAME', field: 'DOCTOR_CATEGORY_NAME', displayName: 'Doctor Category Name', enableFiltering: true, width: '35%'
        },
        {
            name: 'STATUS', field: 'STATUS', displayName: 'Status', enableFiltering: true, width: '34%'
        }
    ];

    $scope.gridOptionsList.rowTemplate = "<div ng-dblclick=\"grid.appScope.EditData(row.entity)\" title=\"Please double click to update. \" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name\" class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" ui-grid-cell></div>"

    $scope.EditData = function (entity) {
        $scope.model.DOCTOR_CATEGORY_ID = entity.DOCTOR_CATEGORY_ID;
        $scope.model.DOCTOR_CATEGORY_CODE = entity.DOCTOR_CATEGORY_CODE;
        $scope.model.DOCTOR_CATEGORY_NAME = entity.DOCTOR_CATEGORY_NAME;
        $scope.model.STATUS = entity.STATUS;
    }

    $scope.SaveData = function (model) {
        $scope.showLoader = true;

        DoctorCategoryService.AddOrUpdate(model).then(function (data) {
            notificationservice.Notification(data.data.Success, true, data.data.Message);
            if (data.data.Success == true) {
                $scope.showLoader = false;
                $scope.DataLoad();
                $scope.ClearForm();
            }
            else {
                $scope.showLoader = false;
            }
        });
    }
}]);