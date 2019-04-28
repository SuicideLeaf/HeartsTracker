using System;
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
		public string Content { get; set; }
		public Enums.DataError Error { get; set; }

		public ErrorResponse( string content, Enums.DataError error )
		{
			Content = content;
			Error = error;
		}

		public string ToErrorMessage( string notFound )
		{
			string error;

			switch ( Error )
			{
				case Enums.DataError.None:
					throw new ArgumentOutOfRangeException( $"{nameof( Error )} cannot be none when an {nameof( ErrorResponse )} is produced." );
				case Enums.DataError.NotFound:
					error = notFound;
					break;
				case Enums.DataError.Connection:
				default:
					error = "Connection Error";
					break;
			}

			return error;
		}
	}
}
