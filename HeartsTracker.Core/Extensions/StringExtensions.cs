using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HeartsTracker.Core.Extensions
{
	public static class StringExtensions
	{
		/// <summary>
		/// Tries to get a model state error from the string. String should be valid json in the form of a Dictionary.
		/// </summary>
		/// <returns>Returns null if deserialization failed or the model state values are not strings.</returns>
		public static bool TryReadAsModelState( this string modelStateJson, out string error )
		{
			try
			{
				var anonymousErrorObject = new { message = "", ModelState = new Dictionary<string, string[ ]>( ) };
				var deserializedErrorObject = JsonConvert.DeserializeAnonymousType( modelStateJson, anonymousErrorObject );

				if ( deserializedErrorObject.ModelState != null )
				{
					IEnumerable<string[ ]> errors = deserializedErrorObject.ModelState
						.Select( kvp => kvp.Value );

					error = errors.First( ).First( );

					return true;
				}
				else
				{
					Dictionary<string, string> errors = JsonConvert.DeserializeObject<Dictionary<string, string>>( modelStateJson );

					if ( errors.Any( ) )
					{
						error = errors.First( ).Value;

						return true;
					}
				}

				error = null;

				return false;
			}
			catch ( Exception )
			{
				error = null;

				return false;
			}
		}
	}
}
