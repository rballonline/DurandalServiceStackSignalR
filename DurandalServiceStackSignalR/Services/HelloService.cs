using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using DurandalServiceStackSignalR.Hubs;
using Microsoft.AspNet.SignalR;

namespace DurandalServiceStackSignalR.Services
{
	public interface IHelloService
	{
		object Any(Hello request);
	}

	public class HelloService : Service, IHelloService
	{
		public object Any(Hello request)
		{
			var hub = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
			hub.Clients.All.Invoke("broadcastMessage", "Hello, " + request.Name);

			return new HelloResponse { Result = "Hello, " + request.Name };
		}
	} 

	[Route("/hello")]
	[Route("/hello/{Name}")]
	public class Hello
	{
		public string Name { get; set; }
	}

	public class HelloResponse
	{
		public string Result { get; set; }
	}


}