using System;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// Declares the Network Service.
	/// </summary>
	public interface INetworkService
	{
		/// <summary>
		/// Occurs when sent data.
		/// </summary>
		event EventHandler<NetworkEventArgs> Sent;

		/// <summary>
		/// Sends the specified data.
		/// </summary>
		/// <typeparam name="T">The type of a data.</typeparam>
		/// <param name="data">The data.</param>
		void Send<T>(T data);
	}
}
