using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// Defines the sender for stack.
	/// </summary>
	/// <seealso cref="ExceptionHandling3Basic.INetworkSender{System.Collections.Generic.Stack{System.String}, System.String}" />
	public class NetworkSender : INetworkSender<string>, IDisposable
	{
		#region Private Fields

		private INetworkService _networkService;

		private Queue<string> _buffer;

		#endregion

		#region Private Members

		private INetworkService NetworkService
		{
			get
			{
				return _networkService;
			}
			set
			{
				if (value == null)
				{
					throw new NullReferenceException("_networkService");
				}

				_networkService = value;
			}
		}

		#endregion

		#region Public Properties

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkSender"/> class.
		/// </summary>
		/// <param name="networkService">The network service.</param>
		public NetworkSender(INetworkService networkService)
		{
			NetworkService = networkService;

			_buffer = new Queue<string>();

			NetworkService.Sent += NetworkService_Sent;
		}

		#endregion

		#region INetworkSender<T> Members

		/// <summary>
		/// Occurs when object sent.
		/// </summary>
		public event EventHandler<NetworkSenderEventArgs<string>> Sent;

		/// <summary>
		/// Adds to buffer.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <exception cref="ArgumentNullException">When obj is null.</exception>
		public void AddToBuffer(string obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}

			_buffer.Enqueue(obj);
		}

		/// <summary>
		/// Adds to buffer.
		/// </summary>
		/// <param name="container">The container.</param>
		public void AddToBuffer(IEnumerable<string> container)
		{
			if (container == null)
			{
				throw new ArgumentNullException("container");
			}

			foreach (var item in container)
			{
				AddToBuffer(item);
			}
		}

		/// <summary>
		/// Sends data from the instance buffer.
		/// </summary>
		public void Send()
		{
			while (_buffer.Count > 0)
			{
				try
				{
					NetworkService.Send<string>(_buffer.Peek());
				}
				catch (ArgumentNullException ex)
				{
					//Do something for logging.
					Debug.WriteLine(ex.ToString());
					throw;
				}
				catch (NetworkException ex)
				{
					//Do something for logging.
					Debug.WriteLine(ex.ToString());
					throw;
				}

				_buffer.Dequeue();
			}
		}

		#endregion

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			NetworkService.Sent -= NetworkService_Sent;
			Sent = null;
			(NetworkService as IDisposable)?.Dispose();
		}

		#endregion

		#region Event Handlers

		private void NetworkService_Sent(object sender, NetworkEventArgs e)
		{
			Sent?.Invoke(this, new NetworkSenderEventArgs<string>((string)e.Data));
		}

		#endregion
	}
}
