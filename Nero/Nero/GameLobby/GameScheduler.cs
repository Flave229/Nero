using Nero.Commands;
using Nero.DiscordAPI;

namespace Nero.GameLobby
{
	public class GameScheduler
	{
		private DiscordClient _discordClient;

		public GameScheduler(DiscordClient discordClient)
		{
			_discordClient = discordClient;
		}

		public bool DoesMessageContainCommandPrefix(string message)
		{
			return message.Length >= 2 && message.Substring(0, 2) == "//";
		}

		public ICommand HandleCommand(DiscordClient.Message message)
		{
			string sanitisedCommand = message.Content.Replace("//", "").Trim();
			string primaryCommand = sanitisedCommand.Split(' ')[0].ToLower();

			switch (primaryCommand)
			{
				case "help":
					return new HelpCommand(message.Channel);
				case "schedule":
					return new ScheduleCommand(message.Channel);
				default:
					return null;
			}
		}
	}
}