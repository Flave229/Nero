using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nero.DiscordAPI;

namespace Nero
{
	class Program
	{
		static void Main(string[] args)
		{
			// Start a forever task that scans through all the channels
			CancellationToken cancelToken = new CancellationToken();
			Task discordLoop = DiscordLoop(cancelToken);
			discordLoop.Wait(cancelToken);
			//discord.PostMessage(new DiscordMessage { content = "Testing Bot" });
		}

		public static Task DiscordLoop(CancellationToken cancellationToken)
		{
			Task discordLoop = new Task(() =>
			{
				DiscordClient discord = new DiscordClient();
				discord.Connect();
				DiscordClient.User botUser = discord.GetBotUser();

				// TODO: We have no webhook yet. We will need to scan the API for any additional guilds the bot has been added to
				List<DiscordClient.Guild> guildData = botUser.GetCurrentUserGuilds().Result;

				// TODO: Without a webhook, we have to scan through everything. Of course, there are optimisations to be made here... but a webhook is the future.
				while (true)
				{
					foreach (DiscordClient.Guild discordGuildData in guildData)
					{
						// Need to get all the channels for the guild
						List<DiscordClient.Channel> channels = discordGuildData.GetChannels().Result;

						foreach (DiscordClient.Channel channel in channels)
						{
							List<DiscordClient.Message> messages = channel.GetNewMessages().Result;

							foreach (DiscordClient.Message message in messages)
							{
								if (message.Content.Length >= 2 
									&& message.Content.Substring(0, 2) == "//")
								{
									channel.SendMessage(new DiscordClient.Message
									{
										Content = "I hear you!"
									});
								}
							}
						}
					}
				}
			});
			discordLoop.Start();
			return discordLoop;
		}
	}
}