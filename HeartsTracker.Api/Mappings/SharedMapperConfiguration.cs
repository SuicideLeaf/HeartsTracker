using AutoMapper;

namespace HeartsTracker.Api.Mappings
{
	public class SharedMapperConfiguration
	{
		public SharedMapperConfiguration( IMapperConfigurationExpression cfg, bool includeSharedProfiles = true )
		{
			cfg.AddProfile( new PlayerProfile( ) );
		}
	}
}