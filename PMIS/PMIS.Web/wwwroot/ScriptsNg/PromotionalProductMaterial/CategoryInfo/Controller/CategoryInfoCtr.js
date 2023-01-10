ngApp.controller('ngGridCtrl', ['$scope', 'CategoryInfoService', 'permissionProvider', 'notificationservice', 'gridregistrationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, categoryInfoService, permissionProvider, notificationservice, gridregistrationservice, $http, $log, $filter, $timeout, $interval, $q) {
    $scope.model = { PM_CATEGORY_ID: 0, PM_CATEGORY_CODE: 0, PM_CATEGORY_NAME: '', STATUS: '', REMARKS: ''}
    $scope.gridOptionsList = (gridregistrationservice.GridRegistration("Category List"));
    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    }

    $scope.DataLoad = function () {
        $scope.showLoader = true;
        categoryInfoService.GetCategoryList().then(function (data) {
            debugger;
            $scope.gridOptionsList.data = data.data.Data;
            for (var i = 0; i < $scope.gridOptionsList.data.length; i++) {
                $scope.gridOptionsList.data[i].ROW_NO = i + 1;
            }
            console.log($scope.gridOptionsList.data);
            $scope.showLoader = false;
        }, function (error) {
            alert(error);

            $scope.showLoader = false;
        });
    }

    $scope.ClearForm = function () {
        $scope.model.EMPLOYEE_ID = 0;
        $scope.model.EMPLOYEE_CODE = "";
        $scope.model.EMPLOYEE_NAME = "";
        $scope.model.EMPLOYEE_STATUS = "Active";
    }
    $scope.Statuses = ["Active", "Inactive"]
    $scope.GetPermissionData = function () {
        $scope.showLoader = true;

        $scope.permissionReqModel = {
            Controller_Name: 'Employee',
            Action_Name: 'EmployeeInfo'
        }
        permissionProvider.GetPermission($scope.permissionReqModel).then(function (data) {
            $scope.getPermissions = data.data;
            $scope.model.ADD_PERMISSION = $scope.getPermissions.ADD_PERMISSION;
            $scope.model.EDIT_PERMISSION = $scope.getPermissions.EDIT_PERMISSION;
            $scope.model.DELETE_PERMISSION = $scope.getPermissions.DELETE_PERMISSION;
            $scope.model.LIST_VIEW = $scope.getPermissions.LIST_VIEW;
            $scope.model.DETAIL_VIEW = $scope.getPermissions.DETAIL_VIEW;
            $scope.model.DOWNLOAD_PERMISSION = $scope.getPermissions.DOWNLOAD_PERMISSION;

            $scope.showLoader = false;
        }, function (error) {
            alert(error);

            $scope.showLoader = false;
        });
    }

    $scope.DataLoad();
    $scope.GetPermissionData();

    $scope.gridOptionsList.columnDefs = [
        { name: 'SL', field: 'ROW_NO', enableFiltering: false, width: 50 }
        , { name: 'PM_CATEGORY_ID', field: 'PM_CATEGORY_ID', visible: false }
        , {
            name: 'PM_CATEGORY_CODE', field: 'PM_CATEGORY_CODE', displayName: 'Category Code', enableFiltering: false, width: '20%', cellTemplate:
                '<input required="required"   ng-model="row.entity.PM_CATEGORY_CODE"  class="pl-sm" />'
        }
        , {
            name: 'PM_CATEGORY_NAME', field: 'PM_CATEGORY_NAME', displayName: 'Category Name', enableFiltering: false, width: '35%', cellTemplate:
                '<input required="required"  type="text"  ng-model="row.entity.PM_CATEGORY_NAME"  class="pl-sm" />'
        },
        {
            name: 'REMARKS', field: 'REMARKS', displayName: 'Remarks', enableFiltering: false, width: '35%', cellTemplate:
                '<input required="required"  type="text"  ng-model="row.entity.REMARKS"  class="pl-sm" />'
        },
        {
            name: 'STATUS', field: 'STATUS', displayName: 'Status', enableFiltering: false, width: '35%', cellTemplate:
                '<input required="required"  type="text"  ng-model="row.entity.STATUS"  class="pl-sm" />'
        },
        , {
            name: 'Actions', displayName: 'Actions', enableFiltering: false, enableColumnMenu: false, width: '10%', cellTemplate:
                '<div style="margin:1px;">' +
                '<button style="margin-bottom: 5px;" ng-show="grid.appScope.model.EDIT_PERMISSION == \'Active\'" ng-click="grid.appScope.EditData(row.entity)" type="button" class="btn btn-outline-primary mb-1">Update</button>' +
                '</div>'
        },

    ];

    $scope.EditData = function (entity) {
        $scope.model.PM_CATEGORY_ID = entity.PM_CATEGORY_ID;
        $scope.model.PM_CATEGORY_CODE = entity.PM_CATEGORY_CODE;
        $scope.model.PM_CATEGORY_NAME = entity.PM_CATEGORY_NAME;
        $scope.model.REMARKS = entity.REMARKS;
        $scope.model.STATUS = entity.STATUS;
        //$scope.SaveData($scope.model);
    }

    $scope.SaveData = function (model) {
        $scope.showLoader = true;

        categoryInfoService.AddOrUpdate(model).then(function (data) {
            debugger;
            notificationservice.Notification(data.data.Message, 1, data.data.Message);
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