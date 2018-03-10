using Microsoft.AspNetCore.Mvc;

namespace HeartsTracker.Api.Controllers
{
	[Produces( "application/json" )]
	[Route( "api/[controller]" )]
	public class BaseController : Controller { }
}