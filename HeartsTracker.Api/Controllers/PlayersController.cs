using HeartsTracker.Api.Models;
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
		public PlayerList GetAll( )
		{
			return new PlayerList( _playerRepository );
		}

		// GET api/players/GetById?id=1
		// GET api/players/1
		[HttpGet( "GetById" )]
		public PlayerDetails GetById( int id )
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
