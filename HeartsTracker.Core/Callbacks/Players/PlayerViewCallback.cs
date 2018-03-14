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
			ProcessPlayer( player );
		}

		public void OnDataError( Enums.DataError dataError )
		{
			_playerView.ShowDataError( dataError );
		}

		private void ProcessPlayer( Player player )
		{
			// Show the player details
			_playerView.ShowPlayer( player );
		}
	}
}
