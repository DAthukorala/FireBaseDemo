//the persistenceService is responsible for managing all data saving tasks
//both local and cloud
//the service will watch for changes in inputs and trigger updates to the data model using modelService
//it will persist those input changes in the local indexeddb as it happens 
//it will also save data to the cloud in a set interval using backupService
function persistenceService(formId) {
    var self = this;
    self.key;

    //save data in local indexeddb
    self.saveData = function () {
        //we don't need to worry about handling call backs.
        //we can just let the save process run asynchronously and keep on saving the latest in time intervals
        //we will only clear the data when the user exit the form and navigate to another form
        //there will always be a copy of the current data snapshot in the indexeddb
        localforage.setItem(self.key, self.db.data);
    }

    //read data stored in the local indexeddb
    self.readData = function () {
        return localforage.getItem(self.key).then(function (savedData) {
            return savedData;
        });
    }

    function initialize(formId) {
        self.key = formId;
        //initialize model service and data model
        self.db = new modelService(formId);

        //initialized local indexeddb instance 
        localforage.config({
            driver: [localforage.INDEXEDDB, localforage.WEBSQL, localforage.LOCALSTORAGE], //set the fall back strategy
            name: 'EHR',
            storeName: 'AutoSaveData',
            description: 'Hold data that are auto saved for the currently active EZ Form'
        });

        //listen for changes in form inputs, and save them in indexed db
        $("#" + formId + "").on('keyup change paste', ':input', function () {
            self.db.updateData($(this));//sync the data model with the new changes
            self.saveData();
        });

        //save data in fire store in a set interval
        setInterval(function () {
            //create the backup document
            var dataToSave = {
                id: "testClient_" + formId,
                formData: JSON.stringify(self.db.data)
            };
            //save in cloud
            backupService.saveData(dataToSave);
        }, 60000);
    }

    initialize(formId);
}