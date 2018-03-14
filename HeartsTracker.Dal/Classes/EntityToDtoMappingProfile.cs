using AutoMapper;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Entities;

namespace HeartsTracker.Dal.Classes
{
	public class EntityToDtoMappingProfile : Profile
	{
		public EntityToDtoMappingProfile( )
		{
			CreateMap<Player, PlayerListItemDto>( );
		}
	}
}
