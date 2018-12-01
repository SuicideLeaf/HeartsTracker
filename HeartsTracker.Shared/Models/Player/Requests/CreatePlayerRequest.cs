using System.ComponentModel.DataAnnotations;

namespace HeartsTracker.Shared.Models.Player.Requests
{
	public class CreatePlayerRequest
	{
		[Required( AllowEmptyStrings = false )]
		public string PlayerName { get; set; }

		[Required( AllowEmptyStrings = false )]
		public string FirstName { get; set; }

		[Required( AllowEmptyStrings = false )]
		public string LastName { get; set; }

		[Required( AllowEmptyStrings = false )]
		public string Colour { get; set; }

		public CreatePlayerRequest( string playerName, string firstName, string lastName, string colour )
		{
			PlayerName = playerName;
			FirstName = firstName;
			LastName = lastName;
			Colour = colour;
		}
	}
}