using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Repositories.Interfaces;

namespace HeartsTracker.Api.Models
{
	public class PlayerDetails
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PlayerName { get; set; }
		public string Colour { get; set; }
		public bool IsActive { get; set; }

		public static PlayerDetails Get( IPlayerRepository playerRepository, int id )
		{
			PlayerDetailsDto playerDetailsDto = playerRepository.GetPlayerDetails( id );
			return playerRepository.Mapper.Map<PlayerDetails>( playerDetailsDto );
		}
	}
}