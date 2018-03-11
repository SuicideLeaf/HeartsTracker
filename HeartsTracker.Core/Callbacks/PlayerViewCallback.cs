using HeartsTracker.Core.Callbacks.Interfaces;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models.Player;
using HeartsTracker.Core.Views;

namespace HeartsTracker.Core.Callbacks
{
	public class PlayerViewCallback : IGetPlayerCallback
	{
		private readonly IPlayerView _playerView;

		public PlayerViewCallback( IPlayerView playerView )
		{
			_playerView = playerView;
		}

		public void OnPlayerLoaded( PlayerViewModel player )
		{
			// The view may not be able to handle UI updates anymore
			if ( !_playerView.IsActive )
			{
				return;
			}

			ProcessPlayer( player );
		}

		public void OnDataNotAvailable( Enums.DataError dataError )
		{
			// The view may not be able to handle UI updates anymore
			if ( !_playerView.IsActive )
			{
				return;
			}

			_playerView.ShowLoadingError( dataError );
		}

		private void ProcessPlayer( PlayerViewModel player )
		{
			// Show the player details
			_playerView.ShowPlayer( player );
		}
	}
}
