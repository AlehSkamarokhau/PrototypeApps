using System;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// Declares the Network Sender.
	/// </summary>
	/// <typeparam name="T">Type of objects to sent.</typeparam>
	public interface INetworkSender<T>
	{
		/// <summary>
		/// Occurs when object sent.
		/// </summary>
		event EventHandler<NetworkSenderEventArgs<T>> ObjectSent;

		/// <summary>
		/// Sends the specified object.
		/// </summary>
		/// <param name="obj">The object.</param>
		void Send(T obj);
	}
}
