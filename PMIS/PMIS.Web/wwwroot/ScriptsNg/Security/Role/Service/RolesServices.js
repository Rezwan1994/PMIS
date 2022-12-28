﻿ngApp.service("RolesServices", function ($http) {
    this.GetRoles = function (companyId) {
        return $http.post('../Role/LoadData', { COMPANY_ID: parseInt(companyId) });
    }
  
    
    this.AddOrUpdate = function (model) {

        var dataType = 'application/json; charset=utf-8';
        return $http({
            type: 'POST',
            method: 'POST',
            url: "../Role/AddOrUpdate",
            dataType: 'json',
            contentType: dataType,
            data: { COMPANY_ID: parseInt(model.COMPANY_ID), ROLE_ID: model.ROLE_ID, ROLE_NAME: model.ROLE_NAME, DEPOT_ID: parseInt(model.DEPOT_ID) },
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
        });

    }


    this.ActivateRole = function (Id) {
        
        return $http.post("../Role/ActivateRole", { ROLE_ID: Id });
    }
    this.DeactivateRole = function (Id) {
        
        return $http.post("../Role/DeactivateRole", { ROLE_ID: Id });
    }

    this.GetSearchableRoles = function (role_name, companyId) {
        
        return $http.post("../Role/GetSearchableRoles", { ROLE_NAME: role_name, COMPANY_ID: parseInt(companyId) });
    }
    this.RoleMenuConfigSelectionList = function (Id, companyId) {
        
        return $http.post("../Role/RoleMenuConfigSelectionList", { ROLE_ID: Id, COMPANY_ID: parseInt(companyId) });
    }
    this.SaveRoleMenuPermission = function (model) {
        
        
        return $http.post("../Role/SaveRoleMenuConfiguration", JSON.stringify(model) );
    }
    this.GetCompanyList = function () {
        return $http.get('../Company/LoadData');
    }
    this.GetDepotList = function (value) {
        return $http.get('/Security/Company/LoadDepotData');
    }
    this.GetCompany = function () {
        return $http.get('/Security/Company/GetCompany');
    }
});