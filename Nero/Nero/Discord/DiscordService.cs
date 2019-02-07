using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nero.Discord.Data;
using Newtonsoft.Json;

namespace Nero.Discord
{
	public class DiscordService
	{
		private readonly HttpClient _discordHttpClient;

		public DiscordService()
		{
			_discordHttpClient = new HttpClient();
		}

		public void Connect()
		{
			var filePath = "Data/DiscordBotToken.config";
			if (!System.IO.File.Exists(filePath))
				Console.WriteLine("Failed to fetch the bot token to log in to Discord");

			var fileContents = System.IO.File.ReadAllLines(filePath);
			var botToken = string.Join(",", fileContents);

			// TODO: Need to move this all out into method
			_discordHttpClient.BaseAddress = new Uri("https://discordapp.com/api/v6/");
			_discordHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", botToken);
		}

		public void PostMessage(DiscordMessage message)
		{
			string serializeObject = JsonConvert.SerializeObject(message);
			StringContent content = new StringContent(serializeObject, Encoding.UTF8, "application/json");
			var result = _discordHttpClient.PostAsync("channels/542319190825238528/messages", content).Result;
			var resolved = result.Content.ReadAsStringAsync().Result;
		}
	}
}
