using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HeartsTracker.Api.Models;
using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Dal.DataTransferObjects;
using HeartsTracker.Dal.Entities;
using HeartsTracker.Dal.Repositories.Interfaces;

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

		public PlayerList GetList( )
		{
			List<PlayerListItemDto> playerDtos = _playerRepository.GetAllPlayers( );
			List<PlayerListItem> players = playerDtos.Select( p => _mapper.Map<PlayerListItem>( p ) ).ToList( );

			return new PlayerList( players );
		}

		public PlayerList GetList( bool? isActive )
		{
			PlayerList playerList;
			if ( isActive.HasValue )
			{
				List<PlayerListItemDto> playerDtos = _playerRepository.GetPlayersByActive( isActive.Value );
				List<PlayerListItem> players = playerDtos.Select( p => _mapper.Map<PlayerListItem>( p ) ).ToList( );

				playerList = new PlayerList( players );
			}
			else
			{
				playerList = GetList( );
			}

			return playerList;
		}

		public PlayerDetails GetDetails( int playerId )
		{
			PlayerDetailsDto playerDetailsDto = _playerRepository.GetPlayerDetails( playerId );

			return _mapper.Map<PlayerDetails>( playerDetailsDto );
		}

		public void Create( PlayerDetails playerDetails )
		{
			Player player = new Player
			{
				PlayerName = playerDetails.PlayerName,
				FirstName = playerDetails.FirstName,
				LastName = playerDetails.LastName,
				Colour = playerDetails.Colour,
				IsActive = true
			};

			_playerRepository.Add( player );
			_playerRepository.SaveChanges( );
		}

		public void UpdateDetails( PlayerDetails playerDetails )
		{
			Player player = _playerRepository.Get( playerDetails.Id );

			if ( player != null )
			{
				player.PlayerName = playerDetails.PlayerName;
				player.FirstName = playerDetails.FirstName;
				player.LastName = playerDetails.LastName;
				player.Colour = playerDetails.Colour;
			}

			_playerRepository.SaveChanges( );
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

		public void UnArchive( int playerId )
		{
			Player player = _playerRepository.Get( playerId );

			if ( player != null )
			{
				player.IsActive = true;
			}

			_playerRepository.SaveChanges( );
		}
	}
}
