using AutoMapper;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Shared.Models.Player.Requests;

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