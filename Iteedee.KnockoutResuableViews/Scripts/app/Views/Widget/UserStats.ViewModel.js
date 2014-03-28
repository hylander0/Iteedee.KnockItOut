//Naming Convension used for RenderPartialKnockoutResource
// {}
    APP.Widget.UserStatsViewModel = function (model) {
        var self = model;
        self.refresh = function () {
            $.post(APP.helpers.prepareRelativeUrl("Widget/UpdateUserStats"), APP.helpers.addAntiForgeryToken({}), function (data) {
                ko.mapping.fromJS(data, {}, self);
            });
        }
        return ko.validatedObservable(self);
    };

