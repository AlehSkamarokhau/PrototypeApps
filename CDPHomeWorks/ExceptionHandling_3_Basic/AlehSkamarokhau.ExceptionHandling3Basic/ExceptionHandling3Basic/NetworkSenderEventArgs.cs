using System;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// The event class for INetworkSender.
	/// </summary>
	/// <typeparam name="TTypeSendObject">The type of the send object.</typeparam>
	/// <seealso cref="System.EventArgs" />
	[Serializable]
	public class NetworkSenderEventArgs<TTypeSendObject> : EventArgs
	{
		private TTypeSendObject _sendObj;

		/// <summary>
		/// Gets or sets the send object.
		/// </summary>
		/// <value>
		/// The send object.
		/// </value>
		public TTypeSendObject SendObj
		{
			get { return _sendObj; }
			set { _sendObj = value; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkSenderEventArgs{TTypeSendObject}"/> class.
		/// </summary>
		public NetworkSenderEventArgs() : base()
		{
			//Empty.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkSenderEventArgs{TTypeSendObject}"/> class.
		/// </summary>
		/// <param name="obj">The object.</param>
		public NetworkSenderEventArgs(TTypeSendObject obj) : base()
		{
			_sendObj = obj;
		}
	}
}
