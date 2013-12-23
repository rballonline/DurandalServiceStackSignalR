define(['modules/hubService'], function (hubService) {
	var vm = function () {
		this.messageSelected = ko.observable(true);
		this.message = ko.observable();
		this.sendMessage = function () {
			hubService.sendMessage(this.message());
			this.message('');
			this.messageSelected(true);
		};
	};

	return vm;
});