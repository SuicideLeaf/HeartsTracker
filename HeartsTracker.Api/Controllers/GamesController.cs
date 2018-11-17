using HeartsTracker.Api.Models.Games;
using HeartsTracker.Api.Models.Games.Requests;
using HeartsTracker.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HeartsTracker.Api.Controllers
{
	[Produces( "application/json" )]
	public class GamesController : BaseController
	{
		private readonly IGameService _gameService;

		public GamesController( IGameService gameService )
		{
			_gameService = gameService;
		}

		//// GET api/games/all?isActive=false
		//[HttpGet( "All" )]
		//public GameList All( bool? isActive = null )
		//{
		//	return _gameService.GetList( isActive );
		//}

		//// GET api/games/get?id=5
		//[HttpGet( "Get" )]
		//public GameDetails Get( int id )
		//{
		//	return _gameService.GetDetails( id );
		//}

		//// POST api/games/create
		//[HttpPost( "Create" )]
		//public int Create( [FromBody]CreateGameRequest gameRequest )
		//{
		//	return _gameService.Create( gameRequest );
		//}

		//// PUT api/games/update?id=5
		//[HttpPut( "Update" )]
		//public void Update( int id, [FromBody]GameDetails gameDetails )
		//{
		//	_gameService.UpdateDetails( gameDetails );
		//}

		//// PUT api/games/archive?id=5
		//[HttpPut( "Archive" )]
		//public void Archive( int id )
		//{
		//	_gameService.Archive( id );
		//}

		//// PUT api/games/unarchive?id=5
		//[HttpPut( "UnArchive" )]
		//public void UnArchive( int id )
		//{
		//	_gameService.UnArchive( id );
		//}
	}
}