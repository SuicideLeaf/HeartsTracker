using AutoMapper;
using AutoMapper.QueryableExtensions;
using HeartsTracker.Api.Classes;
using HeartsTracker.Api.DomainModels.Players;
using HeartsTracker.Api.Extensions;
using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Dal.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HeartsTracker.Api.Services
{
	public class PlayerService : BaseService, IPlayerService
	{
		private DbSet<Dal.Entities.Player> Players => Context.Players;

		public PlayerService( IMapper mapper, HeartsTrackerContext context ) : base( mapper, context )
		{
		}

		public void Archive( int playerId )
		{
			var playerEntity = Players.TryGet( playerId );

			if ( playerEntity != null )
			{
				playerEntity.IsActive = false;
			}

			Context.SaveChanges( );
		}

		public int Create( Player player )
		{
			player.Colour = GetValidColour( player.Colour );

			var playerEntity = Mapper.Map<Dal.Entities.Player>( player );

			Players.Add( playerEntity );
			Context.SaveChanges( );

			return player.Id;
		}

		public Player GetDetails( int playerId )
		{
			var playerEntity = Players.TryGet( playerId );

			return Mapper.Map<Player>( playerEntity );
		}

		public List<PlayerListItem> GetList( Enums.ActiveStatus activeStatus )
		{
			var players = Players
				.ByActiveStatus( activeStatus )
				.ProjectTo<PlayerListItem>( Mapper.ConfigurationProvider )
				.ToList( );

			return players;
		}

		public bool IsPlayerNameUnique( string playerName )
		{
			return !Players.Any( p => p.PlayerName == playerName );
		}

		public void UnArchive( int playerId )
		{
			var playerEntity = Players.TryGet( playerId );

			if ( playerEntity != null )
			{
				playerEntity.IsActive = true;

				Context.SaveChanges( );
			}
		}

		public void Update( Player player )
		{
			player.Colour = GetValidColour( player.Colour );

			var playerEntity = Players.TryGet( player.Id );

			if ( playerEntity != null )
			{
				Mapper.Map( player, playerEntity );

				Context.SaveChanges( );
			}
		}

		private string GetValidColour( string colour )
		{
			if ( !string.IsNullOrWhiteSpace( colour ) && !colour.Substring( 0, 1 ).Equals( "#" ) )
			{
				return "#" + colour;
			}

			return colour;
		}
	}
}