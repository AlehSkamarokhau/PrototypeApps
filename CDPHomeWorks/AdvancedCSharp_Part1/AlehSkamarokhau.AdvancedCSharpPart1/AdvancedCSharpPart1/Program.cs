using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdvancedCSharpPart1
{
	struct InfoData
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}

	sealed class Source
	{
		internal void CheckAndProceed(List<InfoData> data)
		{
			var dest = new Destination<InfoData>(new List<InfoData>());

			//do something

			dest.ProceedDataFor(data);
		}
	}

	sealed class Destination<TData>
	{
		private IList<TData> _items;

		public Destination(IList<TData> items)
		{
			_items = items;
		}

		public IList<TData> Items
		{
			get { return _items; }
			set { _items = value; }
		}

		internal void ProceedDataFor(IList<TData> data)
		{
			for (int i = 0; i < data.Count; i++)
			{
				//do something

				_items.Add(data[i]);
			}
		}

		internal void ProceedDataForeach(IList<TData> data)
		{
			foreach (var currentItem in data)
			{
				//do something

				_items.Add(currentItem);
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			int countObj = 10000000;

			List<InfoData> items = new List<InfoData>(countObj);

			for (int i = 0; i < items.Capacity; i++)
			{
				items.Add(new InfoData() { FirstName = i.ToString(), LastName = i.ToString() });
			}

			Destination<InfoData> dest = new Destination<InfoData>(new List<InfoData>(countObj));

			Stopwatch sw = new Stopwatch();

			sw.Start();
			dest.ProceedDataFor(items);
			sw.Stop();

			Console.WriteLine(String.Format("With FOR loop: {0}", sw.ElapsedMilliseconds));

			sw.Reset();
			dest.Items.Clear();

			sw.Start();
			dest.ProceedDataForeach(items);
			sw.Stop();

			Console.WriteLine(String.Format("With FOREACH loop: {0}", sw.ElapsedMilliseconds));

			Console.ReadLine();
		}
	}
}
