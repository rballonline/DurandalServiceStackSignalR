using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ServiceStack;
using DurandalServiceStackSignalR.Services;
using Microsoft.AspNet.SignalR;
using DurandalServiceStackSignalR.Hubs;

namespace DurandalServiceStackSignalR
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public class AppHost : AppHostBase
		{
			//Tell Service Stack the name of your application and where to find your web services
			public AppHost() : base("Hello Web Services", typeof(HelloService).Assembly) { }

			public override void Configure(Funq.Container container)
			{
				GlobalHost.DependencyResolver = new FunqDependencyResolver(container); 
				SetConfig(new HostConfig { HandlerFactoryPath = "api" });

				container.Register<IHelloService>(new HelloService());

				//register any dependencies your services use, e.g:
				//container.Register<ICacheClient>(new MemoryCacheClient());
			}
		}


		protected void Application_Start()
		{
			RouteTable.Routes.MapHubs();
			AreaRegistration.RegisterAllAreas();

			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			new AppHost().Init();
		}
	}
}