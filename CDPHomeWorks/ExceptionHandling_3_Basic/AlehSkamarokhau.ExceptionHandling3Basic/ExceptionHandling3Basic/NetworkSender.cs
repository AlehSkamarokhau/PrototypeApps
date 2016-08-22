using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// Defines the Network Sender.
	/// </summary>
	/// <typeparam name="T">Type of objects to sent.</typeparam>
	/// <seealso cref="ExceptionHandling3Basic.INetworkSender{T}" />
	/// <seealso cref="ExceptionHandling3Basic.INetworkSender{System.String}" />
	/// <seealso cref="System.IDisposable" />
	public class NetworkSender<T> : INetworkSender<T>, IDisposable
	{
		private const int DEFAULT_CAPACITY = 100;

		private Stack<T> _tempStorage;

		private BackgroundWorker _bgWorker;

		private void AddToTempStorage(T obj)
		{
			_tempStorage.Push(obj);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkSender"/> class.
		/// </summary>
		public NetworkSender()
		{
			_tempStorage = new Stack<T>(DEFAULT_CAPACITY);

			_bgWorker = new BackgroundWorker();

			_bgWorker.DoWork += _bgWorker_DoWork;
		}

		/// <summary>
		/// Occurs when object sent.
		/// </summary>
		public event EventHandler<NetworkSenderEventArgs<T>> ObjectSent;

		/// <summary>
		/// Sends the specified object.
		/// </summary>
		/// <param name="obj">The object.</param>
		public void Send(T obj)
		{
			AddToTempStorage(obj);
		}

		private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			while (true)
			{
				if (_tempStorage.Count > 0)
				{
					ObjectSent?.Invoke(this, new NetworkSenderEventArgs<T>(_tempStorage.Pop()));

					Thread.Sleep(new TimeSpan(0, 0, 15));

					//HACK: This is code to simulate network error.
					if (_tempStorage.Count < 3)
					{
						throw new Exception("Network error.");
					}
				}
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			_bgWorker.DoWork -= _bgWorker_DoWork;
		}
	}
}
