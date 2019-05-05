using System.Net;

namespace HeartsTracker.Core.Classes
{
	public static class Extensions
	{
		public static Enums.DataError ToDataError( this HttpStatusCode enumValue )
		{
			switch ( enumValue )
			{
				case HttpStatusCode.NotFound:
					return Enums.DataError.NotFound;
				case HttpStatusCode.BadRequest:
					return Enums.DataError.BadRequest;
				default:
					return Enums.DataError.SomethingBroke;
			}
		}
	}
}