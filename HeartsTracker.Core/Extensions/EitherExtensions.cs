using System;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models;

namespace HeartsTracker.Core.Extensions
{
	public static class EitherExtensions
	{
		public static Either<TL, string> ConfigureNotFound<TL>( this Either<TL, ErrorResponse> either, Func<TL, bool> hasDataFunc, string notFoundMessage )
		{
			return either.Return<Either<TL, string>>( data =>
			{
				if ( !hasDataFunc( data ) )
					return notFoundMessage;

				return data;
			}, error => error.ToErrorMessage( notFoundMessage ) );
		}

		public static Either<TL, string> ConfigureNotFound<TL>( this Either<TL, ErrorResponse> either, string notFoundMessage )
		{
			return either.Return<Either<TL, string>>( data => data, error => error.ToErrorMessage( notFoundMessage ) );
		}

		/// <summary>
		/// A simple success wrapper for the left either, designed purely for readability.
		/// Useful when dealing with responses from a data source.
		/// </summary>
		public static Either<TL, TR> OnSuccess<TL, TR>( this Either<TL, TR> either, Action<TL> leftFunc ) => either.Left( leftFunc );

		/// <summary>
		/// A simple error wrapper for the right either, designed purely for readability.
		/// Useful when dealing with responses from a data source.
		/// </summary>
		public static Either<TL, TR> OnError<TL, TR>( this Either<TL, TR> either, Action<TR> rightFunc ) => either.Right( rightFunc );
	}
}
