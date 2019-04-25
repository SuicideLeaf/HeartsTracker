using AutoMapper;
using HeartsTracker.Api.Attributes;
using HeartsTracker.Api.DomainModels.Players;
using HeartsTracker.Api.Extensions;
using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Shared.Models.Player;
using HeartsTracker.Shared.Models.Player.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace HeartsTracker.Api.Controllers
{
	[ValidateModelState]
	[Produces( "application/json" )]
	public class PlayersController : BaseController
	{
		private readonly IPlayerService _playerService;

		public PlayersController( IMapper mapper, IPlayerService playerService ) : base( mapper )
		{
			_playerService = playerService;
		}

		#region Actions

		[HttpGet( "" )]
		[ProducesResponseType( 200 )]
		public IActionResult All( bool? isActive )
		{
			var players = _playerService.GetList( isActive.ToActiveStatus( ) );

			var response = new PlayerListResponse( Mapper.Map<List<PlayerListItemResponse>>( players ) );

			return Ok( response );
		}

		[HttpPut( "archive/{id}" )]
		public IActionResult Archive( int id )
		{
			_playerService.Archive( id );

			return Ok( );
		}

		[HttpPost( "create" )]
		[ProducesResponseType( 200 )]
		public IActionResult Create( [FromBody]CreatePlayerRequest request )
		{
			if ( !IsPlayerNameValid( ModelState, nameof( request.PlayerName ), request.PlayerName ) )
			{
				return BadRequest( ModelState );
			}

			var playerId = _playerService.Create( Mapper.Map<Player>( request ) );

			return Ok( playerId );
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
			if ( !IsPlayerNameValid( ModelState, nameof( request.PlayerName ), request.PlayerName ) )
			{
				return BadRequest( ModelState );
			}

			var playerToUpdate = Mapper.Map<Player>( request );
			playerToUpdate.Id = id;

			_playerService.Update( playerToUpdate );

			return Ok( );
		}

		#endregion Actions

		#region Validation

		private bool IsPlayerNameValid( ModelStateDictionary modelState, string keyName, string playerName )
		{
			if ( !_playerService.IsPlayerNameUnique( playerName ) )
			{
				modelState.AddModelError( keyName, "This player name is already taken. Please choose a different name." );
			}

			return modelState.IsValid;
		}

		#endregion Validation
	}
}