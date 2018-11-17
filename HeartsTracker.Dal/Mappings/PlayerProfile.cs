using AutoMapper;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Entities;

namespace HeartsTracker.Dal.Mappings
{
	public class PlayerProfile : Profile
	{
		public PlayerProfile( )
		{
			CreateMap<Player, PlayerListItem>( );
		}
	}
}