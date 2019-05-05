using System;
using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Models;

namespace HeartsTracker.Core.Extensions
{
	public static class EitherExtensions
	{
		/// <summary>		
		/// Transforms an either of error type <see cref="ErrorResponse"/>, into error type <see cref="string"/> by doing the following:		
		/// <para/><para/>
		/// Validates the left data, returns the specified <paramref name="errorMessage"/> if validation fails.
		/// <para/>
		/// Configures the right error's <see cref="Enums.DataError.NotFound"/> message, returns appropriate error message.
		/// </summary>
		public static Either<TL, string> ConfigureNotFound<TL>( this Either<TL, ErrorResponse> either, Func<TL, bool> hasData, string errorMessage )
		{
			return either.Return<Either<TL, string>>( data =>
			{
				if ( !hasData( data ) )
					return errorMessage;

				return data;
			}, error =>
			{
				error.NotFoundMessage = errorMessage;
				return error.GetErrorMessage( );
			} );
		}

		/// <summary>		
		/// Transforms an either of error type <see cref="ErrorResponse"/>, into error type <see cref="string"/> by doing the following:		
		/// <para/><para/>
		/// Configures the right error's <see cref="Enums.DataError.NotFound"/> message, returns appropriate error message.
		/// </summary>
		public static Either<TL, string> ConfigureNotFound<TL>( this Either<TL, ErrorResponse> either, string errorMessage )
		{
			return either.Return<Either<TL, string>>( data => data, error =>
			{
				error.NotFoundMessage = errorMessage;
				return error.GetErrorMessage( );
			} );
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
