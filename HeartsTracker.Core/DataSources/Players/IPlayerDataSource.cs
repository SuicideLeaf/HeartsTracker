using System.Threading.Tasks;
using HeartsTracker.Core.Callbacks.Players;
using HeartsTracker.Shared.Models.Player.Requests;

namespace HeartsTracker.Core.DataSources.Players
{
	public interface IPlayerDataSource
	{
		Task GetPlayers( IGetPlayersCallback callback );
		Task GetPlayer( IGetPlayerCallback callback, int playerId );
		Task AddPlayer( AddPlayerRequest player, IAddPlayerCallback callback );
	}
}