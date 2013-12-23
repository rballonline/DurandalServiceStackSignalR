define(function (require) {
	var router = require('plugins/router');
	var $ = require('jquery');
	var chat;

	var hubService = {
		usersOnlineMsg: ko.observable(null),
		init: function () {
			var self = this;
			chat = $.connection.chatHub;

			chat.client.broadcastMessage = function (name, message) {
				// Add the message to the page. 
				$('#discussion').append('<li><strong>' + htmlEncode(name)
										+ '</strong>: ' + htmlEncode(message) + '</li>');
			};
			
			$.connection.hub.start();
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