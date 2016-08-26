using System;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// Defines the Network Service.
	/// </summary>
	/// <seealso cref="ExceptionHandling3Basic.INetworkService" />
	/// <seealso cref="System.IDisposable" />
	public class NetworkService : INetworkService, IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkService"/> class.
		/// </summary>
		public NetworkService()
		{
			//Empty.
		}

		/// <summary>
		/// Occurs when sent data.
		/// </summary>
		public event EventHandler<NetworkEventArgs> Sent;

		/// <summary>
		/// Sends the specified data.
		/// </summary>
		/// <typeparam name="T">The type of a data.</typeparam>
		/// <param name="data">The data.</param>
		/// <exception cref="ArgumentNullException">When data is null.</exception>
		public void Send<T>(T data)
		{
			if (!typeof(T).IsValueType)
			{
				if (data == null)
				{
					throw new ArgumentNullException("data");
				}
			}

			//Do something for sending by network.

			Sent?.Invoke(this, new NetworkEventArgs(data));
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Sent = null;
		}
	}
}
