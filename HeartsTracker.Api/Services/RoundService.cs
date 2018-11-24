using AutoMapper;
using HeartsTracker.Api.DomainModels.PlayerScores;
using HeartsTracker.Api.DomainModels.Rounds;
using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Dal.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HeartsTracker.Api.Services
{
	public class RoundService : BaseService, IRoundService
	{
		private DbSet<Dal.Entities.GameRound> Rounds => Context.GameRounds;

		public RoundService( IMapper mapper, HeartsTrackerContext context ) : base( mapper, context )
		{
		}

		//public void CompleteRound( int roundId )
		//{
		//	throw new System.NotImplementedException( );
		//}

		//public int CreateRound( Round round )
		//{
		//	throw new System.NotImplementedException( );
		//}

		//public void UpdatePlayersScores( List<PlayerScore> playerScores )
		//{
		//}

		//public void AddPlayerScoresToRound( int roundId )
		//{
		//	throw new System.NotImplementedException( );
		//}
	}
}