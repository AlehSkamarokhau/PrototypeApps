using System;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// The event class for Network Services.
	/// </summary>
	/// <seealso cref="System.EventArgs" />
	[Serializable]
	public class NetworkEventArgs : EventArgs
	{
		private object _data;

		/// <summary>
		/// Gets or sets the sent data.
		/// </summary>
		/// <value>
		/// The sent data.
		/// </value>
		public object Data
		{
			get
			{
				return _data;
			}
			set
			{
				_data = value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkEventArgs"/> class.
		/// </summary>
		public NetworkEventArgs()
		{
			//Empty.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkEventArgs"/> class.
		/// </summary>
		/// <param name="data">The sent data.</param>
		public NetworkEventArgs(object data)
		{
			_data = data;
		}
	}
}
