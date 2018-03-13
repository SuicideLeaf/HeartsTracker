using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeartsTracker.Api.Controllers
{
	public class PlayersController : BaseController
	{
		private readonly IPlayerService _playerService;

		public PlayersController( IPlayerService playerService )
		{
			_playerService = playerService;
		}

		// GET api/players/all?isActive=false
		[HttpGet( "All" )]
		public PlayerList GetAll( bool? isActive = null )
		{
			return _playerService.GetList( isActive );
		}

		// GET api/players/get?id=5
		[HttpGet( "Get" )]
		public PlayerDetails Get( int id )
		{
			return _playerService.GetDetails( id );
		}

		// POST api/players/create
		[HttpPost( "Create" )]
		public void Post( [FromBody]PlayerDetails playerDetails )
		{
			_playerService.Create( playerDetails );
		}

		// PUT api/players/update?id=5
		[HttpPut( "Update" )]
		public void Update( int id, [FromBody]PlayerDetails playerDetails )
		{
			_playerService.UpdateDetails( playerDetails );
		}

		// PUT api/players/archive?id=5
		[HttpPut( "Archive" )]
		public void Archive( int id )
		{
			_playerService.Archive( id );
		}

		// PUT api/players/unarchive?id=5
		[HttpPut( "UnArchive" )]
		public void UnArchive( int id )
		{
			_playerService.UnArchive( id );
		}
	}
}
