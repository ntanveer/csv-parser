var csvApp = angular.module('csvApp');
csvApp.controller('csvFileCtrl', function ($http) {
    this.uploadFile = function () {

        console.log("button clicked.");

        var file = $('#js-import').find('input')[0].files[0],
                    formData = new FormData();
            formData.append('file0', file);

            $http
                .post('http://localhost:8421/file/upload', formData, {})
                .then(function(response) {});
    };
})
.directive('csvFile', [function() {
    return {
        restrict: 'E',
        templateUrl: 'app/file/component.html',
        controller: 'csvFileCtrl'
    };
}]);
