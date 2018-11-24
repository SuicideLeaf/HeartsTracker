using HeartsTracker.Api.Classes;

namespace HeartsTracker.Api.Extensions
{
	public static class EnumExtensions
	{
		public static bool ToBool( this Enums.ActiveStatus activeStatus )
		{
			switch ( activeStatus )
			{
				case Enums.ActiveStatus.Archived:
					return false;

				case Enums.ActiveStatus.Active:
				default:
					return true;
			}
		}
	}
}