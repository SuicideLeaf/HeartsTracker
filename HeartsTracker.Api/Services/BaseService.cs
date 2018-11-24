using AutoMapper;
using HeartsTracker.Dal.Contexts;

namespace HeartsTracker.Api.Services
{
	public class BaseService
	{
		public HeartsTrackerContext Context { get; }
		public IMapper Mapper { get; }

		public BaseService( IMapper mapper, HeartsTrackerContext context )
		{
			Context = context;
			Mapper = mapper;
		}

		public void SaveChanges( )
		{
			Context.SaveChanges( );
		}
	}
}