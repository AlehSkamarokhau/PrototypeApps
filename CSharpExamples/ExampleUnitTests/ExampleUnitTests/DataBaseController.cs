using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleUnitTests.Entities;
using ExampleUnitTests.Interfaces;

namespace ExampleUnitTests
{
	public class DataBaseController : IDataBaseController
	{
		private List<Product> _collection;

		public DataBaseController()
		{
			_collection = new List<Product>();
		}

		public int DeleteProduct(Product deletedProduct)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Product> GetProducts()
		{
			throw new NotImplementedException();
		}

		public int InsertProduct(Product createdProduct)
		{
			MyLogger.WriteTraceMessage("Enter in InsertProduct");

			try
			{
				if (createdProduct == null)
				{
					throw new ArgumentNullException("createdProduct");
				}

				_collection.Add(createdProduct);

				return _collection.Contains(createdProduct) ? 1 : 0;
			}
			catch (Exception ex)
			{
				MyLogger.WriteErrorMessage(ex.ToString());
				return 0;
			}
			finally
			{
				MyLogger.WriteTraceMessage("Exit from InsertProduct");
			}
		}

		public int UpdateProduct(Product updatedProduct)
		{
			throw new NotImplementedException();
		}
	}
}
