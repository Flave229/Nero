using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Nero.DiscordAPI.Data;
using Newtonsoft.Json;

namespace Nero.DiscordAPI
{
	public partial class DiscordClient
	{
		public class User
		{
			public Task<List<DiscordGuildData>> GetCurrentUserGuilds()
			{
				Task<HttpResponseMessage> httpResponseTask = DiscordHttpClient.GetAsync("users/@me/guilds");

				Task<List<DiscordGuildData>> guildDataTask = new Task<List<DiscordGuildData>>(() =>
				{
					HttpResponseMessage httpResponse = httpResponseTask.Result;
					string response = httpResponse.Content.ReadAsStringAsync().Result;
					return JsonConvert.DeserializeObject<List<DiscordGuildData>>(response);
				});
				guildDataTask.Start();
				return guildDataTask;
			}
		}
	}
}
