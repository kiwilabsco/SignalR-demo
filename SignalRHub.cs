using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SignalR_Application
{
	public class SignalRHub: Hub
	{
		int sleepingTime = 3000; // Sleeping time as miliseconds

		public async System.Threading.Tasks.Task GenerateRandomNumbers(int minValue, int maxValue){
			await Task.Run(() => 
			{
				while(true){
					Random randObject = new Random();  
					var randValue = randObject.Next(minValue, maxValue);

					Clients.Caller.updateRandomValue(randValue);
					
					Thread.Sleep(sleepingTime);
				}

			});
		}

		public void GenerateRandomNumber(){
			Clients.Caller.sendRandValue(new Random().Next());
		}
	}
}