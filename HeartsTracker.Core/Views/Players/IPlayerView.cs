using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.QueryParameters.Players;

namespace HeartsTracker.Core.Views.Players
{
	public interface IPlayerView : IApiView<PlayerQueryParameters>
	{
		bool IsActive { get; }
		void ToggleRefreshing( bool active );
		void ToggleLoadingOverlay( bool active );
		void ToggleRetryOverlay( bool active, string message = "" );
		void ShowLoadingOverlay( );
		void ShowPlayer( Player player );
	}
}
