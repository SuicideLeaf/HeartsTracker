using HeartsTracker.Api.Classes;
using HeartsTracker.Api.DomainModels.Games;
using HeartsTracker.Api.DomainModels.PlayerScores;
using HeartsTracker.Api.DomainModels.Rounds;
using System.Collections.Generic;

namespace HeartsTracker.Api.Services.Interfaces
{
	public interface IGameService
	{
		/// <summary>
		/// Adds a <see cref="Dal.Entities.GameRound"/> for a particular <see cref="Dal.Entities.Game"/>
		/// </summary>
		/// <returns>Returns the <see cref="Dal.Entities.GameRound.Id"/> of the added round</returns>
		int AddRound( int gameId );

		/// <summary>
		/// Archives a <see cref="Dal.Entities.Game"/> by setting <see cref="Dal.Entities.Game.IsActive"/> to false
		/// </summary>
		void Archive( int gameId );

		/// <summary>
		/// Completes a <see cref="Dal.Entities.Game"/> by setting the <see cref="Dal.Entities.Game.IsComplete"/> to true
		/// </summary>
		void Complete( int gameId );

		/// <summary>
		/// Completes a particular <see cref="Dal.Entities.GameRound"/> by setting the <see cref="Dal.Entities.GameRound.IsComplete"/> to true
		/// </summary>
		void CompleteRound( int id );

		/// <summary>
		/// Creates a <see cref="Dal.Entities.Game"/> with some players and stores it in the database
		/// </summary>
		/// <returns>Returns the <see cref="Dal.Entities.Game.Id"/> of the created game</returns>
		int Create( Game game, List<int> playerIds );

		/// <summary>
		/// Gets the current <see cref="Round"/> of an incomplete <see cref="Dal.Entities.Game"/>
		/// </summary>
		Round GetCurrentRound( int gameId );

		/// <summary>
		/// Gets a list of all games
		/// </summary>
		List<GameListItem> GetList( Enums.ActiveStatus activeStatus );

		/// <summary>
		/// Gets a list of total scores for each <see cref="Dal.Entities.Player"/> of a <see cref="Dal.Entities.Game"/>
		/// </summary>
		List<PlayerTotalScore> GetPlayersTotalScoresForGame( int gameId );

		/// <summary>
		/// Determines whether the next <see cref="Round"/> of a <see cref="Dal.Entities.Game"/> is a keep round
		/// </summary>
		bool IsNextRoundKeepRound( int currentRoundCount, int playerCount );

		/// <summary>
		/// Archives a <see cref="Dal.Entities.Game"/> by setting the <see cref="Dal.Entities.Game.IsActive"/> to true
		/// </summary>
		void UnArchive( int playerId );
	}
}