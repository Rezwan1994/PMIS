ngApp.service("permissionProvider", function ($http) {
    this.GetPermission = function (model) {
        return $http.post("/Security/MenuPermission/GetPermissions", JSON.stringify(model));
    }

    this.GetPermissionData = function (model, controller_name, action_name) {
        var permissionReqModel = {
            Controller_Name: controller_name,
            Action_Name: action_name
        }
        this.GetPermission(permissionReqModel).then(function (data) {
            model.ADD_PERMISSION = data.data.ADD_PERMISSION;
            model.EDIT_PERMISSION = data.data.EDIT_PERMISSION;
            model.DELETE_PERMISSION = data.data.DELETE_PERMISSION;
            model.LIST_VIEW = data.data.LIST_VIEW;
            model.DETAIL_VIEW = data.data.DETAIL_VIEW;
            model.DOWNLOAD_PERMISSION = data.data.DOWNLOAD_PERMISSION;
        }, function (error) {
            alert(error);
        });
    }
});