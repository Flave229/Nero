using Newtonsoft.Json;

namespace Nero.DiscordAPI
{
	public partial class DiscordClient
	{
		public class Message
		{
			[JsonProperty("id")]
			public string Id { get; private set; }

			[JsonProperty("content")]
			public string Content { get; set; }

			public Channel Channel { get; set; }
		}
	}
}