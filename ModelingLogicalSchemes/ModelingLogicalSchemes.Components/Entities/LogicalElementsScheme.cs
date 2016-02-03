using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingLogicalSchemes.Components.Entities
{
	public class LogicalElementsScheme<TLogicalElement, TLogicalElementConnection> where TLogicalElement : class
																				   where TLogicalElementConnection : class
	{
		#region Private Fields

		private List<TLogicalElement> _elements;

		private List<TLogicalElementConnection> _connections;

		#endregion

		#region Constructor

		public LogicalElementsScheme(List<TLogicalElement> elements, List<TLogicalElementConnection> connections)
		{

		}

		#endregion

		#region Public Interface

		public List<TLogicalElement> Elements
		{
			get
			{
				return _elements;
			}
		}

		public List<TLogicalElementConnection> Connections
		{
			get
			{
				return _connections;
			}
		}

		#endregion
	}
}
