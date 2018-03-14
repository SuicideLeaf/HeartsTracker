using AutoMapper;
using HeartsTracker.Api.Models.Players;
using HeartsTracker.Dal.DataTransferObjects;

namespace HeartsTracker.Api.Classes
{
	public class DtoToViewModelMappingProfile : Profile
	{
		public DtoToViewModelMappingProfile( )
		{
			CreateMap<PlayerListItemDto, PlayerListItem>( );
			CreateMap<PlayerDetailsDto, PlayerDetails>( );
		}
	}
}
