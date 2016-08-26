using System;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// The event class for Network Senders.
	/// </summary>
	/// <typeparam name="T">The type of the send object.</typeparam>
	/// <seealso cref="System.EventArgs" />
	[Serializable]
	public class NetworkSenderEventArgs<T> : EventArgs
	{
		private T _data;

		/// <summary>
		/// Gets or sets the sent data.
		/// </summary>
		/// <value>
		/// The sent data.
		/// </value>
		public T Data
		{
			get { return _data; }
			set { _data = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkSenderEventArgs{TTypeSendObject}"/> class.
		/// </summary>
		public NetworkSenderEventArgs()
		{
			//Empty.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkSenderEventArgs{TTypeSendObject}"/> class.
		/// </summary>
		/// <param name="data">The sent data.</param>
		public NetworkSenderEventArgs(T data)
		{
			_data = data;
		}
	}
}
