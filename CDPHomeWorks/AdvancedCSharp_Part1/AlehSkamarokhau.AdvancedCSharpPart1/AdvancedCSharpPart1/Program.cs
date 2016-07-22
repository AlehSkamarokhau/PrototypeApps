using System.Collections.Generic;

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
			var dest = new Destination();

			//do something

			dest.ProceedData<InfoData>(data);
		}
	}

	sealed class Destination
	{
		internal void ProceedData<TData>(IList<TData> data)
		{
			for (int i = 0; i < data.Count; i++)
			{
				//do something
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
		}
	}
}
