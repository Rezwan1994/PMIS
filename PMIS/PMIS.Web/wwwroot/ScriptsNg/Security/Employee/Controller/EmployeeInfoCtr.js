ngApp.controller('ngGridCtrl', ['$scope', 'EmployeeService', 'permissionProvider', 'notificationservice', 'gridregistrationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, EmployeeService, permissionProvider, notificationservice, gridregistrationservice, $http, $log, $filter, $timeout, $interval, $q) {
    $scope.model = { ID: 0, EMPLOYEE_ID: 0, EMPLOYEE_CODE: '', EMPLOYEE_NAME: '', COMPANY_ADDRESS1: '', COMPANY_ADDRESS1: '' }
    $scope.gridOptionsList = (gridregistrationservice.GridRegistration("Company List"));
    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    }

    $scope.DataLoad = function () {
        $scope.showLoader = true;
        EmployeeService.GetEmployeeList().then(function (data) {
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
        $scope.model.ID = 0;
        $scope.model.EMPLOYEE_ID = 0;
        $scope.model.EMPLOYEE_CODE = '';
        $scope.model.EMPLOYEE_NAME = '';
    }

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
            name: 'EMPLOYEE_CODE', field: 'EMPLOYEE_CODE', displayName: 'Employee Code', enableFiltering: false, width: '30%', cellTemplate:
                '<input required="required"   ng-model="row.entity.EMPLOYEE_CODE"  class="pl-sm" />'
        }
        , {
            name: 'EMPLOYEE_NAME', field: 'EMPLOYEE_NAME', displayName: 'Employee Name', enableFiltering: false, width: '40%', cellTemplate:
                '<input required="required"  type="text"  ng-model="row.entity.EMPLOYEE_NAME"  class="pl-sm" />'
        }
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

        $scope.SaveData($scope.model);
    }

    $scope.SaveData = function (model) {
        $scope.showLoader = true;

        EmployeeService.AddOrUpdate(model).then(function (data) {
            notificationservice.Notification(data.data, 1, 'Data Save Successfully !!');
            if (data.data == 1) {
                $scope.showLoader = false;
                $scope.DataLoad();
                $scope.model.Name = "";
                $scope.model.SerialNo = "";
                $scope.ClearForm();
            }
            else {
                $scope.showLoader = false;
            }
        });
    }
}]);