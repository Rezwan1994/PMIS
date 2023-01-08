ngApp.service("CategoryInfoService", function ($http) {
    this.GetCategoryList = function () {
        return $http.get('../CategoryInfo/LoadData');
    }

    this.AddOrUpdate = function (model) {
        var dataType = 'application/json; charset=utf-8';
        return $http({
            type: 'POST',
            method: 'POST',
            url: "../CategoryInfo/AddOrUpdate",
            dataType: 'json',
            contentType: dataType,
            data: JSON.stringify(model),
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
        });
    }
});