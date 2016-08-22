using System;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// Declares the Network Sender.
	/// </summary>
	/// <typeparam name="TContainer">The type of the container.</typeparam>
	/// <typeparam name="TObject">The type of the object.</typeparam>
	public interface INetworkSender<TContainer, TObject>
	{
		/// <summary>
		/// Occurs when object sent.
		/// </summary>
		event EventHandler<NetworkSenderEventArgs<TObject>> ObjectSent;

		/// <summary>
		/// Sends the specified object.
		/// </summary>
		/// <param name="container">The object.</param>
		void Send(TContainer container);
	}
}
