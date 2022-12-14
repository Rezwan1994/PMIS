ngApp.controller('ngGridCtrl', ['$scope', 'PMInfoService', 'permissionProvider', 'notificationservice', 'gridregistrationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, pmInfoService, permissionProvider, notificationservice, gridregistrationservice, $http, $log, $filter, $timeout, $interval, $q) {
    $scope.model = { PM_ID: 0, PM_CODE: '', PM_NAME: '', PACK_SIZE: '', PM_CATEGORY_CODE: '', STATUS: '', REMARKS: '' }
    $scope.gridOptionsList = (gridregistrationservice.GridRegistration("PM Info List"));
    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    }
    $scope.CategoryList = [];
    $scope.SBUList = [];
    $scope.DataLoad = function () {
        $scope.showLoader = true;
        pmInfoService.GetPMList().then(function (data) {
            
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
    $scope.GetCategoryList = function () {
        $scope.showLoader = true;
        pmInfoService.GetCategoryList().then(function (data) {
            
            $scope.CategoryList = data.data.Data;

        }, function (error) {
            alert(error);
            $scope.showLoader = false;
        });
    }
    $scope.GetSBUList = function () {
        $scope.showLoader = true;
        pmInfoService.GetSBUList().then(function (data) {
            debugger;
            $scope.SBUList = data.data.Data;

        }, function (error) {
            alert(error);
            $scope.showLoader = false;
        });
    }
    $scope.ClearForm = function () {
        $scope.model.PM_ID = 0;
        $scope.model.PM_CODE = "";
        $scope.model.PACK_SIZE = "";
        $scope.model.PM_CATEGORY_ID = "";
        $scope.model.SBU_CODE = "";
        $scope.model.STATUS = "Active";
        $scope.model.PM_NAME = "";
        $scope.model.REMARKS = "";
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
    $scope.GetCategoryList();
    $scope.GetSBUList();
    $scope.GetPermissionData();

    $scope.gridOptionsList.columnDefs = [
        { name: 'SL', field: 'ROW_NO', enableFiltering: false, width: 50 }
        , { name: 'PM_ID', field: 'PM_ID', visible: false }
        , {
            name: 'PM_CODE', field: 'PM_CODE', displayName: 'PM Code', enableFiltering: false, width: '20%'
              
        }
        , {
            name: 'PM_NAME', field: 'PM_NAME', displayName: 'PM Name', enableFiltering: false, width: '20%'
               
        }
        ,
        {
            name: 'PM_CATEGORY_NAME', field: 'PM_CATEGORY_NAME', displayName: 'Category Name', enableFiltering: false, width: '25%'

        },
        {
            name: 'SBU_CODE', field: 'SBU_CODE', displayName: 'Sbu', enableFiltering: false, width: '15%'

        },
        {
            name: 'PACK_SIZE', field: 'PACK_SIZE', displayName: 'Pack Size', enableFiltering: false, width: '15%'
       
        },
        {
            name: 'STATUS', field: 'STATUS', displayName: 'Status', enableFiltering: false, width: '10%'
               
        }

    ];

    $scope.gridOptionsList.rowTemplate = "<div ng-dblclick=\"grid.appScope.EditData(row.entity)\" title=\"Please double click to edit. \" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name\" class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" ui-grid-cell></div>"

    $scope.Statuses = ["Active", "Inactive"]
    $scope.EditData = function (entity) {
        
        $scope.model.PM_ID = entity.PM_ID;
        $scope.model.PM_CODE = entity.PM_CODE;
        $scope.model.SBU_CODE = entity.SBU_CODE;
        $scope.model.PM_NAME = entity.PM_NAME;
        $scope.model.PM_CATEGORY_NAME = entity.PM_CATEGORY_NAME;
        $scope.model.PM_CATEGORY_ID = entity.PM_CATEGORY_ID;
        $scope.model.PACK_SIZE = entity.PACK_SIZE;
        $scope.model.STATUS = entity.STATUS;
        //$scope.SaveData($scope.model);
    }

    $scope.DeletePMtInfo = function (Id) {
        $scope.showLoader = true;
        if (window.confirm("Are you sure to delete this promotional material?")) {
            
            pmInfoService.DeletePMInfo(Id).then(function (data) {
                notificationservice.Notification(data.data.Success, true, 'Deleted the selected material !!');
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
        for (var i = 0; i < $scope.CategoryList.length; i++) {
            if ($scope.CategoryList[i].PM_CATEGORY_ID == model.PM_CATEGORY_ID) {
                model.PM_CATEGORY_NAME = $scope.CategoryList[i].PM_CATEGORY_NAME;
            }
        }
        pmInfoService.AddOrUpdate(model).then(function (data) {
            
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