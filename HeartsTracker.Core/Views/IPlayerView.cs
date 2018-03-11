using HeartsTracker.Core.Models.Player;
using HeartsTracker.Core.QueryParameters;

namespace HeartsTracker.Core.Views
{
	public interface IPlayerView : IApiView<PlayerQueryParameters>
	{
		bool IsActive { get; }
		void ToggleRefreshing( bool active );
		void ToggleLoadingOverlay( bool active );
		void ToggleRetryOverlay( bool active, string message = "" );
		void ShowLoadingOverlay( );
		void ShowPlayer( PlayerViewModel player );
	}
}
