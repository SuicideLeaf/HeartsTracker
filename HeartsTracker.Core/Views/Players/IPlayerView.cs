using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Core.Views.Players
{
	public interface IPlayerView : IBaseView
	{
		int PlayerId { get; set; }
		void ToggleRefreshing( bool active );
		void ToggleLoadingOverlay( bool active );
		void ToggleRetryOverlay( bool active, string message = "" );
		void ShowLoadingOverlay( );
		void ShowPlayer( PlayerViewModel player );
	}
}
