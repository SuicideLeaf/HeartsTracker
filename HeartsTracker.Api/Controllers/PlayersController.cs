using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Shared.Models.Player.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HeartsTracker.Api.Controllers
{
	[Produces( "application/json" )]
	public class PlayersController : BaseController
	{
		private readonly IPlayerService _playerService;

		public PlayersController( IPlayerService playerService )
		{
			_playerService = playerService;
		}

		// GET api/players?isActive=false
		[HttpGet( "" )]
		public PlayerListResponse All( bool? isActive = null )
		{
			return _playerService.GetList( isActive );
		}

		// PUT api/players/archive/1
		[HttpPut( "archive/{id}" )]
		public void Archive( int id )
		{
			_playerService.Archive( id );
		}

		// POST api/players/create
		[HttpPost( "create" )]
		public PlayerListItemResponse Create( [FromBody]AddPlayerRequest request )
		{
			return _playerService.Create( request );
		}

		// GET api/players/1
		[HttpGet( "{id}" )]
		public PlayerResponse Get( int id )
		{
			return _playerService.GetDetails( id );
		}

		// PUT api/players/unarchive/1
		[HttpPut( "unarchive/{id}" )]
		public void UnArchive( int id )
		{
			_playerService.UnArchive( id );
		}

		// PUT api/players/update/1
		[HttpPut( "update/{id}" )]
		public void Update( int id, [FromBody]UpdatePlayerRequest request )
		{
			_playerService.Update( request );
		}
	}
}