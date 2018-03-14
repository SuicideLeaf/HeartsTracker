using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Core.Callbacks.Players
{
	public interface IAddPlayerCallback : IBaseCallback
	{
		void OnPlayerAdded( PlayerListItem playerListItem );
	}
}
