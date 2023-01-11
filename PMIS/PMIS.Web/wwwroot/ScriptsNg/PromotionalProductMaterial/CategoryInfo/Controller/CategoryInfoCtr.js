ngApp.controller('ngGridCtrl', ['$scope', 'CategoryInfoService', 'permissionProvider', 'notificationservice', 'gridregistrationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, categoryInfoService, permissionProvider, notificationservice, gridregistrationservice, $http, $log, $filter, $timeout, $interval, $q) {

    $scope.model = { PM_CATEGORY_ID: 0, PM_CATEGORY_CODE: '', PM_CATEGORY_NAME: '', STATUS: '', REMARKS: '' }

    $scope.gridOptionsList = (gridregistrationservice.GridRegistration("Promotional Material Category"));

    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    }

    $scope.DataLoad = function () {
        $scope.showLoader = true;
        categoryInfoService.GetCategoryList().then(function (data) {
            
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

        {
            name: 'Sl.No.', field: 'ROW_NO', enableFiltering: false, width: 60

        },

        {
            name: 'PM_CATEGORY_ID', field: 'PM_CATEGORY_ID', visible: false
        },

        {
            name: 'PM_CATEGORY_CODE', field: 'PM_CATEGORY_CODE', displayName: 'Category Code', enableFiltering: false, width: '20%'
            /*, cellTemplate:'<input  disabled ng-model="row.entity.PM_CATEGORY_CODE"  class="pl-sm" />'*/
        },

        {
            name: 'PM_CATEGORY_NAME', field: 'PM_CATEGORY_NAME', displayName: 'Category Name', enableFiltering: false, width: '35%'
            /*, cellTemplate:'<input  disabled  type="text"  ng-model="row.entity.PM_CATEGORY_NAME"  class="pl-sm" />'*/
        },

        {
            name: 'REMARKS', field: 'REMARKS', displayName: 'Remarks', enableFiltering: false, width: '25%'
            /*, cellTemplate:'<input  disabled type="text"  ng-model="row.entity.REMARKS"  class="pl-sm" />'*/
        },

        {
            name: 'STATUS', field: 'STATUS', displayName: 'Status', enableFiltering: false, width: '14%'
            /*, cellTemplate:'<input  disabled type="text"  ng-model="row.entity.STATUS"  class="pl-sm" />'*/
        }

        //,
        //, {
        //    name: 'Actions', displayName: 'Actions', enableFiltering: false, enableColumnMenu: false, width: '20%', cellTemplate:
        //        '<div style="margin:1px;">' +
        //        '<button style="margin-bottom: 5px;" ng-show="grid.appScope.model.EDIT_PERMISSION == \'Active\'" ng-click="grid.appScope.EditData(row.entity)" type="button" class="btn btn-outline-primary mb-1">Update</button>' +
        //        '<button style="margin-bottom: 5px; margin-left:5px;"  ng-show="grid.appScope.model.DELETE_PERMISSION == \'Active\'"  ng-click="grid.appScope.DeleteCategorytInfo(row.entity.PM_CATEGORY_ID)" type="button" class="btn btn-outline-danger mb-1">Delete</button>' +
        //        '</div>'
        //},

    ];

    $scope.gridOptionsList.rowTemplate = "<div ng-dblclick=\"grid.appScope.EditData(row.entity)\" title=\"Please double click to update. \" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name\" class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" ui-grid-cell></div>"

    $scope.EditData = function (entity) {
        $scope.model.PM_CATEGORY_ID = entity.PM_CATEGORY_ID;
        $scope.model.PM_CATEGORY_CODE = entity.PM_CATEGORY_CODE;
        $scope.model.PM_CATEGORY_NAME = entity.PM_CATEGORY_NAME;
        $scope.model.REMARKS = entity.REMARKS;
        $scope.model.STATUS = entity.STATUS;

    }


    $scope.Statuses = ["Active", "Inactive"]

    $scope.DeleteCategorytInfo = function (Id) {
        $scope.showLoader = true;
        if (window.confirm("Are you sure to delete this Menu Category?")) {
            categoryInfoService.DeleteCategoryInfo(Id).then(function (data) {
                notificationservice.Notification(data.data.Success, true, 'Deleted the selected category !!');
                if (data.data.Success == true) {
                    $scope.showLoader = false;
                    $scope.DataLoad();
                }
                else {
                    $scope.showLoader = false;
                }
            });
        }
    }


    $scope.SaveData = function (model) {
        $scope.showLoader = true;

        categoryInfoService.AddOrUpdate(model).then(function (data) {
            
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