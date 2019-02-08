using System;
using System.Collections.Generic;
using Nero.Discord.Data;
using Nero.DiscordAPI;
using Nero.DiscordAPI.Data;

namespace Nero
{
	class Program
	{
		static void Main(string[] args)
		{
			DiscordAPI.DiscordClient discord = new DiscordAPI.DiscordClient();
			discord.Connect();
			DiscordClient.User botUser = discord.GetBotUser();
			List<DiscordGuildData> guildData = botUser.GetCurrentUserGuilds().Result;


			//discord.PostMessage(new DiscordMessage { content = "Testing Bot" });
		}
	}
}