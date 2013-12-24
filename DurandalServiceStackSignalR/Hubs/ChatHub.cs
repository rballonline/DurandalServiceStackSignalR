using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace DurandalServiceStackSignalR.Hubs
{
	public class ChatHub : Hub
	{
		public ChatHub()
		{

		}

		public void Send(string message)
		{
			Clients.All.broadcastMessage(message);
		}
	}
}