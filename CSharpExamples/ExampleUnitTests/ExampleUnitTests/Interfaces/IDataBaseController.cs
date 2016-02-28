using System.Collections.Generic;

using ExampleUnitTests.Entities;

namespace ExampleUnitTests.Interfaces
{
	public interface IDataBaseController
	{
		IEnumerable<Product> GetProducts();

		int InsertProduct(Product createdProduct);

		int UpdateProduct(Product updatedProduct);

		int DeleteProduct(Product deletedProduct);
	}
}
