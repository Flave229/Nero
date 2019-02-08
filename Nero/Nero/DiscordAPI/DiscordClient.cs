using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Nero.DiscordAPI
{
	public partial class DiscordClient
	{
		private static readonly HttpClient DiscordHttpClient = new HttpClient();

		public void Connect()
		{
			var filePath = "Data/DiscordBotToken.config";
			if (!System.IO.File.Exists(filePath))
				Console.WriteLine("Failed to fetch the bot token to log in to Discord");

			var fileContents = System.IO.File.ReadAllLines(filePath);
			var botToken = string.Join(",", fileContents);

			DiscordHttpClient.BaseAddress = new Uri("https://discordapp.com/api/v6/");
			DiscordHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", botToken);
		}

		//public void PostMessage(DiscordMessage message)
		//{
		//	string serializeObject = JsonConvert.SerializeObject(message);
		//	StringContent content = new StringContent(serializeObject, Encoding.UTF8, "application/json");
		//	var result = DiscordHttpClient.PostAsync("channels/542319190825238528/messages", content).Result;
		//	var resolved = result.Content.ReadAsStringAsync().Result;
		//}

		public User GetBotUser()
		{
			// TODO: If other users should appear out of this, the user id needs to be provided in the constructor
			return new User();
		}
	}
}
