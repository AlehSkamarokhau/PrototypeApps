using System;
using System.Globalization;

namespace AdvancedCSharpPart2
{

	struct Product : IFormattable, IComparable, IComparable<Product>, IEquatable<Product>
	{
		private string _name;

		private decimal _price;

		private uint _count;

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public decimal Price
		{
			get
			{
				return _price;
			}
		}

		public uint Count
		{
			get
			{
				return _count;
			}
		}

		public Product(string name, decimal price, uint count)
		{
			_name = name;
			_price = price;
			_count = count;
		}

		public int CompareTo(object obj)
		{
			return CompareTo((Product)obj);
		}

		public int CompareTo(Product other)
		{
			return _price.CompareTo(other.Price);
		}

		public override bool Equals(object obj)
		{
			return Equals((Product)obj);
		}

		public bool Equals(Product other)
		{
			return _name.Equals(other.Name, StringComparison.OrdinalIgnoreCase) & _price.Equals(other.Price) & _count.Equals(other.Count);
		}

		public override int GetHashCode()
		{
			return String.Concat(_name, _price.ToString(), _count.ToString()).GetHashCode();
		}

		public override string ToString()
		{
			return String.Format(CultureInfo.CurrentCulture, "Name = {0}, Price = {1:C}, Count = {2}", _name, _price.ToString(), _count.ToString());
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return String.Format(formatProvider, format, _name, _price.ToString(), _count.ToString());
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
		}
	}
}
