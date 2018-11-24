using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace HeartsTracker.Api.Controllers
{
	[Produces( "application/json" )]
	[Route( "api/[controller]" )]
	[ApiController]
	public class BaseController : ControllerBase
	{
		public IMapper Mapper { get; }

		public BaseController( IMapper mapper )
		{
			Mapper = mapper;
		}
	}
}