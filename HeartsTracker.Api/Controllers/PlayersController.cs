using HeartsTracker.Api.Models;
using HeartsTracker.Dal.Entities;
using HeartsTracker.Dal.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HeartsTracker.Api.Controllers
{
	public class PlayersController : BaseController
	{
		private readonly IPlayerRepository _playerRepository;

		public PlayersController( IPlayerRepository playerRepository )
		{
			_playerRepository = playerRepository;
		}

		// GET api/players
		[HttpGet]
		public PlayerList Get( )
		{
			return new PlayerList( _playerRepository );
		}

		// GET api/players/5
		[HttpGet( "{id}" )]
		public PlayerDetails Get( int id )
		{
			return PlayerDetails.Get( _playerRepository, id );
		}

		// POST api/players
		[HttpPost]
		public void Post( [FromBody]string value )
		{
		}

		// PUT api/players/5
		[HttpPut( "{id}" )]
		public void Put( int id, [FromBody]string value )
		{
		}

		// DELETE api/players/5
		[HttpDelete( "{id}" )]
		public void Delete( int id )
		{
		}
	}
}
