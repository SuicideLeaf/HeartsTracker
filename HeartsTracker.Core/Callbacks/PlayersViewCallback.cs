using System.Linq;
using HeartsTracker.Core.Callbacks.Interfaces;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models.Player;
using HeartsTracker.Core.Views;

namespace HeartsTracker.Core.Callbacks
{
	public class PlayersViewCallback : IGetPlayersCallback
	{
		private readonly IPlayersView _playersView;

		public PlayersViewCallback( IPlayersView playersView )
		{
			_playersView = playersView;
		}

		public void OnPlayersLoaded( PlayerListViewModel playerList )
		{
			// The view may not be able to handle UI updates anymore
			if ( !_playersView.IsActive )
			{
				return;
			}

			ProcessPlayers( playerList );
		}

		public void OnDataNotAvailable( Enums.DataError dataError )
		{
			// The view may not be able to handle UI updates anymore
			if ( !_playersView.IsActive )
			{
				return;
			}

			_playersView.ShowLoadingError( dataError );
		}

		private void ProcessPlayers( PlayerListViewModel playerList )
		{
			// Show the list of tasks
			_playersView.ShowPlayers( playerList );
		}
	}
}
