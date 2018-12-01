using System.ComponentModel.DataAnnotations;

namespace HeartsTracker.Shared.Models.Player.Requests
{
	public class UpdatePlayerRequest
	{
		[Required( AllowEmptyStrings = false )]
		public string PlayerName { get; set; }

		[Required( AllowEmptyStrings = false )]
		public string FirstName { get; set; }

		[Required( AllowEmptyStrings = false )]
		public string LastName { get; set; }

		[Required( AllowEmptyStrings = false )]
		public string Colour { get; set; }
	}
}