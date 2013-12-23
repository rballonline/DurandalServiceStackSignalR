requirejs.config({
	paths: {
		'text': '../Scripts/text',
		'durandal': '../Scripts/durandal',
		'plugins': '../Scripts/durandal/plugins',
		'transitions': '../Scripts/durandal/transitions'
	}
});

define('jquery', function() { return jQuery; });
define('knockout', ko);

define(['durandal/system', 'durandal/app', 'durandal/viewLocator', 'modules/hubService'], function (system, app, viewLocator, hubService) {
	//>>excludeStart("build", true);
	system.debug(true);
	//>>excludeEnd("build");

	app.title = 'Loading...';

	app.configurePlugins({
		router: true,
		dialog: true,
		widget: true
	});

	app.start().then(function () {
		//Replace 'viewmodels' in the moduleId with 'views' to locate the view.
		//Look for partial views in a 'views' folder in the root.
		viewLocator.useConvention();
		hubService.init();
		app.setRoot('viewmodels/shell', 'entrance');
	});
});