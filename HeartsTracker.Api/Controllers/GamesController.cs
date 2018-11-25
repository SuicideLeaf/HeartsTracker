using AutoMapper;
using HeartsTracker.Api.Classes;
using HeartsTracker.Api.DomainModels.Games;
using HeartsTracker.Api.DomainModels.PlayerScores;
using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Shared.Models.Game;
using HeartsTracker.Shared.Models.Game.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HeartsTracker.Api.Controllers
{
	[Produces( "application/json" )]
	public class GamesController : BaseController
	{
		private readonly IGameService _gameService;
		private readonly IPlayerScoreService _scoreService;

		public GamesController( IMapper mapper, IGameService gameService, IPlayerScoreService scoreService ) : base( mapper )
		{
			_gameService = gameService;
			_scoreService = scoreService;
		}

		[HttpPost( "addround/{id}" )]
		[ProducesResponseType( 201 )]
		public IActionResult AddRound( int id )
		{
			var roundId = _gameService.AddRound( id );

			return Created( new Uri( $"" ), roundId );
		}

		[HttpGet( "" )]
		[ProducesResponseType( 200 )]
		public ActionResult<GameListResponse> All( )
		{
			var games = _gameService.GetList( Enums.ActiveStatus.Both );

			return new GameListResponse( Mapper.Map<List<GameListItemResponse>>( games ) );
		}

		[HttpPut( "archive/{id}" )]
		[ProducesResponseType( 200 )]
		public IActionResult Archive( int id )
		{
			_gameService.Archive( id );

			return Ok( );
		}

		[HttpPut( "complete/{id}" )]
		[ProducesResponseType( 200 )]
		public IActionResult Complete( int id )
		{
			_gameService.Complete( id );

			return Ok( );
		}

		[HttpPut( "completeround/{id}" )]
		[ProducesResponseType( 200 )]
		public IActionResult CompleteRound( int id )
		{
			// Complete the current round before adding a new round.
			var currentRound = _gameService.GetCurrentRound( id );

			if ( currentRound == null )
			{
				return BadRequest( );
			}

			_gameService.CompleteRound( currentRound.Id );

			return Ok( );
		}

		[HttpPost( "create" )]
		[ProducesResponseType( 201 )]
		public IActionResult Create( [FromBody]CreateGameRequest request )
		{
			var game = Mapper.Map<Game>( request );

			int gameId = _gameService.Create( game, request.Players );

			return Created( new Uri( $"" ), gameId );
		}

		[HttpPut( "unarchive/{id}" )]
		[ProducesResponseType( 200 )]
		public ActionResult UnArchive( int id )
		{
			_gameService.UnArchive( id );

			return Ok( );
		}

		[HttpPut( "updateplayersscores/{id}" )]
		[ProducesResponseType( 200 )]
		[ProducesResponseType( 400 )]
		public IActionResult UpdatePlayersScores( int id, UpdatePlayersScoresRequest request )
		{
			var playersScores = Mapper.Map<List<PlayerScore>>( request.PlayerScores );

			if ( !request.RoundId.HasValue )
			{
				var currentRound = _gameService.GetCurrentRound( id );

				if ( currentRound == null )
				{
					return BadRequest( );
				}

				request.RoundId = currentRound.Id;
			}

			foreach ( var score in playersScores )
			{
				score.RoundId = request.RoundId.Value;
			}

			_scoreService.UpdateRange( playersScores );

			return Ok( );
		}
	}
}