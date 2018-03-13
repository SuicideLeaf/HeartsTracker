using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.QueryParameters.Players;

namespace HeartsTracker.Core.Views.Players
{
	public interface IPlayersView : IApiView<PlayersQueryParameters>
	{
		bool IsActive { get; }
		void ToggleRefreshing( bool active );
		void ToggleLoadingOverlay( bool active );
		void ToggleRetryOverlay( bool active, string message = "" );
		void ShowLoadingOverlay( );
		void ShowPlayers( PlayerList playerList );
		void LoadPlayerDetailsScreen( int playerId );
	}
}
