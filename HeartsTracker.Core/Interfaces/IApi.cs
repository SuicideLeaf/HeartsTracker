using System.Threading.Tasks;
using HeartsTracker.Core.Models.Player;
using HeartsTracker.Core.QueryParameters;
using Refit;

namespace HeartsTracker.Core.Interfaces
{
	//[Headers( "Authorization: Bearer" )]
	public interface IApi
	{
		[Get( "/api/players" )]
		Task<PlayerList> GetPlayers( PlayersQueryParameters queryParams );

		[Get( "/api/players/getbyid" )]
		Task<Player> GetPlayer( PlayerQueryParameters queryParams );
	}
}
