using HeartsTracker.Core.Models.Players;

namespace HeartsTracker.Core.Views.Players
{
	public interface IPlayersView : IBaseView
	{
		void ShowPlayers( PlayerListViewModel playerList );
		void LoadPlayerDetailsScreen( int playerId );
	}
}
