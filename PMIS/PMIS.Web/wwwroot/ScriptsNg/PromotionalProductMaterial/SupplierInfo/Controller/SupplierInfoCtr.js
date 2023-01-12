ngApp.controller('ngGridCtrl', ['$scope', 'SupplierInfoService', 'permissionProvider', 'notificationservice', 'gridregistrationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, SupplierInfoService, permissionProvider, notificationservice, gridregistrationservice, $http, $log, $filter, $timeout, $interval, $q) {
    $scope.model = { SUPPLIER_ID: 0, SUPPLIER_CODE: '', SUPPLIER_NAME: '', STATUS: '' }

    $scope.gridOptionsList = (gridregistrationservice.GridRegistration("Doctor Category"));

    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    }

    $scope.DataLoad = function () {
        $scope.showLoader = true;
        SupplierInfoService.GetCategoryList().then(function (data) {
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
        $scope.model.SUPPLIER_ID = 0;
        $scope.model.SUPPLIER_CODE = "";
        $scope.model.SUPPLIER_NAME = "";
        $scope.model.REMARKS = "";
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
            name: 'SUPPLIER_ID', field: 'SUPPLIER_ID', visible: false
        },
        {
            name: 'SUPPLIER_CODE', field: 'SUPPLIER_CODE', displayName: 'Doctor Category Code', enableFiltering: false, width: '20%'
        },

        {
            name: 'SUPPLIER_NAME', field: 'SUPPLIER_NAME', displayName: 'Doctor Category Name', enableFiltering: false, width: '35%'
        },
        {
            name: 'STATUS', field: 'STATUS', displayName: 'Status', enableFiltering: false, width: '34%'
        }
    ];

    $scope.gridOptionsList.rowTemplate = "<div ng-dblclick=\"grid.appScope.EditData(row.entity)\" title=\"Please double click to update. \" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name\" class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" ui-grid-cell></div>"

    $scope.EditData = function (entity) {
        $scope.model.SUPPLIER_ID = entity.SUPPLIER_ID;
        $scope.model.SUPPLIER_CODE = entity.SUPPLIER_CODE;
        $scope.model.SUPPLIER_NAME = entity.SUPPLIER_NAME;
        $scope.model.STATUS = entity.STATUS;
        $scope.model.REMARKS = entity.REMARKS;
    }

    $scope.SaveData = function (model) {
        $scope.showLoader = true;

        SupplierInfoService.AddOrUpdate(model).then(function (data) {
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
