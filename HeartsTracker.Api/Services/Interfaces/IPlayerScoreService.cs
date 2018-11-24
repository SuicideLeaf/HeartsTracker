using HeartsTracker.Api.DomainModels.PlayerScores;
using System.Collections.Generic;

namespace HeartsTracker.Api.Services.Interfaces
{
	public interface IPlayerScoreService
	{
		/// <summary>
		/// Updates a range of players scores.
		/// </summary>
		void UpdateRange( List<PlayerScore> playerScores );
	}
}