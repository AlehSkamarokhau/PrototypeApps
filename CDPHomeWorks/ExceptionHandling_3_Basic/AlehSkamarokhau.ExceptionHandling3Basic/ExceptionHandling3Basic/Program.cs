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
			container.Push("Message 4");
			container.Push("Message 5");

			INetworkSender<string> sender = new NetworkSender(new NetworkService());

			sender.Sent += Sender_Sent;

			sender.AddToBuffer(container);

			sender.AddToBuffer("Message 6");

			try
			{
				sender.Send();
			}
			catch (Exception ex)
			{
				Console.WriteLine();
				Console.WriteLine(ex.ToString());
				Console.WriteLine();
			}

			sender.Send();

			sender.Sent -= Sender_Sent;

			Console.ReadKey();
		}

		private static void Sender_Sent(object sender, NetworkSenderEventArgs<string> e)
		{
			Console.WriteLine(e.Data);
		}
	}
}
