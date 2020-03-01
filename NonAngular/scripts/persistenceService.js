function persistenceService(formId) {
    var self = this;
    self.key;

    self.saveData = function () {
        //we don't need to worry about handling call backs.
        //we can just let the save process run asynchronously and keep on saving the latest in time intervals
        //we will only clear the data when the user exit the form
        localforage.setItem(self.key, self.db.data);
    }

    self.readData = function () {
        return localforage.getItem(self.key).then(function(savedData) {
            return savedData;
          });
    }

    function initialize(formId) {
        self.key = formId;
        //initialize model service and data model
        self.db = new modelService(formId);

        localforage.config({
            driver: [localforage.INDEXEDDB, localforage.WEBSQL, localforage.LOCALSTORAGE], //set the fall back strategy
            name: 'EHR',
            storeName: 'AutoSaveData', // Should be alphanumeric, with underscores.
            description: 'Hold data that are auto saved for the currently active EZ Form'
        });

        //listen for change in form inputs, and save them in indexed db
        $("#" + formId + "").on('keyup change paste', ':input', function () {
            self.db.updateData($(this));
            self.saveData();
        });

        //save data in fire store every 60 seconds
        setInterval(function() {
            var dataToSave={id:"testClient_"+formId, formData:JSON.stringify(self.db.data)};
            backupService.saveData(dataToSave);
        }, 5000);//60000
    }

    initialize(formId);
}