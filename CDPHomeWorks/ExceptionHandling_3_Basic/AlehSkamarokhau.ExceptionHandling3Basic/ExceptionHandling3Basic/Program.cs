using System;
using System.Collections.Generic;

namespace ExceptionHandling3Basic
{
	/// <summary>
	/// The helper class for string constants.
	/// </summary>
	public static class ConstantsHelper
	{
		//To call the simulation of an error.
		public const string ERROR_SIGNAL = "ERROR MESSAGE";
	}

	class Program
	{
		static void Main(string[] args)
		{
			Stack<String> container = new Stack<string>();

			container.Push("Message 1");
			container.Push("Message 2");
			container.Push("Message 3");
			container.Push(ConstantsHelper.ERROR_SIGNAL);
			container.Push("Message 4");
			container.Push("Message 5");

			INetworkSender<Stack<string>, string> sender = new StackNetworkSender();

			//BUG: IS BAD. Without unsubscribe.
			sender.ObjectSent += Sender_ObjectSent;

			try
			{
				sender.Send(container);
			}
			catch (Exception ex)
			{
				Console.WriteLine();
				Console.WriteLine(ex.ToString());
				Console.WriteLine();

				//BUG. IS BAD.
				sender.Send(container);
			}

			Console.ReadKey();
		}

		private static void Sender_ObjectSent(object sender, NetworkSenderEventArgs<string> e)
		{
			Console.WriteLine(e.SendObj);
		}
	}
}
