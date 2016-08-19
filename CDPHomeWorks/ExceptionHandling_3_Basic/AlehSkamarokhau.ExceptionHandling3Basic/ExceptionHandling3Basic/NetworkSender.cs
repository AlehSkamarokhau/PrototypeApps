using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExceptionHandling3Basic
{
	public class NetworkSender : INetworkSender<string>
	{
		private const int DEFAULT_CAPACITY = 100;

		private Stack<string> _tempStorage;

		private BackgroundWorker _bgWorker;

		private void AddToTempStorage(string obj)
		{
			_tempStorage.Push(obj);
		}

		public NetworkSender()
		{
			_tempStorage = new Stack<string>(DEFAULT_CAPACITY);

			_bgWorker = new BackgroundWorker();

			_bgWorker.DoWork += _bgWorker_DoWork;
			_bgWorker.ProgressChanged += _bgWorker_ProgressChanged;
			_bgWorker.RunWorkerCompleted += _bgWorker_RunWorkerCompleted;
		}

		public event EventHandler<NetworkSenderEventArgs<string>> ObjectSent;

		public void Send(string obj)
		{
			AddToTempStorage(obj);
		}

		private void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//TODO: Add the return of the result.

			_bgWorker.DoWork -= _bgWorker_DoWork;
			_bgWorker.ProgressChanged -= _bgWorker_ProgressChanged;
			_bgWorker.RunWorkerCompleted -= _bgWorker_RunWorkerCompleted;
		}

		private void _bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			while (true)
			{
				if (_tempStorage.Count > 0)
				{
					ObjectSent?.Invoke(this, new NetworkSenderEventArgs<string>(_tempStorage.Pop()));

					Thread.Sleep(new TimeSpan(0, 0, 15));
				}
			}
		}
	}
}
