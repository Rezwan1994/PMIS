ngApp.service("CompanyService", function ($http) {
    this.GetCompanyList = function () {
        return $http.get('../Company/LoadData');
    }

    this.AddOrUpdate = function (model) {
        var dataType = 'application/json; charset=utf-8';
        return $http({
            type: 'POST',
            method: 'POST',
            url: "../Company/AddOrUpdate",
            dataType: 'json',
            contentType: dataType,
            data: JSON.stringify(model),
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
        });
    }
    this.GetUnitList = function () {
        return $http.get('../Company/LoadUnitData');
    }

    this.AddOrUpdateUnit = function (model) {
        return $http.post("../Company/AddOrUpdateUnit", { DEPOT_ID: parseInt(model.DEPOT_ID), DEPOT_CODE: model.DEPOT_CODE, DEPOT_NAME: model.DEPOT_NAME, DEPOT_SHORT_NAME: model.DEPOT_SHORT_NAME, DEPOT_ADDRESS: model.DEPOT_ADDRESS });
    }

    this.ActivateUnit = function (model) {
        return $http.post("../Company/ActivateUnit", { DEPOT_ID: parseInt(model) });
    }
    this.DeactivateUnit = function (model) {
        return $http.post("../Company/DeactivateUnit", { DEPOT_ID: parseInt(model) });
    }
    this.GetCompany = function () {
        return $http.get('/SalesAndDistribution/Market/GetCompany');
    }
});