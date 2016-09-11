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
		//HACK: For the generate error only once.
		private bool _isThrowError;

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkService"/> class.
		/// </summary>
		public NetworkService()
		{
			_isThrowError = true;
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

			//HACK: For generate error.
			if (_isThrowError)
			{
				if (data is string)
				{
					if ((data as string) == ConstantsHelper.ERROR_SIGNAL)
					{
						_isThrowError = false;
						throw new NetworkException("Something network error.");
					}
				}
			}

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
