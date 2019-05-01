using HeartsTracker.Core.Classes;
using HeartsTracker.Core.Extensions;
using HeartsTracker.Core.Models;
using Refit;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HeartsTracker.Core.DataSources
{
	public class BaseApiDataSource
	{
		public virtual async Task<Either<TL, ErrorResponse>> RequestAsync<TL>( Func<Task<TL>> action )
		{
			try
			{
				return await action( );
			}
			catch ( ApiException e )
			{
				Enums.DataError dataError = e.StatusCode.ToDataError( );

				if ( e.StatusCode.Equals( HttpStatusCode.BadRequest ) && e.Content.TryReadAsModelState( out string error ) )
				{
					return new ErrorResponse( dataError )
					{
						BadRequestMessage = error
					};
				}

				return new ErrorResponse( dataError );
			}
			catch ( Exception )
			{
				return new ErrorResponse( Enums.DataError.SomethingBroke );
			}
		}

		///// <summary>
		///// Catches any exceptions when making a request and returns an appropriate data error to return in the callback
		///// </summary>
		///// <returns>Returns object of type <see cref="Response{T}"/>. If the request failed this method will return an appropriate data error/content with it.</returns>
		//public virtual async Task<Response<T>> RequestAsyncOld<T>( Func<Task<T>> action )
		//{
		//	try
		//	{
		//		T data = await action( );

		//		Response<T> response = new Response<T>
		//		{
		//			Data = data,
		//			Content = string.Empty,
		//			IsRequestSuccessful = true
		//		};

		//		return response;
		//	}
		//	catch ( ApiException e )
		//	{
		//		Response<T> response = new Response<T>
		//		{
		//			Content = e.Content,
		//			IsRequestSuccessful = false,
		//			DataError = e.StatusCode.ToDataError( )
		//		};

		//		return response;
		//	}
		//	catch ( Exception )
		//	{
		//		Response<T> response = new Response<T>
		//		{
		//			Content = string.Empty,
		//			IsRequestSuccessful = false,
		//			DataError = Enums.DataError.Connection
		//		};

		//		return response;
		//	}
		//}

		///// <summary>
		///// Catches any exceptions when making a request and returns an appropriate data error to return in the callback
		///// </summary>
		///// <returns>Returns object of type <see cref="Response"/>. If the request failed this method will return an appropriate data error/content with it.</returns>
		//public virtual async Task<Response> RequestAsync( Func<Task> action )
		//{
		//	try
		//	{
		//		await action( );

		//		Response response = new Response
		//		{
		//			Content = string.Empty,
		//			IsRequestSuccessful = true
		//		};

		//		return response;
		//	}
		//	catch ( ApiException e )
		//	{
		//		Response response = new Response
		//		{
		//			Content = e.Content,
		//			IsRequestSuccessful = false,
		//			DataError = e.StatusCode.ToDataError( )
		//		};

		//		return response;
		//	}
		//	catch ( Exception )
		//	{
		//		Response response = new Response
		//		{
		//			Content = string.Empty,
		//			IsRequestSuccessful = false,
		//			DataError = Enums.DataError.Connection
		//		};

		//		return response;
		//	}
		//}

		///// <summary>
		///// Calls the given success action if the response is successful.
		///// Tries to fetch a new instance url if the device is connected by the response gives a connection error.
		///// </summary>
		///// <param name="callback">Base callback for when there is a data error to trigger.</param>
		///// <param name="response">The response from a previous request.</param>
		///// <param name="successAction">Success action to trigger if the response given is successful.</param>
		//public virtual void HandleResponse( IBaseCallback callback, Response response, Action successAction )
		//{
		//	if ( response.IsRequestSuccessful )
		//	{
		//		successAction( );
		//	}
		//	else
		//	{
		//		callback.OnDataError( response.DataError, response.Content );
		//	}
		//}
	}
}