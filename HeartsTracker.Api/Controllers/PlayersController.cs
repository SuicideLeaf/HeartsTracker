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
		public ActionResult<PlayerListResponse> All( bool? isActive )
		{
			var players = _playerService.GetList( isActive.ToActiveStatus( ) );

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
			if ( !Validate( ModelState, request ) )
			{
				return BadRequest( ModelState );
			}

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
			if ( !Validate( ModelState, request ) )
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

		private bool Validate( ModelStateDictionary modelState, CreatePlayerRequest request )
		{
			if ( !_playerService.IsPlayernameUnique( request.PlayerName ) )
			{
				modelState.AddModelError( nameof( request.PlayerName ), "This player name is already taken. Please choose a different name." );
			}

			return modelState.IsValid;
		}

		private bool Validate( ModelStateDictionary modelState, UpdatePlayerRequest request )
		{
			if ( !_playerService.IsPlayernameUnique( request.PlayerName ) )
			{
				modelState.AddModelError( nameof( request.PlayerName ), "This player name is already taken. Please choose a different name." );
			}

			return modelState.IsValid;
		}

		#endregion Validation
	}
}