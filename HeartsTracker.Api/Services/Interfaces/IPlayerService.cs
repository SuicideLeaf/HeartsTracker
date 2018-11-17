using HeartsTracker.Shared.Models.Player.Requests;

namespace HeartsTracker.Api.Services.Interfaces
{
	public interface IPlayerService
	{
		PlayerResponse GetDetails( int playerId );
		PlayerListResponse GetList( );
		PlayerListResponse GetList( bool? isActive );
		PlayerListItemResponse Create( AddPlayerRequest playerRequest );
		void Update( UpdatePlayerRequest playerDetails );
		void Archive( int playerId );
		void UnArchive( int playerId );
	}
}