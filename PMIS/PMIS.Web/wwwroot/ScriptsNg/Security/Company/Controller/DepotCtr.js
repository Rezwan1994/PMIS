ngApp.controller('ngGridCtrl', ['$scope', 'CompanyService', 'permissionProvider', 'notificationservice', 'gridregistrationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, CompanyService, permissionProvider, notificationservice, gridregistrationservice, $http, $log, $filter, $timeout, $interval, $q) {
    $scope.model = { ID: 0, DEPOT_ID: 0, DEPOT_CODE: "", DEPOT_NAME: "", DEPOT_SHORT_NAME: "", DEPOT_ADDRESS: "", STATUS: "" }

    $scope.gridOptionsList = (gridregistrationservice.GridRegistration("Unit List"));
    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    }

    $scope.DataLoad = function () {
        $scope.showLoader = true;
        CompanyService.GetUnitList().then(function (data) {
            $scope.gridOptionsList.data = [];
            for (var i = 0; i < data.data.length; i++) {
                if (data.data[i].COMPANY_ID == $scope.model.COMPANY_ID) {
                    $scope.gridOptionsList.data.push(data.data[i]);
                }
            }
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
        //$scope.model.ID = 0;
        //$scope.model.COMPANY_ID = 0;
        //$scope.model.COMPANY_NAME = '';
        //$scope.model.COMPANY_SHORT_NAME = '';
        //$scope.model.COMPANY_ADDRESS1 = '';
        //$scope.model.COMPANY_ADDRESS2 = '';
    }

    $scope.GetPermissionData = function () {
        $scope.showLoader = true;

        $scope.permissionReqModel = {
            Controller_Name: 'Company',
            Action_Name: 'Depot'
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
        { name: 'SL', field: 'ROW_NO', enableFiltering: false, width: 40 }

        , { name: 'DEPOT_ID', field: 'DEPOT_ID', visible: false }

        , {
            name: 'DEPOT_CODE', field: 'DEPOT_CODE', displayName: 'DEPOT CODE', enableFiltering: true, width: '20%', cellTemplate:
                '<input required="required"   ng-model="row.entity.DEPOT_CODE"  class="pl-sm" />'
        }
        , {
            name: 'DEPOT_NAME', field: 'DEPOT_NAME', displayName: 'Unit Name', enableFiltering: true, width: '20%', cellTemplate:
                '<input required="required"   ng-model="row.entity.DEPOT_NAME"  class="pl-sm" />'
        }
        , {
            name: 'DEPOT_SHORT_NAME', field: 'DEPOT_SHORT_NAME', displayName: 'Short Name', enableFiltering: true, width: ' 20%', cellTemplate:
                '<input required="required"  type="text"  ng-model="row.entity.DEPOT_SHORT_NAME"  class="pl-sm" />'
        }

        , { name: 'STATUS', field: 'STATUS', displayName: 'Status', enableFiltering: true, width: ' 8%' }

        , {
            name: 'DEPOT_ADDRESS', field: 'DEPOT_ADDRESS', displayName: 'Unit Address 1', enableFiltering: true, width: ' 24%', cellTemplate:
                '<input required="required"  type="text"  ng-model="row.entity.DEPOT_ADDRESS"  class="pl-sm" />'
        }

        , {
            name: 'Actions', displayName: 'Actions', enableFiltering: false, enableColumnMenu: false, width: '30%', cellTemplate:
                '<div style="margin:1px;">' +
                '<button style="margin-bottom: 5px;" ng-show="grid.appScope.model.EDIT_PERMISSION == \'Active\'" ng-click="grid.appScope.EditUnitData(row.entity)" type="button" class="btn btn-outline-primary mb-1">Update</button>' +
                '<button style="margin-bottom: 5px;" ng-show="grid.appScope.model.EDIT_PERMISSION == \'Active\'" ng-click="grid.appScope.ActivateUnit(row.entity.DEPOT_ID)" type="button" class="btn btn-outline-success mb-1"  ng-disabled="row.entity.STATUS == \'Active\'">Activate</button>' +
                '<button style="margin-bottom: 5px;" ng-show="grid.appScope.model.EDIT_PERMISSION == \'Active\'" type="button" class="btn btn-outline-secondary mb-1" ng-disabled="row.entity.STATUS == \'InActive\'" ng-click="grid.appScope.DeactivateUnit(row.entity.DEPOT_ID)">Deactive</button>' +
                '</div>'
        },

    ];

    $scope.EditUnitData = function (entity) {
        $scope.model.DEPOT_ID = entity.DEPOT_ID;
        $scope.model.DEPOT_CODE = entity.DEPOT_CODE;
        $scope.model.DEPOT_NAME = entity.DEPOT_NAME;
        $scope.model.DEPOT_SHORT_NAME = entity.DEPOT_SHORT_NAME;
        $scope.model.DEPOT_ADDRESS = entity.DEPOT_ADDRESS;

        $scope.SaveData($scope.model);
    }

    $scope.SaveData = function (model) {
        $scope.showLoader = true;

        CompanyService.AddOrUpdateUnit(model).then(function (data) {
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

    $scope.ActivateUnit = function (Id) {
        $scope.showLoader = true;
        CompanyService.ActivateUnit(Id).then(function (data) {
            notificationservice.Notification(data.data, 1, 'Activated the selected Unit !!');
            if (data.data == 1) {
                $scope.showLoader = false;
                $scope.DataLoad();
            }
            else {
                $scope.showLoader = false;
            }
        });
    }

    $scope.DeactivateUnit = function (Id) {
        $scope.showLoader = true;
        CompanyService.DeactivateUnit(Id).then(function (data) {
            notificationservice.Notification(data.data, 1, 'Deactivated the selected Unit !!');
            if (data.data == 1) {
                $scope.showLoader = false;
                $scope.CompanyLoad();

                $scope.DataLoad();
            }
            else {
                $scope.showLoader = false;
            }
        });
    }
}]);