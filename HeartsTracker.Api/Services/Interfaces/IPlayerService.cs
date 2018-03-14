using HeartsTracker.Api.Models;
using HeartsTracker.Api.Models.Players;
using HeartsTracker.Api.Models.Players.Requests;

namespace HeartsTracker.Api.Services.Interfaces
{
	public interface IPlayerService
	{
		PlayerDetails GetDetails( int playerId );
		PlayerList GetList( );
		PlayerList GetList( bool? isActive );
		PlayerListItem Create( AddPlayerRequest playerRequest );
		void UpdateDetails( PlayerDetails playerDetails );
		void Archive( int playerId );
		void UnArchive( int playerId );
	}
}