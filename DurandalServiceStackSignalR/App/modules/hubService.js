define(function (require) {
	var router = require('plugins/router');
	var $ = require('jquery');
	var app = require('durandal/app');
	var chat;

	var hubService = {
		usersOnlineMsg: ko.observable(null),
		init: function () {
			var self = this;
			chat = $.connection.chatHub;

			chat.client.broadcastMessage = function (message) {
				app.trigger('new-message', message);
			};

		},
		sendMessage: function (message) {
			chat.server.send(message);
		}
	};

	function htmlEncode(value) {
		var encodedValue = $('<div />').text(value).html();
		return encodedValue;
	}

	return hubService;
});