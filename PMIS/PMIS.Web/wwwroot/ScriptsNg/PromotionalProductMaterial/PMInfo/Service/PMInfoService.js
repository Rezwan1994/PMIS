ngApp.service("PMInfoService", function ($http) {
    this.GetPMList = function () {
        return $http.get('../PMInfo/Get');
    }
    this.GetCategoryList = function () {
        return $http.get('../CategoryInfo/Get');
    }
    this.DeletePMInfo = function (Id) {

        return $http.delete("../PMInfo/Delete/"+Id);
    }
    this.AddOrUpdate = function (model) {
        var dataType = 'application/json; charset=utf-8';
        return $http({
            type: 'POST',
            method: 'POST',
            url: "../PMInfo/Post",
            dataType: 'json',
            contentType: dataType,
            data: JSON.stringify(model),
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
        });
    }
});