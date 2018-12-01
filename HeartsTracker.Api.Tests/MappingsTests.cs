using AutoMapper;
using HeartsTracker.Api.Mappings;
using Xunit;

namespace HeartsTracker.Api.Tests
{
	public class MappingsTests
	{
		[Fact]
		public void AssertMappingsProfilesConfiguration( )
		{
			var mapper = new Mapper( new MapperConfiguration( cfg => new SharedMapperConfiguration( cfg ) ) );
			mapper.DefaultContext.ConfigurationProvider.AssertConfigurationIsValid( );
		}
	}
}