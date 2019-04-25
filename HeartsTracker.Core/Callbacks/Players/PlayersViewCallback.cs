using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.Views.Players;

namespace HeartsTracker.Core.Callbacks.Players
{
	public class PlayersViewCallback : BaseCallback<IPlayersView>, IGetPlayersCallback
	{
		public PlayersViewCallback( IPlayersView playersView ) : base( playersView )
		{
		}

		public void OnPlayersLoaded( PlayerListViewModel playerList )
		{
			View.ShowPlayers( playerList );
		}
	}
}
