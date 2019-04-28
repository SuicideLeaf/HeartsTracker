using HeartsTracker.Core.Classes;

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
}
