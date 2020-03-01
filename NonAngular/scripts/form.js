$(function () {
    //initialize persistence service
    var service = new persistenceService("sampleForm");

    //fetch and show saved data from the index db
    $("#btnShowLocalData").click(function () {
        service.readData().then(function (data) {
            $("#lblSavedLocalData").text(JSON.stringify(data));
        });
    });

    //fetch and show saved data from firebase cloud storage
    $("#btnShowCloudData").click(function () {
        backupService.readData("testClient_sampleForm").then(function (data) {
            $("#lblSavedCloudData").text(JSON.stringify(data));
        });
    });

})