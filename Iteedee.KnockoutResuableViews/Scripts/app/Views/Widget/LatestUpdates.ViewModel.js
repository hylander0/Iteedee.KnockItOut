//Naming Convension used for RenderPartialKnockoutResource
// {}
APP.Widget.LatestUpdatesViewModel = function (model) {
    var self = model;
    self.AddNew = function () {
        $.post(APP.helpers.prepareRelativeUrl("Widget/PostUpdate"), APP.helpers.addAntiForgeryToken({ "update": $("#txtUpdate").val() }), function (data) {
            $("#txtUpdate").val("");
            ko.mapping.fromJS(data, {}, self);
        });
    }
	return ko.validatedObservable(self);
};