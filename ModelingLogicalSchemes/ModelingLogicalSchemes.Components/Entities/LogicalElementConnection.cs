using System;

namespace ModelingLogicalSchemes.Components.Entities
{
	public class LogicalElementConnection<TLogicalElement> where TLogicalElement : class
	{
		#region Private Members

		private readonly string _numberConnection;

		private readonly bool _isBroken;

		private readonly TLogicalElement _leftElement;

		private readonly TLogicalElement _rightElement;

		#endregion

		#region Constructor

		public LogicalElementConnection(TLogicalElement leftElement, TLogicalElement rightElement, string numberConnection, bool isBroken = false)
		{
			if (leftElement == null)
			{
				throw new ArgumentNullException("leftElement");
			}

			if (rightElement == null)
			{
				throw new ArgumentNullException("rightElement");
			}

			if (String.IsNullOrEmpty(numberConnection))
			{
				throw new ArgumentException("numberConnection");
			}

			_leftElement = leftElement;
			_rightElement = rightElement;
			_numberConnection = numberConnection;
			_isBroken = isBroken;
		}

		#endregion

		#region Public Interface

		public string NumberElement
		{
			get
			{
				return _numberConnection;
			}
		}

		public TLogicalElement LeftElement
		{
			get
			{
				return _leftElement;
			}
		}

		public TLogicalElement RightElement
		{
			get
			{
				return _rightElement;
			}
		}

		public void CheckStateConnection()
		{
			if (_isBroken)
			{
				throw new Exception("Connection is broken.");
			}
		}

		#endregion
	}
}
