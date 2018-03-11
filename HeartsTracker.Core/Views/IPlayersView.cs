using HeartsTracker.Core.Models.Player;
using HeartsTracker.Core.QueryParameters;

namespace HeartsTracker.Core.Views
{
	public interface IPlayersView : IApiView<PlayersQueryParameters>
	{
		bool IsActive { get; }
		void ToggleRefreshing( bool active );
		void ToggleLoadingOverlay( bool active );
		void ToggleRetryOverlay( bool active, string message = "" );
		void ShowLoadingOverlay( );
		void ShowPlayers( PlayerListViewModel playerList );
		void LoadPlayerDetailsScreen( int playerId );
	}
}
