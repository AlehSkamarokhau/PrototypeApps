using System;
using System.Collections.Generic;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// Defines the sender for stack.
	/// </summary>
	/// <seealso cref="ExceptionHandling3Basic.INetworkSender{System.Collections.Generic.Stack{System.String}, System.String}" />
	public class StackNetworkSender : INetworkSender<Stack<string>, string>
	{
		#region Private Fields

		//HACK: This flag needs for simulating error only once.
		private bool _isThrowException;

		#endregion

		#region Private Members

		private void SendData(string data)
		{
			//HACK: The next block needs for simulated error.
			if (!_isThrowException)
			{
				if (data.Equals(ConstantsHelper.ERROR_SIGNAL, StringComparison.OrdinalIgnoreCase))
				{
					_isThrowException = true;
					throw new Exception("Network error.");
				}
			}

			//HACK: The next statement to simulate sending data.
			ObjectSent?.Invoke(this, new NetworkSenderEventArgs<string>(data));
		}

		private void SendDataFromStack(Stack<string> container)
		{
			while (container.Count > 0)
			{
				//This call is required to save the object on the stack when an error occurs.
				SendData(container.Peek());

				//This call is required to remove the object from the stack when sending was successful.
				container.Pop();
			}
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="StackNetworkSender"/> class.
		/// </summary>
		public StackNetworkSender()
		{
			_isThrowException = false;
		}

		#endregion

		#region INetworkSender<T> Members

		/// <summary>
		/// Occurs when object sent.
		/// </summary>
		public event EventHandler<NetworkSenderEventArgs<string>> ObjectSent;

		/// <summary>
		/// Sends the specified object.
		/// </summary>
		/// <param name="container">The object.</param>
		public void Send(Stack<string> container)
		{
			SendDataFromStack(container);
		}

		#endregion
	}
}
