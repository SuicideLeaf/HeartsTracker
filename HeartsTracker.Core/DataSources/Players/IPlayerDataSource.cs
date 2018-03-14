using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.Models.Players.Requests;
using HeartsTracker.Core.QueryParams;
using HeartsTracker.Core.QueryParams.Players;

namespace HeartsTracker.Core.DataSources.Players
{
	public interface IPlayerDataSource
	{
		Task GetPlayers( IGetPlayersCallback callback, PlayersQueryParameters queryParams );
		Task GetPlayer( IGetPlayerCallback callback, PlayerQueryParameters queryParams );
		Task AddPlayer( AddPlayerRequest player, IAddPlayerCallback callback, QueryParameters queryParams );
	}
}
