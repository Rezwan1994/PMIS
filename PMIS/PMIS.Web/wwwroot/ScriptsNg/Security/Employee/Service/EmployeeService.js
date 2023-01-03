ngApp.service("EmployeeService", function ($http) {
    this.GetEmployeeList = function () {
        return $http.get('../Employee/LoadData');
    }

    this.AddOrUpdate = function (model) {
        var dataType = 'application/json; charset=utf-8';
        return $http({
            type: 'POST',
            method: 'POST',
            url: "../Employee/AddOrUpdate",
            dataType: 'json',
            contentType: dataType,
            data: JSON.stringify(model),
            headers: { 'Content-Type': 'application/json; charset=utf-8' },
        });
    }
});