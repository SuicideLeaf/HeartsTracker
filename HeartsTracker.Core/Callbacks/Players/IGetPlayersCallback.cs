using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Core.Callbacks.Players
{
    public interface IGetPlayersCallback : IBaseCallback
	{
		void OnPlayersLoaded( PlayerList playerList );
	}
}
