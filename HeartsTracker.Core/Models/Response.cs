using System;
using System.Collections.Generic;
using System.Net;
using HeartsTracker.Core.Classes;
using HeartsTracker.Shared.Models.Player;

namespace HeartsTracker.Core.Models
{
	public class Response<T> : Response
	{
		public T Data { get; set; }
	}

	public class Response
	{
		public bool IsRequestSuccessful { get; set; }
		public string Content { get; set; }
		public Enums.DataError DataError { get; set; }
	}

	public class ErrorResponse
	{
		public string NotFoundMessage { get; set; } = "Resource not found";
		public string BadRequestMessage { get; set; } = "Request failed";
		public string ConnectionMessage { get; set; } = "Connection Error";
		public string SomethingBrokeMessage { get; set; } = "Something broke";

		public Enums.DataError Type { get; set; }

		public ErrorResponse( Enums.DataError errorType )
		{
			Type = errorType;
		}

		public string GetErrorMessage( )
		{
			string error;

			switch ( Type )
			{
				case Enums.DataError.None:
					throw new ArgumentOutOfRangeException( $"{nameof( Type )} cannot be none when an {nameof( ErrorResponse )} is produced." );
				case Enums.DataError.NotFound:
					error = NotFoundMessage;
					break;
				case Enums.DataError.BadRequest:
					error = BadRequestMessage;
					break;
				case Enums.DataError.Connection:
					error = ConnectionMessage;
					break;
				case Enums.DataError.SomethingBroke:
				default:
					error = SomethingBrokeMessage;
					break;
			}

			return error;
		}
	}
}
