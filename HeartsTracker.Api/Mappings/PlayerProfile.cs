using AutoMapper;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Shared.Models.Player;

namespace HeartsTracker.Api.Mappings
{
	public class PlayerProfile : Profile
	{
		public PlayerProfile( )
		{
			CreateMap<PlayerListItem, PlayerListItemResponse>( );
			CreateMap<PlayerDetails, PlayerResponse>( );
		}
	}
}