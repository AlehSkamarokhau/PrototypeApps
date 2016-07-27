using System;
using System.Globalization;

namespace AdvancedCSharpPart2
{
	public struct Product : IFormattable, IComparable, IComparable<Product>, IEquatable<Product>
	{
		#region Private Fields

		private string _name;

		private decimal _price;

		private uint _count;

		#endregion

		#region Properties

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

		#endregion

		#region Constructor

		public Product(string name, decimal price, uint count)
		{
			_name = name;
			_price = price;
			_count = count;
		}

		#endregion

		#region ICompareble Members

		public int CompareTo(object obj)
		{
			return CompareTo((Product)obj);
		}

		#endregion

		#region ICompareble<T> Members

		public int CompareTo(Product other)
		{
			return _price.CompareTo(other.Price);
		}

		#endregion

		#region IEquatable<T> Members

		public bool Equals(Product other)
		{
			return _name.Equals(other.Name, StringComparison.OrdinalIgnoreCase) & _price.Equals(other.Price) & _count.Equals(other.Count);
		}

		#endregion

		#region Overrided Methods

		public override bool Equals(object obj)
		{
			return Equals((Product)obj);
		}

		public override int GetHashCode()
		{
			return String.Concat(_name, _price.ToString(), _count.ToString()).GetHashCode();
		}

		public override string ToString()
		{
			return String.Format(CultureInfo.CurrentCulture, "Name = {0}, Price = {1:C}, Count = {2}", _name, _price.ToString(), _count.ToString());
		}

		#endregion

		#region IFormattable Members

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return String.Format(formatProvider, format, _name, _price.ToString(), _count.ToString());
		}

		#endregion

		#region Overrided Operators

		public static bool operator ==(Product x, Product y)
		{
			return x.Price == y.Price;
		}

		public static bool operator !=(Product x, Product y)
		{
			return x.Price != y.Price;
		}

		public static bool operator >(Product x, Product y)
		{
			return x.Price > y.Price;
		}

		public static bool operator >=(Product x, Product y)
		{
			return x.Price >= y.Price;
		}

		public static bool operator <(Product x, Product y)
		{
			return x.Price < y.Price;
		}

		public static bool operator <=(Product x, Product y)
		{
			return x.Price <= y.Price;
		}

		#endregion
	}
}
