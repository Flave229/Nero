using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Nero.DiscordAPI
{
	public partial class DiscordClient
	{
		public class User
		{
			public Task<List<Guild>> GetCurrentUserGuilds()
			{
				Task<HttpResponseMessage> httpResponseTask = DiscordHttpClient.GetAsync("users/@me/guilds");

				Task<List<Guild>> guildDataTask = new Task<List<Guild>>(() =>
				{
					HttpResponseMessage httpResponse = httpResponseTask.Result;
					if (httpResponse.IsSuccessStatusCode == false)
					{
						return new List<Guild>();
					}

					string response = httpResponse.Content.ReadAsStringAsync().Result;
					return JsonConvert.DeserializeObject<List<Guild>>(response);
				});
				guildDataTask.Start();
				return guildDataTask;
			}
		}
	}
}