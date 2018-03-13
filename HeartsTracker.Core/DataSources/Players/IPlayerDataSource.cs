using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Core.QueryParameters.Players;

namespace HeartsTracker.Core.DataSources.Players
{
	public interface IPlayerDataSource
	{
		Task GetPlayers( IGetPlayersCallback callback, PlayersQueryParameters queryParams );
		Task GetPlayer( IGetPlayerCallback callback, PlayerQueryParameters queryParams );
	}
}
