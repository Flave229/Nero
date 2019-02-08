using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Nero.DiscordAPI
{
	public partial class DiscordClient
	{
		public class Guild
		{
			[JsonProperty("id")]
			public string Id { get; private set; }

			[JsonProperty("name")]
			public string Name { get; private set; }

			[JsonProperty("channels")]
			public List<Channel> Channels { get; private set; }

			public Guild()
			{
				Channels = new List<Channel>();
			}

			public Guild(string id)
			{
				Id = id;
			}

			public Task<List<Channel>> GetChannels()
			{
				// TODO: Handle additional channels being added after bots first pass through
				if (Channels.Count > 0)
				{
					return Task.Run(() => Channels);
				}

				Task<HttpResponseMessage> httpResponseTask = DiscordHttpClient.GetAsync($"guilds/{Id}/channels");

				Task<List<Channel>> channelDataTask = new Task<List<Channel>>(() =>
				{
					HttpResponseMessage httpResponse = httpResponseTask.Result;
					if (httpResponse.IsSuccessStatusCode == false)
					{
						return new List<Channel>();
					}

					string response = httpResponse.Content.ReadAsStringAsync().Result;
					List<Channel> channels = JsonConvert.DeserializeObject<List<Channel>>(response);
					Channels = channels;
					return channels;
				});
				channelDataTask.Start();
				return channelDataTask;
			}
		}
	}
}