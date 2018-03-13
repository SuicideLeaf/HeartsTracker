using HeartsTracker.Api.Models;

namespace HeartsTracker.Api.Services.Interfaces
{
	public interface IPlayerService
	{
		PlayerDetails GetDetails( int playerId );
		PlayerList GetList( );
		PlayerList GetList( bool? isActive );
		void Create( PlayerDetails playerDetails );
		void UpdateDetails( PlayerDetails playerDetails );
		void Archive( int playerId );
		void UnArchive( int playerId );
	}
}