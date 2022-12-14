ngApp.service("SupplierInfoService", function ($http) {

    this.GetCategoryList = function () {
        return $http.get('../SupplierInfo/Get');
    }

    this.AddOrUpdate = function (model) {
        var dataType = 'application/json; charset=utf-8';
        return $http({
            type: 'POST',
            method: 'POST',
            url: "../SupplierInfo/Post",
            dataType: 'json',
            contentType: dataType,
            data: JSON.stringify(model),
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
        });
    }
});