ngApp.service("ProductionSectionInfoService", function ($http) {
    this.GetSectionList = function () {
        return $http.get('../ProductionSectionInfo/GetSectionList');
    }
    this.GetUnitList = function () {
        return $http.get('../ProductionSectionInfo/GetUnitList');
    }
    this.AddOrUpdate = function (model) {
        var dataType = 'application/json; charset=utf-8';
        return $http({
            type: 'POST',
            method: 'POST',
            dataType: 'json',
            url: "../ProductionSectionInfo/Post",
            contentType: dataType,
            data: JSON.stringify(model),
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
        });
    }
});