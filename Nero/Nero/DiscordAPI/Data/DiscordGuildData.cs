using Newtonsoft.Json;

namespace Nero.DiscordAPI.Data
{
	public class DiscordGuildData
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}