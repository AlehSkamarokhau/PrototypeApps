using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsOnCSharp.InsertionSort
{
	public class ProgramHelper
	{
		public string PrintArrayToStr(int[] items)
		{
			StringBuilder strBuild = new StringBuilder();

			for (int i = 0; i < items.Length; i++)
			{
				strBuild.Append(items[i].ToString());
				strBuild.Append('\t');
			}

			return strBuild.ToString();
		}

		public int[] GetInsertionSortedArray(int[] items, bool isShowOutput = false)
		{
			for (int i = 1; i < items.Length; i++)
			{
				int cur = items[i];
				int j = i;

				while (j > 0 && cur < items[j - 1])
				{
					items[j] = items[j - 1];
					j--;
				}

				items[j] = cur;

				if (isShowOutput)
				{
					Console.WriteLine("\r\nCurrent items position:\r\n");
					Console.WriteLine(PrintArrayToStr(items));
				}
			}

			return items;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Press any key for start.");
			Console.ReadKey();

			ProgramHelper ph = new ProgramHelper();

			int[] nums = { 5, 2, 10, 6, 33, 25, 13, 30, 19 };

			Console.WriteLine("\r\nItems:\r\n");
			Console.WriteLine(ph.PrintArrayToStr(nums));

			Console.WriteLine("\r\nPress any key for continue.");
			Console.ReadKey();

			int[] sortedNums = ph.GetInsertionSortedArray(nums, true);

			Console.WriteLine("\r\nSorted Items:\r\n");
			Console.WriteLine(ph.PrintArrayToStr(sortedNums));

			Console.WriteLine("\r\nFor exit press any key.");
			Console.ReadKey();
		}
	}
}
