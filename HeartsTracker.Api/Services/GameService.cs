using AutoMapper;
using AutoMapper.QueryableExtensions;
using HeartsTracker.Api.Classes;
using HeartsTracker.Api.DomainModels.Games;
using HeartsTracker.Api.DomainModels.PlayerScores;
using HeartsTracker.Api.DomainModels.Rounds;
using HeartsTracker.Api.Extensions;
using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Dal.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HeartsTracker.Api.Services
{
	public class GameService : BaseService, IGameService
	{
		private DbSet<Dal.Entities.GamePlayer> GamePlayers => Context.GamePlayers;
		private DbSet<Dal.Entities.Game> Games => Context.Games;
		private DbSet<Dal.Entities.GameRound> Rounds => Context.GameRounds;

		public GameService( IMapper mapper, HeartsTrackerContext context ) : base( mapper, context )
		{
		}

		public int AddRound( int gameId )
		{
			// Gather game data in order to create a round.
			var game = Games
				.Where( g => g.Id == gameId )
				.Select( g => new
				{
					g.Id,
					NumberOfRounds = g.GameRounds.Count,
					Players = g.GamePlayers.Select( p => new { Id = p.PlayerId, p.OrderNumber } )
				} )
				.First( );

			// Determine if next round is keep round
			var isKeepRound = IsNextRoundKeepRound( game.NumberOfRounds, game.Players.Count( ) );

			// Create default blank scores for the round all players
			List<Dal.Entities.PlayerScore> scores = new List<Dal.Entities.PlayerScore>( );
			foreach ( var player in game.Players )
			{
				scores.Add( new Dal.Entities.PlayerScore { PlayerId = player.Id } );
			}

			var roundNumber = game.NumberOfRounds + 1; // Include this round being added
			var dealerOrderNumber = GetDealerPlayerOrderNumber( roundNumber, game.Players.Count( ) );
			var dealerId = game.Players.First( p => p.OrderNumber == dealerOrderNumber ).Id;

			// Create the base round
			var round = new Dal.Entities.GameRound
			{
				GameId = game.Id,
				IsKeepRound = isKeepRound,
				Scores = scores,
				DealerId = dealerId,
				RoundNumber = roundNumber,
				IsComplete = false
			};

			Rounds.Add( round );

			SaveChanges( );

			return round.Id;
		}

		public void Archive( int gameId )
		{
			var game = Games.TryGet( gameId );

			if ( game != null )
			{
				game.IsActive = false;

				SaveChanges( );
			}
		}

		public void Complete( int gameId )
		{
			var game = Games.First( g => g.Id == gameId );

			// Calculate winner & loser
			var gamePlayerTotalScores = GetPlayersTotalScoresForGame( gameId ).OrderByDescending( p => p.TotalScore );
			var winnerId = gamePlayerTotalScores.First( ).PlayerId;
			var loserId = gamePlayerTotalScores.Last( ).PlayerId;

			game.IsComplete = true;
			game.WinnerId = winnerId;
			game.LoserId = loserId;

			SaveChanges( );
		}

		public int Create( Game game, List<int> playerIds )
		{
			game.IsActive = true;

			var gameEntity = Mapper.Map<Dal.Entities.Game>( game );

			Games.Add( gameEntity );

			SaveChanges( );

			SetGamePlayers( gameEntity, playerIds );
			AddRound( gameEntity.Id );

			return gameEntity.Id;
		}

		public Round GetCurrentRound( int gameId )
		{
			return Games
				.Where( g => g.Id == gameId )
				.Select( g => g.GameRounds.OrderByDescending( r => r.RoundNumber ).FirstOrDefault( ) )
				.ProjectTo<Round>( )
				.First( );
		}

		public List<GameListItem> GetList( Enums.ActiveStatus activeStatus )
		{
			var games = Games
				.ByActiveStatus( activeStatus )
				.ProjectTo<GameListItem>( )
				.ToList( );

			return games;
		}

		public List<PlayerTotalScore> GetPlayersTotalScoresForGame( int gameId )
		{
			var game = Games
				.Where( g => g.Id == gameId )
				.Select( g => new
				{
					IndividualScoresList = g.GameRounds.SelectMany( r => r.Scores.Select( s => new
					{
						s.PlayerId,
						s.Score
					} ) )
				} )
				.First( );

			return game.IndividualScoresList
				.GroupBy( g => g.PlayerId )
				.Select( g => new PlayerTotalScore
				{
					PlayerId = g.Key,
					TotalScore = g.Sum( s => s.Score )
				} )
				.ToList( );
		}

		public bool IsNextRoundKeepRound( int currentRoundCount, int playerCount )
		{
			return ( currentRoundCount + 1 ) == playerCount;
		}

		public void UnArchive( int gameId )
		{
			var game = Games.TryGet( gameId );

			if ( game != null )
			{
				game.IsActive = true;

				SaveChanges( );
			}
		}

		private int GetDealerPlayerOrderNumber( int roundNumber, int numberOfPlayers )
		{
			var orderNumberModulo = roundNumber % numberOfPlayers;

			if ( orderNumberModulo == 0 )
			{
				return numberOfPlayers;
			}

			return orderNumberModulo;
		}

		private void SetGamePlayers( Dal.Entities.Game game, List<int> playerIds )
		{
			foreach ( int player in playerIds )
			{
				GamePlayers.Add( new Dal.Entities.GamePlayer
				{
					PlayerId = player,
					GameId = game.Id
				} );
			}

			SaveChanges( );
		}
	}
}