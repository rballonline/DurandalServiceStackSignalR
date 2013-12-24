define(['plugins/router', 'durandal/app', 'modules/hubService'], function (router, app, hubService) {
    return {
    	router: router,
    	hubService: hubService,
        search: function() {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: '', title:'Welcome', moduleId: 'viewmodels/welcome', nav: true }/*,
                { route: 'flickr', moduleId: 'viewmodels/flickr', nav: true }*/
            ]).buildNavigationModel();
            
            return router.activate();
        }
    };
});