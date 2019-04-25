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

		public void OnPlayerLoaded( PlayerViewModel player )
		{
			ProcessPlayer( player );
		}

		public void OnDataError( Enums.DataError dataError, string content )
		{
			_playerView.ShowDataError( dataError );
		}

		private void ProcessPlayer( PlayerViewModel player )
		{
			// Show the player details
			_playerView.ShowPlayer( player );
		}
	}
}
