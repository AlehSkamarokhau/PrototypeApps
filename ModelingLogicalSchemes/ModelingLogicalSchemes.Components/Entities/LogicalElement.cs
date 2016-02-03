using System;
using System.Collections.Generic;

namespace ModelingLogicalSchemes.Components.Entities
{
	public delegate TOutput LogicalElementFunction<TInput, TOutput>(TInput[] inputValues);

	public class LogicalElement<TInput, TOutput>
	{
		#region Private Fields

		private readonly int _numberElement;

		private readonly bool _isBrokenElement;

		private readonly LogicalElementFunction<TInput, TOutput> _function;

		private Dictionary<LogicalElementConnection<LogicalElement<TInput, TOutput>>, LogicalElementConnectionType> _connections;

		#endregion

		#region Constructor

		public LogicalElement(LogicalElementFunction<TInput, TOutput> function, int numberElement, bool isBrokenElement = false)
		{
			if (function == null)
			{
				throw new ArgumentNullException("function");
			}

			_numberElement = numberElement;
			_isBrokenElement = isBrokenElement;
			_function = new LogicalElementFunction<TInput, TOutput>(function);
		}

		#endregion

		#region Public Interface

		public int NumberElement
		{
			get
			{
				return _numberElement;
			}
		}

		public void SetConnections(Dictionary<LogicalElementConnection<LogicalElement<TInput, TOutput>>, LogicalElementConnectionType> connections)
		{
			if (connections == null)
			{
				throw new ArgumentNullException("connections");
			}

			if (connections.Count == 0)
			{
				throw new ArgumentException("connections");
			}

			_connections = connections;
		}

		public TOutput GetOutputValue(params TInput[] inputValues)
		{
			if (inputValues == null)
			{
				throw new ArgumentNullException("inputValues");
			}

			if (inputValues.Length == 0)
			{
				throw new ArgumentException("inputValues");
			}

			if (_isBrokenElement)
			{
				throw new Exception("Element is broken.");
			}

			return _function(inputValues);
		}

		#endregion
	}
}
