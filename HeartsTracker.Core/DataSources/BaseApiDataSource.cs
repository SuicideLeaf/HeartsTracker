using HeartsTracker.Core.Callbacks;
using HeartsTracker.Core.Classes;
using Refit;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HeartsTracker.Core.DataSources
{
	public class BaseApiDataSource
	{
		public virtual void HandleResponse( ResponseWrapper response, Action successAction, IBaseCallback callback )
		{
			if ( response.StatusCode == HttpStatusCode.OK )
			{
				successAction( );
			}
			else
			{
				callback.OnDataError( response.StatusCode.Value.ToDataError( ) );
			}
		}

		/// <summary>
		/// Catches any exceptions when making a request.
		/// </summary>
		/// <returns>Returns object of type <see cref="ResponseWrapper{T}"/>. If the request failed, the status code will be returned instead of the content.</returns>
		public async Task<ResponseWrapper<T>> SafeCallApi<T>( Func<Task<T>> action )
		{
			try
			{
				T result = await action( );

				return new ResponseWrapper<T>
				{
					Content = result,
					StatusCode = HttpStatusCode.OK
				};
			}
			catch ( ApiException e )
			{
				return new ResponseWrapper<T>
				{
					StatusCode = e.StatusCode
				};
			}
			catch ( Exception e )
			{
				throw e;

				//return new T
				//{
				//	DataError = Enums.DataError.Connection
				//};
			}
		}
	}

	public class ResponseWrapper<T> : ResponseWrapper
	{
		public T Content { get; set; }
	}

	public class ResponseWrapper
	{
		public HttpStatusCode? StatusCode { get; set; }
	}
}