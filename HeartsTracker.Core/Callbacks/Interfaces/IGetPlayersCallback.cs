using HeartsTracker.Core.Models.Player;

namespace HeartsTracker.Core.Callbacks.Interfaces
{
    public interface IGetPlayersCallback : IBaseCallback
	{
		void OnPlayersLoaded( PlayerListViewModel playerList );
	}
}
