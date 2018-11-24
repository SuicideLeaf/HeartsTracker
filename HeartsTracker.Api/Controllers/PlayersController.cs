using AutoMapper;
using HeartsTracker.Api.Classes;
using HeartsTracker.Api.DomainModels.Players;
using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Shared.Models.Player;
using HeartsTracker.Shared.Models.Player.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HeartsTracker.Api.Controllers
{
	[Produces( "application/json" )]
	public class PlayersController : BaseController
	{
		private readonly IPlayerService _playerService;

		public PlayersController( IMapper mapper, IPlayerService playerService ) : base( mapper )
		{
			_playerService = playerService;
		}

		[HttpGet( "" )]
		[ProducesResponseType( 200 )]
		public ActionResult<PlayerListResponse> All( )
		{
			var players = _playerService.GetList( Enums.ActiveStatus.Both );

			return new PlayerListResponse( Mapper.Map<List<PlayerListItemResponse>>( players ) );
		}

		[HttpPut( "archive/{id}" )]
		public IActionResult Archive( int id )
		{
			_playerService.Archive( id );

			return Ok( );
		}

		[HttpPost( "create" )]
		[ProducesResponseType( 201 )]
		public IActionResult Create( [FromBody]CreatePlayerRequest request )
		{
			var playerId = _playerService.Create( Mapper.Map<Player>( request ) );

			return Created( new Uri( $"api/players/{playerId}" ), playerId );
		}

		[HttpGet( "{id}" )]
		[ProducesResponseType( 200 )]
		public ActionResult<PlayerResponse> Get( int id )
		{
			var player = _playerService.GetDetails( id );

			return Mapper.Map<PlayerResponse>( player );
		}

		[HttpPut( "unarchive/{id}" )]
		[ProducesResponseType( 200 )]
		public IActionResult UnArchive( int id )
		{
			_playerService.UnArchive( id );

			return Ok( );
		}

		[HttpPut( "update/{id}" )]
		[ProducesResponseType( 200 )]
		public IActionResult Update( int id, [FromBody]UpdatePlayerRequest request )
		{
			_playerService.Update( Mapper.Map<Player>( request ) );

			return Ok( );
		}
	}
}