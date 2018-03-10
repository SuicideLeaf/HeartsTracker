using AutoMapper;
using HeartsTracker.Api.Models;
using HeartsTracker.Dal.DataTransferObjects;

namespace HeartsTracker.Api.Classes
{
	public class ViewModelMappingProfile : Profile
	{
		public ViewModelMappingProfile( )
		{
			CreateMap<PlayerListItemDto, PlayerListItem>( );
			CreateMap<PlayerDetailsDto, PlayerDetails>( );
		}
	}
}
