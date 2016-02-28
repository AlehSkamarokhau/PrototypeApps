using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleUnitTests.Entities;
using ExampleUnitTests.Interfaces;

using LightInject;

namespace ExampleUnitTests
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Start");

			var container = new ServiceContainer();
			container.Register<IDataBaseController, DataBaseController>();

			IDataBaseController _dbController = container.GetInstance<IDataBaseController>();

			Product p1 = new Product()
			{
				Id = 1
			};

			Product p2 = new Product()
			{
				Id = 2
			};

			Product p3 = null;

			_dbController.InsertProduct(p1);
			_dbController.InsertProduct(p3);
			_dbController.InsertProduct(p2);

			Console.WriteLine("End");

			Console.ReadLine();
		}
	}
}
