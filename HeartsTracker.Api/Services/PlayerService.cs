using AutoMapper;
using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Entities;
using HeartsTracker.Dal.Repositories.Interfaces;
using HeartsTracker.Shared.Models.Player.Requests;
using System.Collections.Generic;
using System.Linq;

namespace HeartsTracker.Api.Services
{
	public class PlayerService : IPlayerService
	{
		private readonly IMapper _mapper;
		private readonly IPlayerRepository _playerRepository;

		public PlayerService( IMapper mapper, IPlayerRepository playerRepository )
		{
			_mapper = mapper;
			_playerRepository = playerRepository;
		}

		public void Archive( int playerId )
		{
			Player player = _playerRepository.Get( playerId );

			if ( player != null )
			{
				player.IsActive = false;
			}

			_playerRepository.SaveChanges( );
		}

		public PlayerListItemResponse Create( AddPlayerRequest playerRequest )
		{
			Player player = new Player
			{
				PlayerName = playerRequest.PlayerName,
				FirstName = playerRequest.FirstName,
				LastName = playerRequest.LastName,
				Colour = playerRequest.Colour,
				IsActive = true
			};

			_playerRepository.Add( player );
			_playerRepository.SaveChanges( );

			PlayerListItem playerListItemDto = _mapper.Map<PlayerListItem>( player );

			return _mapper.Map<PlayerListItemResponse>( playerListItemDto );
		}

		public PlayerResponse GetDetails( int playerId )
		{
			PlayerDetails playerDetailsDto = _playerRepository.GetPlayerDetails( playerId );

			return _mapper.Map<PlayerResponse>( playerDetailsDto );
		}

		public PlayerListResponse GetList( )
		{
			List<PlayerListItem> playerDtos = _playerRepository.GetPlayers( );
			List<PlayerListItemResponse> players = playerDtos.Select( p => _mapper.Map<PlayerListItemResponse>( p ) ).ToList( );

			return new PlayerListResponse( players );
		}

		public PlayerListResponse GetList( bool? isActive )
		{
			PlayerListResponse playerList;
			if ( isActive.HasValue )
			{
				List<PlayerListItem> playerDtos = _playerRepository.GetPlayers( isActive.Value );
				List<PlayerListItemResponse> players = playerDtos.Select( p => _mapper.Map<PlayerListItemResponse>( p ) ).ToList( );

				playerList = new PlayerListResponse( players );
			}
			else
			{
				playerList = GetList( );
			}

			return playerList;
		}

		public void UnArchive( int playerId )
		{
			Player player = _playerRepository.Get( playerId );

			if ( player != null )
			{
				player.IsActive = true;

				_playerRepository.SaveChanges( );
			}
		}

		public void Update( UpdatePlayerRequest updateRequest )
		{
			Player player = _playerRepository.Get( updateRequest.Id );

			if ( player != null )
			{
				player.PlayerName = updateRequest.PlayerName;
				player.FirstName = updateRequest.FirstName;
				player.LastName = updateRequest.LastName;
				player.Colour = updateRequest.Colour;

				_playerRepository.SaveChanges( );
			}
		}
	}
}