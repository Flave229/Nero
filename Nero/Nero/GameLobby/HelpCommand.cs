using Nero.Commands;
using Nero.DiscordAPI;

namespace Nero.GameLobby
{
	public class HelpCommand : ICommand
	{
		private readonly DiscordClient.Channel _channel;

		public HelpCommand(DiscordClient.Channel channel)
		{
			_channel = channel;
		}

		public void Invoke()
		{
			_channel.SendMessage(new DiscordClient.Message
			{
				Content = "Help command has been reached."
			});
		}
	}
}