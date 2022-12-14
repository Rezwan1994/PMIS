ngApp.controller('ngGridCtrl', ['$scope', 'UserServices', 'permissionProvider', 'CompanyService', 'notificationservice', 'gridregistrationservice', '$http', '$log', '$filter', '$timeout', '$interval', '$q', function ($scope, UserServices, permissionProvider, CompanyService, notificationservice, gridregistrationservice, $http, $log, $filter, $timeout, $interval, $q) {
    $scope.model = { USER_ID: 0, USER_NAME: '', COMPANY_ID: 0, DEPOT_ID: 0 }
    $scope.CompanyData = [];
    $scope.DepotData = [];
    $scope.UserTypeData = [];
    $scope.EmployeeData = [];

    $scope.gridOptionsList = (gridregistrationservice.GridRegistration("User Ctr"));
    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
    }

    $scope.CompanyDataLoad = function () {
        CompanyService.GetCompanyList().then(function (data) {
            $scope.CompanyData = data.data;
        }, function (error) {
        });
    }

    $scope.CompanyLoad = function () {
        $scope.showLoader = true;

        CompanyService.GetCompany().then(function (data) {
            $scope.model.COMPANY_ID = parseInt(data.data);
            $scope.model.COMPANY_SEARCH_ID = parseInt(data.data);
            $interval(function () {
                $('#COMPANY_ID').trigger('change');
            }, 800, 4);

            $scope.showLoader = false;
        }, function (error) {
            alert(error);

            $scope.showLoader = false;
        });
    }
    $scope.DepotDataLoad = function () {
        CompanyService.GetDepotList().then(function (data) {
            $scope.DepotData = data.data;
        }, function (error) {
        });
    }
    $scope.UserTypeDataLoad = function () {
        $scope.UserType = {
            Type: 'General'
        }
        $scope.UserType1 = {
            Type: 'Admin'
        }
        $scope.UserType2 = {
            Type: 'Distributor'
        }
        $scope.UserType3 = {
            Type: 'DSM'
        }
        $scope.UserType4 = {
            Type: 'SM'
        }
        $scope.UserType5 = {
            Type: 'HOS'
        }
        $scope.UserTypeData.push($scope.UserType);
        $scope.UserTypeData.push($scope.UserType1);
        $scope.UserTypeData.push($scope.UserType2);
        $scope.UserTypeData.push($scope.UserType3);
        $scope.UserTypeData.push($scope.UserType4);
        $scope.UserTypeData.push($scope.UserType5);

        if ($scope.model.UserType == 'SuperAdmin') {
            $scope.UserType2 = {
                Type: 'SuperAdmin'
            }
            $scope.UserTypeData.push($scope.UserType2);
        }
    }

    $scope.typeaheadSelectedCompany = function (entity) {
        $scope.model.COMPANY_ID = entity.COMPANY_ID;
        $scope.DepotDataLoad();
    };
    $scope.DataLoad = function () {
        $scope.showLoader = true;
        UserServices.LoadData().then(function (data) {
            $scope.gridOptionsList.data = data.data;
            $scope.ParantData = data.data;

            $scope.showLoader = false;
        }, function (error) {
            alert(error);

            $scope.showLoader = false;
        });
    }
    $scope.ClearForm = function () {
        $scope.model.USER_ID = 0;
        $scope.model.USER_NAME = "";
        $scope.model.COMPANY_ID = 0;
        $scope.model.DEPOT_ID = 0;
        $scope.model.USER_TYPE = '';
        $scope.model.EMPLOYEE_ID = '';
        $scope.model.EMAIL = '';
    }

    $scope.EditData = function (entity) {
        $scope.model.USER_ID = entity.USER_ID;
        $scope.model.USER_PASSWORD = entity.USER_PASSWORD;
        $scope.model.USER_NAME = entity.USER_NAME;
        $scope.model.EMAIL = entity.EMAIL;
        $scope.model.EMPLOYEE_ID = entity.EMPLOYEE_ID;
        $scope.model.USER_TYPE = entity.USER_TYPE;
        $scope.model.DEPOT_ID = entity.DEPOT_ID;

        $scope.SaveData($scope.model);
    }
    $scope.GetPermissionData = function () {
        $scope.showLoader = true;

        $scope.permissionReqModel = {
            Controller_Name: 'User',
            Action_Name: 'Index'
        }
        permissionProvider.GetPermission($scope.permissionReqModel).then(function (data) {
            $scope.getPermissions = data.data;
            $scope.model.ADD_PERMISSION = $scope.getPermissions.ADD_PERMISSION;
            $scope.model.EDIT_PERMISSION = $scope.getPermissions.EDIT_PERMISSION;
            $scope.model.DELETE_PERMISSION = $scope.getPermissions.DELETE_PERMISSION;
            $scope.model.LIST_VIEW = $scope.getPermissions.LIST_VIEW;
            $scope.model.DETAIL_VIEW = $scope.getPermissions.DETAIL_VIEW;
            $scope.model.DOWNLOAD_PERMISSION = $scope.getPermissions.DOWNLOAD_PERMISSION;
            $scope.model.USER_TYPE = $scope.getPermissions.useR_TYPE;
            $scope.showLoader = false;
        }, function (error) {
            alert(error);

            $scope.showLoader = false;
        });
    }

    $scope.GetEmployeeData = function () {
        UserServices.GetEmployees($scope.model.COMPANY_ID).then(function (data) {
            $scope.EmployeeData = data.data;
        }, function (error) {
        });
    }
    $scope.DataLoad();
    $scope.GetPermissionData();
    $scope.UserTypeDataLoad()
    $scope.CompanyDataLoad();
    $scope.DepotDataLoad(0);
    $scope.GetEmployeeData();
    $scope.CompanyLoad();

    $scope.gridOptionsList.columnDefs = [
        {
            name: 'SL', field: 'ROW_NO', enableFiltering: false, width: 50
        }

        , {
            name: 'USER_ID', field: 'USER_ID', visible: false
        }


        , {
            name: 'COMPANY_ID', field: 'COMPANY_ID', visible: false
        }


        , {
            name: 'EMAIL', field: 'EMAIL', displayName: 'User Name', enableFiltering: true, width: '25%', cellTemplate:
                '<input required="required"  type="text"  ng-model="row.entity.EMAIL"  class="pl-sm" />'
        }


        , {
            name: 'USER_PASSWORD', field: 'USER_PASSWORD', displayName: 'Password', enableFiltering: true, width: '25%'
        }



        , {
            name: 'USER_NAME', field: 'USER_NAME', displayName: 'Employee Name', enableFiltering: true, width: '30%'
        }


        , {
            name: 'USER_TYPE', field: 'USER_TYPE', displayName: 'User Type', enableFiltering: true, visible: true, width: '15%'
        }






        , {
            name: 'EMPLOYEE_ID', field: 'EMPLOYEE_ID', displayName: 'Employee Name', visible:false,enableFiltering: true, width: ' 25%', cellTemplate:
                '<input required="required"  type="text"  ng-model="row.entity.EMPLOYEE_ID"  class="pl-sm" />'
        }




        , {
            name: 'COMPANY_NAME', field: 'COMPANY_NAME', displayName: 'Company', enableFiltering: true, visible: false, width: ' 22%'
        }






 

        , {
            name: 'Actions', displayName: 'Actions', width: '20%', visible: false, enableFiltering: false, enableColumnMenu: false, cellTemplate:
                '<div style="margin:1px;">' +
                '<button style="margin-bottom: 5px;" ng-show="grid.appScope.model.EDIT_PERMISSION == \'Active\'" ng-click="grid.appScope.EditData(row.entity)" type="button" class="btn btn-outline-primary mb-1">Update</button>' +
                '</div>'
        },

    ];

    $scope.SaveData = function (model) {
        $scope.showLoader = true;
        
        model.DEPOT_ID = parseInt(model.DEPOT_ID);
        UserServices.AddOrUpdate(model).then(function (data) {
            $scope.model.DEPOT_ID = $scope.model.DEPOT_ID.toString();
            notificationservice.Notification(data.data, 1, 'Temporary password sent to your mail. !!');
            if (data.data == 1) {
                $scope.showLoader = false;
                $scope.DataLoad();
                $scope.model.Name = "";
                $scope.model.SerialNo = "";
            }
            else {
                $scope.showLoader = false;
            }
        });
    }

    $scope.ActivateMenu = function (Id) {
        $scope.showLoader = true;
        MenuMasterServices.ActivateMenu(Id).then(function (data) {
            notificationservice.Notification(data.data, 1, 'Activated the selected category !!');
            if (data.data == 1) {
                $scope.showLoader = false;
                $scope.DataLoad();
            }
            else {
                $scope.showLoader = false;
            }
        });
    }

    $scope.DeactivateMenu = function (Id) {
        $scope.showLoader = true;
        MenuMasterServices.DeactivateMenu(Id).then(function (data) {
            notificationservice.Notification(data.data, 1, 'Deactivated the selected category !!');
            if (data.data == 1) {
                $scope.showLoader = false;
                $scope.DataLoad();
            }
            else {
                $scope.showLoader = false;
            }
        });
    }
    $scope.DeleteMenu = function (Id) {
        $scope.showLoader = true;
        if (window.confirm("Are you sure to delete this Menu Category?")) {
            MenuMasterServices.DeleteMenu(Id).then(function (data) {
                notificationservice.Notification(data.data, 1, 'Deleted the selected category !!');
                if (data.data == 1) {
                    $scope.showLoader = false;
                    $scope.DataLoad();
                }
                else {
                    $scope.showLoader = false;
                }
            });
        }
    }
}]);