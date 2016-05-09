var csvApp = angular.module('csvApp');

csvApp.directive('csvFile', function($http) {
    return {
        restrict: 'E',
        scope: { },
        templateUrl: 'app/file/component.html',
        link: function(scope, element, attrs) {
            document.getElementById('js-file').onchange = function () {

                console.log("uploading...");

                var file = $('#js-import').find('input')[0].files[0],
                            formData = new FormData();
                formData.append('file0', file);

                $http
                    .post('http://localhost:8421/file/upload', formData, {
                        transformRequest: angular.identity,
                        headers: { 'Content-Type': undefined }
                    }).then(function (response) { });
            };
        }
    };
});
