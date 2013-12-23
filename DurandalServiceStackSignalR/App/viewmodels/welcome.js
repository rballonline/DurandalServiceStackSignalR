define(['modules/hubService', 'durandal/app'], function (hubService, app) {
	var vm = function () {
		var self = this;
		this.message = ko.observable();
		this.messageHasFocus = ko.observable(true);
		this.messages = ko.observableArray();
		this.sendMessage = function () {
			hubService.sendMessage(this.message());
			this.message('');
			this.messageHasFocus(true);
		};

		app.on('new-message').then(function (message) {
			self.messages.push(message);
		});
	};

	return vm;
});