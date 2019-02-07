using System;
using Nero.Discord;
using Nero.Discord.Data;

namespace Nero
{
	class Program
	{
		static void Main(string[] args)
		{
			DiscordService discord = new DiscordService();
			discord.Connect();
			discord.PostMessage(new DiscordMessage { content = "Testing Bot" });
		}
	}
}