using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleUnitTests.Entities;
using ExampleUnitTests.Interfaces;

using LightInject;
using NUnit.Framework;

namespace ExampleUnitTests.Tests
{

	[TestFixture]
	public class DataBaseControllerTest
	{
		[Test]
		public void InsertProduct_Returned1()
		{
			//Arrange
			var container = new ServiceContainer();
			container.Register<IDataBaseController, DataBaseController>();

			Product fakeProduct = new Product()
			{
				Id = 100,
				Name = "FooProduct",
				Price = 25
			};

			IDataBaseController dataBaseController = container.GetInstance<IDataBaseController>();

			//Act
			int resultOperation = dataBaseController.InsertProduct(fakeProduct);

			//Assert
			Assert.AreEqual(resultOperation, 1);
		}

		[Test]
		public void InsertProduct_TakeNullArg_ThrowArgumentNullException()
		{
			//Arrange
			var container = new ServiceContainer();
			container.Register<IDataBaseController, DataBaseController>();

			IDataBaseController dataBaseController = container.GetInstance<IDataBaseController>();

			//Assert
			Assert.Throws<ArgumentNullException>(() =>
			{
				Product fakeProduct = null;
				dataBaseController.InsertProduct(fakeProduct);
			});
		}
	}
}
