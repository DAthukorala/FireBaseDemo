//this service is responsible for maintaining data for current form
//it does this by inspecting name attributes of every control in the form and creating a json object with corresponding properties
//this part needs to be changed/replaced as needed to facilitate the current implementation of ez forms
function modelService(formId) {
    var self = this;

    self.data = {};

    //update data using the latest values from the changed control
    self.updateData = function (control) {
        var value = $(control).val();
        //if the control is a check box and if it is unchecked we need to clear the value
        if ($(control).attr('type') === "checkbox" && !$(control).is(":checked")) {
            value = "";
        }
        self.data[$(control).attr('name')] = value;
    }

    initializeDataModel(formId);

    //initialize the data model based on the name attributes of inputs in the form
    function initializeDataModel(formId) {
        $("#" + formId + " :input").each(function (i, control) {
            self.data[$(control).attr('name')] = "";
        })
    }

}