using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.Views.Players;

namespace HeartsTracker.Core.Callbacks.Players
{
	public class PlayersViewCallback : IGetPlayersCallback
	{
		private readonly IPlayersView _playersView;

		public PlayersViewCallback( IPlayersView playersView )
		{
			_playersView = playersView;
		}

		public void OnPlayersLoaded( PlayerList playerList )
		{
			ProcessPlayers( playerList );
		}

		public void OnDataError( Enums.DataError dataError )
		{
			_playersView.ShowDataError( dataError );
		}

		private void ProcessPlayers( PlayerList playerList )
		{
			// Show the list of tasks
			_playersView.ShowPlayers( playerList );
		}
	}
}
