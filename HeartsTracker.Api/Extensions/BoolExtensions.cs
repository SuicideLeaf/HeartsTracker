using HeartsTracker.Api.Classes;

namespace HeartsTracker.Api.Extensions
{
	public static class BoolExtensions
	{
		public static Enums.ActiveStatus ToActiveStatus( this bool? isActive )
		{
			if ( !isActive.HasValue )
			{
				return Enums.ActiveStatus.Both;
			}

			return ToActiveStatus( isActive.Value );
		}

		public static Enums.ActiveStatus ToActiveStatus( this bool isActive )
		{
			return isActive ? Enums.ActiveStatus.Active : Enums.ActiveStatus.Archived;
		}
	}
}