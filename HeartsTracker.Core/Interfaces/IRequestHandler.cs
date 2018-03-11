using System;
using System.Collections.Generic;
using System.Text;

namespace HeartsTracker.Core.Interfaces
{
	public interface IRequestHandler
	{
		string InstanceUrl { get; }
		string DeviceIdentifier { get; }
		string DeviceInfo { get; }
		Guid ConsumerKey { get; }
		Guid Secret { get; }
		Guid? AuthenticationToken { get; }
	}
}
