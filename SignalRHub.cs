using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR_Application
{
	public class SignalRHub: Hub
	{
		int sleepingTime = 3000; // Sleeping time as miliseconds

		// Async Function for generating numbers in sleepingTime period
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

		// Async Function for generating numbers and updating the chart in sleepingTimePeriod
		public async System.Threading.Tasks.Task prepareDataForChart(int minValue, int maxValue){
			await Task.Run(() => 
			{
				while(true){
					Random randObject = new Random();  
					int[] dataArray = {randObject.Next(minValue, maxValue),
									   randObject.Next(minValue, maxValue),
									   randObject.Next(minValue, maxValue),
									   randObject.Next(minValue, maxValue),
									   randObject.Next(minValue, maxValue)};
					

					Clients.Caller.getChartData(dataArray);
					
					Thread.Sleep(sleepingTime);
				}

			});
		}

		public void GenerateRandomNumber(){
			Clients.Caller.sendRandValue(new Random().Next());
		}
	}
}