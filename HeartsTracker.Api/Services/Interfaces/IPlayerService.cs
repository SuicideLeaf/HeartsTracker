using HeartsTracker.Api.Classes;
using HeartsTracker.Api.DomainModels.Players;
using System.Collections.Generic;

namespace HeartsTracker.Api.Services.Interfaces
{
	public interface IPlayerService
	{
		/// <summary>
		/// Archives a <see cref="Dal.Entities.Player"/> by setting the <see cref="Dal.Entities.Player.IsActive"/> to false
		/// </summary>
		void Archive( int playerId );

		/// <summary>
		/// Creates a <see cref="Dal.Entities.Player"/> and stores them in the database
		/// </summary>
		int Create( Player player );

		/// <summary>
		/// Gets all <see cref="Dal.Entities.Player"/> details
		/// </summary>
		Player GetDetails( int playerId );

		/// <summary>
		/// Gets a list of all <see cref="Dal.Entities.Player"/>s with limited information
		/// </summary>
		List<PlayerListItem> GetList( Enums.ActiveStatus activeStatus );

		/// <summary>
		/// Archives a <see cref="Dal.Entities.Player"/> by setting the <see cref="Dal.Entities.Player.IsActive"/> to true
		/// </summary>
		void UnArchive( int playerId );

		/// <summary>
		/// Updates a <see cref="Dal.Entities.Player"/> and saves the changes to the database
		/// </summary>
		void Update( Player player );
	}
}