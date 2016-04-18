using System;
using System.Collections.Generic;

namespace ModelingLogicalSchemes.Components.Entities
{
	public class LogicalElement
	{
		#region Private Fields

		private int _numberElement;

		private Func<bool[], bool> _function;

		private BrokenTypes _brokenType;

		#endregion

		#region Public Properties

		public int NumberElement
		{
			get
			{
				return _numberElement;
			}
			set
			{
				_numberElement = value;
			}
		}

		public Func<bool[], bool> Function
		{
			get
			{
				return _function;
			}
			set
			{
				_function = value;
			}
		}

		public BrokenTypes BrokenType
		{
			get
			{
				return _brokenType;
			}
			set
			{
				_brokenType = value;
			}
		}

		#endregion

		#region Constructors

		public LogicalElement()
		{
			//Empty.
		}

		public LogicalElement(Func<bool[], bool> function, int numberElement, BrokenTypes brokenType = BrokenTypes.Non)
		{
			_numberElement = numberElement;
			_brokenType = brokenType;
			_function = function;
		}

		#endregion

		#region Public Interface

		public bool GetOutputValue(params bool[] inputValues)
		{
			try
			{
				if (inputValues == null)
				{
					throw new ArgumentNullException("inputValues");
				}

				if (inputValues.Length == 0)
				{
					throw new ArgumentException("inputValues");
				}

				if (_brokenType != BrokenTypes.Non)
				{
					throw new Exception("Element is broken.");
				}
			}
			catch (ArgumentNullException)
			{
				throw;
			}
			catch (ArgumentException)
			{
				throw;
			}
			catch
			{
				switch (_brokenType)
				{
					case BrokenTypes.Non:
						return _function(inputValues);

					case BrokenTypes.NonSignal:
						//throw;
						return default(bool);

					case BrokenTypes.IncorrectSignal:
						return !_function(inputValues);

					case BrokenTypes.ConstantSignal:
						return default(bool);

					default:
						break;
				}
			}

			return _function(inputValues);
		}

		#endregion
	}
}
