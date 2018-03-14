using Refit;

namespace HeartsTracker.Core.QueryParams
{
	public class QueryParameters
	{
		[AliasAs( "token" )]
		public string Token { get; set; }
		[AliasAs( "requestIdentifier" )]
		public string RequestIdentifier { get; set; }
		[AliasAs( "deviceIdentifier" )]
		public string DeviceIdentifier { get; set; }
		[AliasAs( "checksum" )]
		public string Checksum { get; set; }

		public void SetupBaseQueryParameters( string token, string requestIdentifier, string deviceIdentifier, string checksum )
		{
			Token = token;
			RequestIdentifier = requestIdentifier;
			DeviceIdentifier = deviceIdentifier;
			Checksum = checksum;
		}
	}
}