ngApp.controller('ngGridCtrl', ['$scope', 'CategoryInfoService', 'permissionProvider', 'notificationservice', 'gridregistrationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, categoryInfoService, permissionProvider, notificationservice, gridregistrationservice, $http, $log, $filter, $timeout, $interval, $q) {
    $scope.model = { PM_CATEGORY_ID: 0, PM_CATEGORY_CODE: 0, PM_CATEGORY_NAME: '', STATUS: '', REMARKS: ''}
    $scope.gridOptionsList = (gridregistrationservice.GridRegistration("Category List"));
    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    }

    $scope.DataLoad = function () {
        $scope.showLoader = true;
        categoryInfoService.GetCategoryList().then(function (data) {
            $scope.gridOptionsList.data = data.data;
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
            $scope.model.ADD_PERMISSION = $scope.getPermissions.adD_PERMISSION;
            $scope.model.EDIT_PERMISSION = $scope.getPermissions.ediT_PERMISSION;
            $scope.model.DELETE_PERMISSION = $scope.getPermissions.deletE_PERMISSION;
            $scope.model.LIST_VIEW = $scope.getPermissions.lisT_VIEW;
            $scope.model.DETAIL_VIEW = $scope.getPermissions.detaiL_VIEW;
            $scope.model.DOWNLOAD_PERMISSION = $scope.getPermissions.downloaD_PERMISSION;

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
        , { name: 'EMPLOYEE_ID', field: 'EMPLOYEE_ID', visible: false }
        , {
            name: 'PM_CATEGORY_CODE', field: 'PM_CATEGORY_CODE', displayName: 'Category Code', enableFiltering: false, width: '20%', cellTemplate:
                '<input required="required"   ng-model="row.entity.PM_CATEGORY_CODE"  class="pl-sm" />'
        }
        , {
            name: 'PM_CATEGORY_NAME', field: 'PM_CATEGORY_NAME', displayName: 'Category Name', enableFiltering: false, width: '35%', cellTemplate:
                '<input required="required"  type="text"  ng-model="row.entity.PM_CATEGORY_NAME"  class="pl-sm" />'
        },
        {
            name: 'REMARK', field: 'REMARK', displayName: 'Remark', enableFiltering: false, width: '35%', cellTemplate:
                '<input required="required"  type="text"  ng-model="row.entity.REMARK"  class="pl-sm" />'
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
        $scope.model.ID = entity.ID;
        $scope.model.EMPLOYEE_ID = entity.EMPLOYEE_ID;
        $scope.model.EMPLOYEE_CODE = entity.EMPLOYEE_CODE;
        $scope.model.EMPLOYEE_NAME = entity.EMPLOYEE_NAME;
        $scope.model.EMPLOYEE_STATUS = entity.EMPLOYEE_STATUS;
        $scope.SaveData($scope.model);
    }

    $scope.SaveData = function (model) {
        $scope.showLoader = true;

        categoryInfoService.AddOrUpdate(model).then(function (data) {
            notificationservice.Notification(data.data, 1, 'Data Save Successfully !!');
            if (data.data == 1) {
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