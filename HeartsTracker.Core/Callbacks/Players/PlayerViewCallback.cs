using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.Views.Players;

namespace HeartsTracker.Core.Callbacks.Players
{
	public class PlayerViewCallback : IGetPlayerCallback
	{
		private readonly IPlayerView _playerView;

		public PlayerViewCallback( IPlayerView playerView )
		{
			_playerView = playerView;
		}

		public void OnPlayerLoaded( Player player )
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

		private void ProcessPlayer( Player player )
		{
			// Show the player details
			_playerView.ShowPlayer( player );
		}
	}
}
