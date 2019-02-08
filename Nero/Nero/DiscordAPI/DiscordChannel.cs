using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Nero.DiscordAPI
{
	public partial class DiscordClient
	{
		public class Channel
		{
			[JsonProperty("id")]
			public string Id { get; private set; }

			[JsonProperty("name")]
			public string Name { get; private set; }

			private string _lastRecievedMessageId = "0";

			public Task<List<Message>> GetNewMessages()
			{
				// Do not want the after query before we have populated lastRecieved as it will start fetching messages from the beginning of time
				string query = _lastRecievedMessageId != "0" ? $"?after={_lastRecievedMessageId}" : "";
				Task<HttpResponseMessage> httpResponseTask = DiscordHttpClient.GetAsync($"channels/{Id}/messages{query}");

				Task<List<Message>> messagesDataTask = new Task<List<Message>>(() =>
				{
					HttpResponseMessage httpResponse = httpResponseTask.Result;
					if (httpResponse.IsSuccessStatusCode == false)
					{
						return new List<Message>();
					}

					string response = httpResponse.Content.ReadAsStringAsync().Result;
					List<Message> messages = JsonConvert.DeserializeObject<List<Message>>(response);

					//Response always ordered with recent at top. So can take ID from first item
					if (messages.Count > 0)
					{
						_lastRecievedMessageId = messages[0].Id;
					}
					return messages;
				});
				messagesDataTask.Start();
				return messagesDataTask;
			}

			public void SendMessage(Message message)
			{
				string serializeObject = JsonConvert.SerializeObject(message);
				StringContent content = new StringContent(serializeObject, Encoding.UTF8, "application/json");
				var result = DiscordHttpClient.PostAsync("channels/542319190825238528/messages", content).Result;
				var resolved = result.Content.ReadAsStringAsync().Result;
			}
		}
	}
}