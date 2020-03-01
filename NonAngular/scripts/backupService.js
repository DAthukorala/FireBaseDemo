var backupService = new function () {

    var self = this;
    self.savedData;

    self.saveData = function (backup) {
        var dataToBackup = JSON.stringify(backup);
        //check if the data has been changed
        if (dataToBackup !== self.savedData) {
            //if yes call the web api to save data in fire store
            $.post("https://localhost:44315/api/values", backup, function () {
                self.savedData = dataToBackup;
            });
        }
    }

    self.readData = function (id) {
        return $.get("https://localhost:44315/api/values/" + id, function (data) {
            return data;
        });
    }
}