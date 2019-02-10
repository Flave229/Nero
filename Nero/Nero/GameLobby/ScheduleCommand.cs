using Nero.Commands;
using Nero.DiscordAPI;

namespace Nero.GameLobby
{
	class ScheduleCommand : ICommand
	{
		private readonly DiscordClient.Channel _channel;

		public ScheduleCommand(DiscordClient.Channel channel)
		{
			_channel = channel;
		}

		public void Invoke()
		{
			_channel.SendMessage(new DiscordClient.Message
			{
				Content = "Schedule command has been reached."
			});
		}
	}
}