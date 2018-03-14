using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.QueryParams.Players;

namespace HeartsTracker.Core.Views.Players
{
	public interface IPlayerView : IApiView<PlayerQueryParameters>
	{
		void ToggleRefreshing( bool active );
		void ToggleLoadingOverlay( bool active );
		void ToggleRetryOverlay( bool active, string message = "" );
		void ShowLoadingOverlay( );
		void ShowPlayer( Player player );
	}
}
