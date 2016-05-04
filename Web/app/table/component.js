var csvApp = angular.module('csvApp');
csvApp
.controller('csvTableCtrl', function($scope, $http) {
    $http.get("http://localhost:8421/items")
        .then(function(response) {
            $scope.items = response.data;
    });
})
.directive('csvTable', [function() {
    return {
        restrict: 'E',
        templateUrl: 'app/table/component.html',
        controller: 'csvTableCtrl'
    };
}]);
