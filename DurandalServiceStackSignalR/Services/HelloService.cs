using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using DurandalServiceStackSignalR.Hubs;
using Microsoft.AspNet.SignalR;

namespace DurandalServiceStackSignalR.Services
{
	public class HelloService : Service
	{
		public object Any(Hello request)
		{
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