//this service is responsible for saving and reading data from firebase cloud storage
//it wil call the restful web api and save or read data using the exposed end points
function backupService() {

    var self = this;
    self.savedData;

    self.saveData = function (backup) {
        $.post("https://localhost:44315/api/values", backup, function () {
            //update the current back up data value, to be uses for equality checks in the next run
            self.savedData = JSON.stringify(backup);
        });
    }

    self.readData = function (id) {
        //retrieve data stored in firebase based on its id (practiceId_formName)
        return $.get("https://localhost:44315/api/values/" + id, function (data) {
            return data;
        });
    }
}