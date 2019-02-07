using System;
using System.Collections.Generic;
using System.Text;

namespace Nero.Discord.Data
{
	public class DiscordMessage
	{
		public string content { get; set; }
		public bool tts { get; set; }
		public DiscordMessageEmbed embed { get; set; }
	}

	public class DiscordMessageEmbed
	{
		public DiscordMessageAuthor Author { get; set; }
		public string Title { get; set; }
		public List<DiscordMessageField> Fields { get; set; }
	}

	public class DiscordMessageField
	{
		public string Name { get; set; }
		public string Value { get; set; }
	}

	public class DiscordMessageAuthor
	{
		public string Name { get; set; }
	}
}
