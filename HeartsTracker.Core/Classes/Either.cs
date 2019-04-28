using System;

namespace HeartsTracker.Core.Classes
{
	public class Either<TL, TR>
	{
		private readonly TL _left;
		private readonly TR _right;
		private readonly bool _isLeft;

		public static implicit operator Either<TL, TR>( TL left ) => new Either<TL, TR>( left );

		public static implicit operator Either<TL, TR>( TR right ) => new Either<TL, TR>( right );

		public Either( TL left )
		{
			_left = left;
			_isLeft = true;
		}

		public Either( TR right )
		{
			_right = right;
			_isLeft = false;
		}

		public T Return<T>( Func<TL, T> leftFunc, Func<TR, T> rightFunc )
			=> _isLeft ? leftFunc( _left ) : rightFunc( _right );

		public void Invoke( Action<TL> leftFunc, Action<TR> rightFunc )
		{
			if ( _isLeft )
			{
				leftFunc( _left );
			}
			else
			{
				rightFunc( _right );
			}
		}

		public Either<TL, TR> Left( Action<TL> leftFunc )
		{
			if ( _isLeft )
			{
				leftFunc( _left );
			}

			return this;
		}

		public Either<TL, TR> Right( Action<TR> rightFunc )
		{
			if ( !_isLeft )
			{
				rightFunc( _right );
			}

			return this;
		}
	}
}
