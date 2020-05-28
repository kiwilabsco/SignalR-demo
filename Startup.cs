using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalR_Application.Startup))]

namespace SignalR_Application
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// Initiliaze the SignalR 
			app.MapSignalR();
		}
	}
}
