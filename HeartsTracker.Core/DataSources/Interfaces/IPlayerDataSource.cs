using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Interfaces;
using HeartsTracker.Core.QueryParameters;

namespace HeartsTracker.Core.DataSources.Interfaces
{
	public interface IPlayerDataSource
	{
		Task GetPlayers( IGetPlayersCallback callback, PlayersQueryParameters queryParams );
		Task GetPlayer( IGetPlayerCallback callback, PlayerQueryParameters queryParams );
	}
}
