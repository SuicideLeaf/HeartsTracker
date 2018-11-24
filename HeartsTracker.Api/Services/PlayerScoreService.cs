using AutoMapper;
using HeartsTracker.Api.DomainModels.PlayerScores;
using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Dal.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HeartsTracker.Api.Services
{
	public class PlayerScoreService : BaseService, IPlayerScoreService
	{
		private DbSet<Dal.Entities.PlayerScore> PlayerScores => Context.PlayerScores;

		public PlayerScoreService( IMapper mapper, HeartsTrackerContext context ) : base( mapper, context )
		{
		}

		public void UpdateRange( List<PlayerScore> playerScores )
		{
			List<Dal.Entities.PlayerScore> playerScoreEntities = PlayerScores
				.Where( s => playerScores
					.Any( ps =>
						ps.RoundId == s.RoundId &&
						ps.PlayerId == s.PlayerId ) )
				.ToList( );

			foreach ( var score in playerScores )
			{
				Dal.Entities.PlayerScore playerScoreEntity = playerScoreEntities
					.First( s =>
						s.PlayerId == score.PlayerId &&
						s.RoundId == score.RoundId );

				Mapper.Map( score, playerScoreEntity );
			}

			SaveChanges( );
		}
	}
}