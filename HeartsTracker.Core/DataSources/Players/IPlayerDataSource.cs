using System.Threading.Tasks;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models;
using HeartsTracker.Shared.Models.Player;
using HeartsTracker.Shared.Models.Player.Requests;

namespace HeartsTracker.Core.DataSources.Players
{
	public interface IPlayerDataSource
	{
		Task<Either<PlayerListResponse, ErrorResponse>> GetPlayers( );
		Task GetPlayer( int playerId );
		Task AddPlayer( CreatePlayerRequest player );
	}
}