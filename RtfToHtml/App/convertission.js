var app = angular.module('app',[]);
app.controller('controller', function ($scope, $http, FileUploadService) {


    var init = function () {
        $scope.fixe = true;
        $scope.titre = false;
    };
    

    $scope.clean = function () {
        init();
    }
    

  
    init();
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;
    var x = "";
    

    $scope.html = function () {
        $scope.SelectedFileForUpload = document.getElementById('file').files[0];
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
       // $scope.ChechFileValid($scope.SelectedFileForUpload);
        FileUploadService.UploadFile($scope.SelectedFileForUpload).then(function (d) {
            alert(d.Message);
            ClearForm();
            
        }, function (e) {
            alert(e);
          
        })
    }

    function ClearForm() {
        $scope.FileDescription = x;
        $scope.fixe = false;
        $scope.titre = true;
        angular.forEach(angular.element("input[type='file']"), function (inputElem) {
            angular.element(inputElem).val(null);
        });

        $scope.f1.$setPristine();
        $scope.IsFormSubmitted = false;
    }
}).factory('FileUploadService', function ($http, $q) {
    var fac = {};
    
    fac.UploadFile = function (file) {
        var formData = new FormData();
        formData.append("file", file);
        
        var defer = $q.defer();
        $http.post("/Tokenizer/SaveFiles", formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })

           
        

    
        
 
    }
    
    return fac;
 
})
    