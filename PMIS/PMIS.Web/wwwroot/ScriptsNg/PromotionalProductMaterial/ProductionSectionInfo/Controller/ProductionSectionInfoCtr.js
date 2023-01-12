ngApp.controller('ngGridCtrl', ['$scope', 'ProductionSectionInfoService', 'permissionProvider', 'notificationservice', 'gridregistrationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, ProductionSectionInfoService, permissionProvider, notificationservice, gridregistrationservice, $http, $log, $filter, $timeout, $interval, $q) {

    $scope.model = { SECTION_ID: 0, SECTION_CODE: '', SECTION_NAME: '', UNIT_ID: '', STATUS: '' }

    $scope.gridOptionsList = (gridregistrationservice.GridRegistration("Production Section Info"));

    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    }

    $scope.UnitList = [];

    $scope.DataLoad = function () {
        $scope.showLoader = true;
        ProductionSectionInfoService.GetSectionList().then(function (data) {

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

    $scope.GetUnitList = function () {
        $scope.showLoader = true;
        ProductionSectionInfoService.GetUnitList().then(function (data) {
            $scope.UnitList = data.data.Data;
        }, function (error) {
            alert(error);
            $scope.showLoader = false;
        });
    }

    $scope.ClearForm = function () {
        $scope.model.SECTION_ID = 0;
        $scope.model.SECTION_CODE = "";
        $scope.model.STATUS = "Active";
        $scope.model.SECTION_NAME = "";
        $scope.model.UNIT_ID = "";
    }

    $scope.Statuses = ["Active", "Inactive"]

    $scope.GetPermissionData = function () {
        $scope.showLoader = true;

        $scope.permissionReqModel = {
            Controller_Name: 'ProductionSectionInfo',
            Action_Name: 'frmProductionSectionInfo'
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
    $scope.GetUnitList();
    $scope.GetPermissionData();

    $scope.gridOptionsList.columnDefs = [
        { name: 'Sl.No.', field: 'ROW_NO', enableFiltering: false, width: 70 },
        {
            name: 'SECTION_ID', field: 'SECTION_ID', visible: false
        },
        {
            name: 'SECTION_CODE', field: 'SECTION_CODE', displayName: 'Section Code', enableFiltering: false, width: '20%', visible: true 
        },
        {
            name: 'SECTION_NAME', field: 'SECTION_NAME', displayName: 'Section Name', enableFiltering: false, width: '30%'
        },
        {
            name: 'UNIT_NAME', field: 'UNIT_NAME', displayName: 'Unit Name', enableFiltering: false, width: '28%'
        },
        {
            name: 'STATUS', field: 'STATUS', displayName: 'Status', enableFiltering: false, width: '15%'
        }
    ];

    $scope.gridOptionsList.rowTemplate = "<div ng-dblclick=\"grid.appScope.EditData(row.entity)\" title=\"Please double click to edit. \" ng-repeat=\"(colRenderIndex, col) in colContainer.renderedColumns track by col.colDef.name\" class=\"ui-grid-cell\" ng-class=\"{ 'ui-grid-row-header-cell': col.isRowHeader }\" ui-grid-cell></div>"

    $scope.Statuses = ["Active", "Inactive"]


    $scope.EditData = function (entity) {
        $scope.model.SECTION_ID = entity.SECTION_ID;
        $scope.model.SECTION_CODE = entity.SECTION_CODE;
        $scope.model.SECTION_NAME = entity.SECTION_NAME;
        $scope.model.UNIT_NAME = entity.UNIT_NAME;
        $scope.model.UNIT_ID = entity.UNIT_ID;
        $scope.model.STATUS = entity.STATUS;
    }


    $scope.SaveData = function (model) {
        $scope.showLoader = true;

        model.UNIT_NAME = $scope.UnitList.find(e => e.UNIT_ID == model.UNIT_ID)?.UNIT_NAME;

        ProductionSectionInfoService.AddOrUpdate(model).then(function (data) {

            notificationservice.Notification(data.data.Message, data.data.Success, data.data.Message);
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