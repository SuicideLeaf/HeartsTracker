using AutoMapper;
using HeartsTracker.Api.DomainModels.Players;
using HeartsTracker.Shared.Models.Player;
using HeartsTracker.Shared.Models.Player.Requests;

namespace HeartsTracker.Api.Mappings
{
	public class PlayerProfile : Profile
	{
		public PlayerProfile( )
		{
			CreateMap<PlayerListItem, PlayerListItemResponse>( );

			CreateMap<CreatePlayerRequest, Player>( )
				.ForMember( dest => dest.Id, opt => opt.Ignore( ) )
				.ForMember( dest => dest.IsActive, opt => opt.Ignore( ) );

			CreateMap<UpdatePlayerRequest, Player>( )
				.ForMember( dest => dest.IsActive, opt => opt.Ignore( ) );

			CreateMap<Player, Dal.Entities.Player>( )
				.ForMember( dest => dest.GamePlayers, opt => opt.Ignore( ) )
				.ForMember( dest => dest.Scores, opt => opt.Ignore( ) )
				.ForMember( dest => dest.GamesWon, opt => opt.Ignore( ) )
				.ForMember( dest => dest.GamesLost, opt => opt.Ignore( ) )
				.ForMember( dest => dest.GameRoundsDealt, opt => opt.Ignore( ) );
		}
	}
}