using System;
using System.Collections.Generic;

using System.Globalization;

using System.IO;

using System.Linq;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedCSharpPart2.Tests
{
	[TestClass]
	public class ProductTests
	{
		#region Helpers Methods

		private List<Product> GetProducts()
		{
			List<Product> products = new List<Product>();

			products.Add(new Product("Trek 3500", 400M, 25));
			products.Add(new Product("Trek 7500", 650M, 30));
			products.Add(new Product("GT Agressor", 500M, 50));
			products.Add(new Product("Stels Navigator 850", 300M, 100));
			products.Add(new Product("Trek 1.2", 950M, 10));
			products.Add(new Product("Trek Madone", 1500M, 5));
			products.Add(new Product("Pinarello Dogma", 2000M, 5));

			return products;
		}

		//HACK: This is code taked from this source.
		//      http://stackoverflow.com/questions/12373800/3-digit-currency-code-to-currency-symbol
		private string GetCurrencyIDByISOCurrencySymbol(string ISOCurrencySymbol)
		{
			string result = null;

			result = CultureInfo.GetCultures(CultureTypes.AllCultures)
								.Where(c => !c.IsNeutralCulture)
								.Select(culture => {
														try
														{
															return new RegionInfo(culture.LCID);
														}
														catch
														{
															return null;
														}
													})
								.Where(ri => ri != null && ri.ISOCurrencySymbol == ISOCurrencySymbol)
								.Select(ri => ri.CurrencySymbol)
								.FirstOrDefault();

			return result;
		}

		public MemoryStream SerializeToStream(object obj)
		{
			MemoryStream stream = new MemoryStream();
			IFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, obj);
			return stream;
		}

		public object DeserializeFromStream(MemoryStream stream)
		{
			IFormatter formatter = new BinaryFormatter();
			stream.Seek(0, SeekOrigin.Begin);
			object o = formatter.Deserialize(stream);
			return o;
		}

		#endregion

		#region Test Members IComparable

		[TestCategory("Tests Members IComparable")]
		[TestMethod]
		public void CallProductCompareToCheckCurrentPrecedes()
		{
			Product p1 = new Product("Trek 3500", 400M, 25);
			Product p2 = new Product("Trek 3500", 500M, 25);

			IComparable cmprP1 = p1;

			int compareToResult = cmprP1.CompareTo(p2);

			Assert.AreEqual<int>(-1, compareToResult);
		}

		[TestCategory("Tests Members IComparable")]
		[TestMethod]
		public void CallProductCompareToCheckCurrentSome()
		{
			Product p1 = new Product("Trek 3500", 400M, 25);
			Product p2 = new Product("Trek 7500", 400M, 30);

			IComparable cmprP1 = p1;

			int compareToResult = cmprP1.CompareTo(p2);

			Assert.AreEqual<int>(0, compareToResult);
		}

		[TestCategory("Tests Members IComparable")]
		[TestMethod]
		public void CallProductCompareToCheckCurrentFollows()
		{
			Product p1 = new Product("Trek 3500", 500M, 25);
			Product p2 = new Product("Trek 3500", 400M, 25);

			IComparable cmprP1 = p1;

			int compareToResult = cmprP1.CompareTo(p2);

			Assert.AreEqual<int>(1, compareToResult);
		}

		#endregion

		#region Test Members IComparable<T>

		[TestCategory("Tests Members IComparable<T>")]
		[TestMethod]
		public void CallProductGenericCompareToCheckCurrentPrecedes()
		{
			Product p1 = new Product("Trek 3500", 400M, 25);
			Product p2 = new Product("Trek 3500", 500M, 25);

			IComparable<Product> cmprP1 = p1;

			int compareToResult = cmprP1.CompareTo(p2);

			Assert.AreEqual<int>(-1, compareToResult);
		}

		[TestCategory("Tests Members IComparable<T>")]
		[TestMethod]
		public void CallProductGenericCompareToCheckCurrentSome()
		{
			Product p1 = new Product("Trek 3500", 400M, 25);
			Product p2 = new Product("Trek 7500", 400M, 30);

			IComparable<Product> cmprP1 = p1;

			int compareToResult = cmprP1.CompareTo(p2);

			Assert.AreEqual<int>(0, compareToResult);
		}

		[TestCategory("Tests Members IComparable<T>")]
		[TestMethod]
		public void CallProductGenericCompareToCheckCurrentFollows()
		{
			Product p1 = new Product("Trek 3500", 500M, 25);
			Product p2 = new Product("Trek 3500", 400M, 25);

			IComparable<Product> cmprP1 = p1;

			int compareToResult = cmprP1.CompareTo(p2);

			Assert.AreEqual<int>(1, compareToResult);
		}

		#endregion

		#region Test Overrided Equal

		[TestCategory("Test Overrided Equal")]
		[TestMethod]
		public void CallProductOverridedEqualsCheckCurrentEqual()
		{
			Product p1 = new Product("Trek 3500", 500M, 25);
			Product p2 = new Product("Trek 3500", 500M, 25);

			bool resultEquals = p1.Equals((object)p2);

			Assert.AreEqual<bool>(true, resultEquals);
		}

		[TestCategory("Test Overrided Equal")]
		[TestMethod]
		public void CallProductOverridedEqualsCheckCurrentNotEqual()
		{
			Product p1 = new Product("Trek 3500", 500M, 25);

			Product p2 = new Product("Trek 7500", 500M, 25);

			Product p3 = new Product("Trek 3500", 600M, 25);

			Product p4 = new Product("Trek 3500", 500M, 30);

			bool resultEquals1 = p1.Equals((object)p2);

			bool resultEquals2 = p1.Equals((object)p3);

			bool resultEquals3 = p1.Equals((object)p4);

			Assert.AreEqual<bool>(false, resultEquals1);
			Assert.AreEqual<bool>(false, resultEquals2);
			Assert.AreEqual<bool>(false, resultEquals3);
		}

		#endregion

		#region Test Overrided GetHashCode

		[TestCategory("Test Overrided GetHashCode")]
		[TestMethod]
		public void CallProductOverridedGetHashCodeCheckCurrentHashsEqual()
		{
			Product p1 = new Product("Trek 3500", 500M, 25);
			Product p2 = new Product("Trek 3500", 500M, 25);

			Assert.AreEqual<int>(p1.GetHashCode(), p2.GetHashCode());
		}

		[TestCategory("Test Overrided GetHashCode")]
		[TestMethod]
		public void CallProductOverridedGetHashCodeCheckCurrentHashsNotEqual()
		{
			Product p1 = new Product("Trek 3500", 500M, 25);

			Product p2 = new Product("Trek 7500", 500M, 25);

			Product p3 = new Product("Trek 3500", 600M, 25);

			Product p4 = new Product("Trek 3500", 500M, 30);

			Assert.AreNotEqual<int>(p1.GetHashCode(), p2.GetHashCode());
			Assert.AreNotEqual<int>(p1.GetHashCode(), p3.GetHashCode());
			Assert.AreNotEqual<int>(p1.GetHashCode(), p4.GetHashCode());
		}

		#endregion

		#region Test Members IEquatable<T>

		[TestCategory("Test Members IEquatable<T>")]
		[TestMethod]
		public void CallProductGenericEqualsCheckCurrentEqual()
		{
			Product p1 = new Product("Trek 3500", 500M, 25);
			Product p2 = new Product("Trek 3500", 500M, 25);

			IEquatable<Product> eqtblP1 = p1;

			bool resultEquals = eqtblP1.Equals(p2);

			Assert.AreEqual<bool>(true, resultEquals);
		}

		[TestCategory("Test Members IEquatable<T>")]
		[TestMethod]
		public void CallProductGenericEqualsCheckCurrentNotEqual()
		{
			Product p1 = new Product("Trek 3500", 500M, 25);

			Product p2 = new Product("Trek 7500", 500M, 25);

			Product p3 = new Product("Trek 3500", 600M, 25);

			Product p4 = new Product("Trek 3500", 500M, 30);

			IEquatable<Product> eqtblP1 = p1;

			bool resultEquals1 = eqtblP1.Equals(p2);

			bool resultEquals2 = eqtblP1.Equals(p3);

			bool resultEquals3 = eqtblP1.Equals(p4);

			Assert.AreEqual<bool>(false, resultEquals1);
			Assert.AreEqual<bool>(false, resultEquals2);
			Assert.AreEqual<bool>(false, resultEquals3);
		}

		#endregion

		#region Call Overrided ToString

		[TestCategory("Call Overrided ToString")]
		[TestMethod]
		public void CallProductToString()
		{
			Product p1 = new Product("Trek 3500", 500M, 25);
			Console.WriteLine(p1.ToString());
		}

		#endregion

		#region Test Members IFormattable

		[TestCategory("Test Members IFormattable")]
		[TestMethod]
		public void CallProductFormattableToStringCheckCultureUS()
		{
			string formatPattern = @"Name = {0}, Price = {1:C}, Count = {2}";

			Product p1 = new Product("Trek 3500", 500M, 25);
			IFormattable f1 = p1;

			string expectedResult = @"Name = Trek 3500, Price = " + GetCurrencyIDByISOCurrencySymbol("USD") + @"500.00, Count = 25";

			string result = f1.ToString(formatPattern, CultureInfo.CreateSpecificCulture("en-US"));

			Console.WriteLine(String.Format("Expected: {0}", expectedResult));
			Console.WriteLine(String.Format("Actual: {0}", result));

			Assert.AreEqual<string>(expectedResult, result);
		}

		[TestCategory("Test Members IFormattable")]
		[TestMethod]
		public void CallProductFormattableToStringCheckCultureGB()
		{
			string formatPattern = @"Name = {0}, Price = {1:C}, Count = {2}";

			Product p1 = new Product("Trek 3500", 500M, 25);
			IFormattable f1 = p1;

			string expectedResult = @"Name = Trek 3500, Price = " + GetCurrencyIDByISOCurrencySymbol("GBP") + @"500.00, Count = 25";

			string result = f1.ToString(formatPattern, CultureInfo.CreateSpecificCulture("en-GB"));

			Console.WriteLine(String.Format("Expected: {0}", expectedResult));
			Console.WriteLine(String.Format("Actual: {0}", result));

			Assert.AreEqual<string>(expectedResult, result);
		}

		[TestCategory("Test Members IFormattable")]
		[TestMethod]
		public void CallProductFormattableToStringCheckCultureFR()
		{
			string formatPattern = @"Name = {0}, Price = {1:C}, Count = {2}";

			Product p1 = new Product("Trek 3500", 500M, 25);
			IFormattable f1 = p1;

			string expectedResult = @"Name = Trek 3500, Price = 500,00 " + GetCurrencyIDByISOCurrencySymbol("EUR") + ", Count = 25";

			string result = f1.ToString(formatPattern, CultureInfo.CreateSpecificCulture("fr-FR"));

			Console.WriteLine(String.Format("Expected: {0}", expectedResult));
			Console.WriteLine(String.Format("Actual: {0}", result));

			Assert.AreEqual<string>(expectedResult, result);
		}

		[TestCategory("Test Members IFormattable")]
		[TestMethod]
		public void CallProductFormattableToStringCheckCultureJP()
		{
			string formatPattern = @"Name = {0}, Price = {1:C}, Count = {2}";

			Product p1 = new Product("Trek 3500", 500M, 25);
			IFormattable f1 = p1;

			string expectedResult = @"Name = Trek 3500, Price = " + GetCurrencyIDByISOCurrencySymbol("JPY") + @"500, Count = 25";

			string result = f1.ToString(formatPattern, CultureInfo.CreateSpecificCulture("ja-JP"));

			Console.WriteLine(String.Format("Expected: {0}", expectedResult));
			Console.WriteLine(String.Format("Actual: {0}", result));

			Assert.AreEqual<string>(expectedResult, result);
		}

		#endregion

		#region Test Members ISerializable

		[TestCategory("Test Members ISerializable")]
		[TestMethod]
		public void CallProductSerializeCheckInstanse()
		{
			Product p1 = new Product("Trek 3500", 500M, 25);

			MemoryStream stream = this.SerializeToStream(p1);
			Product restoreP1 = (Product)this.DeserializeFromStream(stream);

			Console.WriteLine(String.Format("Expected: {0}", p1.ToString()));
			Console.WriteLine(String.Format("Actual: {0}", restoreP1.ToString()));

			Assert.AreEqual<Product>(p1, restoreP1);
		}

		#endregion

		#region Test Overrided Operators

		[TestCategory("Test Overrided Operators")]
		[TestMethod]
		public void CallProductOverridedOperatorCheckEqual()
		{
			Product p1 = new Product("Trek 3500", 500M, 25);
			Product p2 = new Product("Trek 7500", 500M, 30);

			Assert.AreEqual<bool>(true, p1 == p2);
		}

		[TestCategory("Test Overrided Operators")]
		[TestMethod]
		public void CallProductOverridedOperatorCheckGreaterThen()
		{
			Product p1 = new Product("Trek 3500", 700M, 25);
			Product p2 = new Product("Trek 3500", 500M, 25);

			Assert.AreEqual<bool>(true, p1 > p2);
		}

		[TestCategory("Test Overrided Operators")]
		[TestMethod]
		public void CallProductOverridedOperatorCheckGreaterThenEqualTo()
		{
			Product p1 = new Product("Trek 3500", 700M, 25);
			Product p2 = new Product("Trek 3500", 700M, 25);
			Product p3 = new Product("Trek 3500", 500M, 25);

			Assert.AreEqual<bool>(true, p1 >= p2);
			Assert.AreEqual<bool>(true, p1 >= p3);
		}

		[TestCategory("Test Overrided Operators")]
		[TestMethod]
		public void CallProductOverridedOperatorCheckLessThen()
		{
			Product p1 = new Product("Trek 3500", 300M, 25);
			Product p2 = new Product("Trek 3500", 500M, 25);

			Assert.AreEqual<bool>(true, p1 < p2);
		}

		[TestCategory("Test Overrided Operators")]
		[TestMethod]
		public void CallProductOverridedOperatorCheckLessThenEqualTo()
		{
			Product p1 = new Product("Trek 3500", 300M, 25);
			Product p2 = new Product("Trek 3500", 300M, 25);
			Product p3 = new Product("Trek 3500", 700M, 25);

			Assert.AreEqual<bool>(true, p1 <= p2);
			Assert.AreEqual<bool>(true, p1 <= p3);
		}

		#endregion
	}
}
