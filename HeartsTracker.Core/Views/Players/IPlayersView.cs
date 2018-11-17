using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Core.Views.Players
{
	public interface IPlayersView : IBaseView
	{
		void ToggleRefreshing( bool active );
		void ToggleLoadingOverlay( bool active );
		void ToggleRetryOverlay( bool active, string message = "" );
		void ShowLoadingOverlay( );
		void ShowPlayers( PlayerListViewModel playerList );
		void LoadPlayerDetailsScreen( int playerId );
	}
}
