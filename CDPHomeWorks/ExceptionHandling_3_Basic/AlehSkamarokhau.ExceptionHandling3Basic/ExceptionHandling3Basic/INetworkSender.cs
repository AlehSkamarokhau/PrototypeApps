using System;
using System.Collections.Generic;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// Declares the Network Sender.
	/// </summary>
	/// <typeparam name="T">The type of an object for send.</typeparam>
	public interface INetworkSender<T>
	{
		/// <summary>
		/// Occurs when object sent.
		/// </summary>
		event EventHandler<NetworkSenderEventArgs<T>> Sent;

		/// <summary>
		/// Gets the buffer.
		/// </summary>
		/// <value>
		/// The buffer.
		/// </value>
		IList<T> Buffer { get; }

		/// <summary>
		/// Adds to buffer.
		/// </summary>
		/// <param name="obj">The object.</param>
		void AddToBuffer(T obj);

		/// <summary>
		/// Adds to buffer.
		/// </summary>
		/// <param name="container">The container.</param>
		void AddToBuffer(IEnumerable<T> container);

		/// <summary>
		/// Sends data from the instance buffer.
		/// </summary>
		void Send();
	}
}
