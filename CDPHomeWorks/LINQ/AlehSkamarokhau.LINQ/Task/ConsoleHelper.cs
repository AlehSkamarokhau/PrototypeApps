using System;

namespace Task
{
	public static class ConsoleHelper
	{
		public static void WriteSplitLine(char splitSymbol, int sizeLine)
		{
			for (int i = 0; i < sizeLine; i++)
			{
				Console.Write(splitSymbol);
			}
			Console.Write("\r\n\r\n");
		}
	}
}
