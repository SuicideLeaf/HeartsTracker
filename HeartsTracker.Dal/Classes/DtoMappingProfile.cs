using AutoMapper;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Entities;

namespace HeartsTracker.Dal.Classes
{
	public class DtoMappingProfile : Profile
	{
		public DtoMappingProfile( )
		{
			CreateMap<Player, PlayerListItemDto>( );
		}
	}
}
