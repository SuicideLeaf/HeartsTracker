using HeartsTracker.Core.Models.Players;
using HeartsTracker.Core.QueryParams.Players;

namespace HeartsTracker.Core.Views.Players
{
	public interface IPlayersView : IApiView<PlayersQueryParameters>
	{
		void ToggleRefreshing( bool active );
		void ToggleLoadingOverlay( bool active );
		void ToggleRetryOverlay( bool active, string message = "" );
		void ShowLoadingOverlay( );
		void ShowPlayers( PlayerList playerList );
		void LoadPlayerDetailsScreen( int playerId );
	}
}
