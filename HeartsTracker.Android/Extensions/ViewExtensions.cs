using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;

namespace HeartsTracker.Android.Extensions
{
	public static class ViewExtensions
	{
		public static void ToCircle( this View view, Color colour )
		{
			GradientDrawable circle = new GradientDrawable( );
			circle.SetShape( ShapeType.Oval );
			circle.SetColor( colour );

			view.Background = circle;
		}
	}
}