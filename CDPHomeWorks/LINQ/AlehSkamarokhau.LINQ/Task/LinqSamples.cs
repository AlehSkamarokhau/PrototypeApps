﻿// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{
		private const int DEFAULT_SIZE_SPLIT_LINE = 70;

		private DataSource dataSource = new DataSource();

		[Category("Restriction Operators")]
		[Title("Example 1. Where - Task 1")]
		[Description("This sample uses the where clause to find all elements of an array with a value less than 5.")]
		public void LinqExample1()
		{
			int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

			var lowNums =
				from num in numbers
				where num < 5
				select num;

			Console.WriteLine("Numbers < 5:");
			foreach (var x in lowNums)
			{
				Console.WriteLine(x);
			}
		}

		[Category("Restriction Operators")]
		[Title("Example 2. Where - Task 2")]
		[Description("This sample return return all presented in market products")]
		public void LinqExample2()
		{
			var products =
				from p in dataSource.Products
				where p.UnitsInStock > 0
				select p;

			foreach (var p in products)
			{
				ObjectDumper.Write(p);
			}
		}

		[Title("Task 1")]
		public void Linq1()
		{
			var inputValues = new decimal[] { 5000M, 10000M, 20000M };

			var GetFilteredCustomers = new Func<decimal, IEnumerable<Customer>>((totalSumOrders) =>
			{
				return dataSource.Customers.Where(c => c.Orders.Sum(o => o.Total) > totalSumOrders);
			});

			Dictionary<decimal, IEnumerable<Customer>> results = new Dictionary<decimal, IEnumerable<Customer>>();

			for (int i = 0; i < inputValues.Length; i++)
			{
				results.Add(inputValues[i], GetFilteredCustomers(inputValues[i]));
			}

			foreach (var currentKey in results.Keys)
			{
				Console.WriteLine("Customers with the sum of order is more {0}:\r\n", currentKey);

				foreach (var currentCustomer in results[currentKey])
				{
					//TODO: Impruve. Don't get Sum Orders again.
					Console.WriteLine("Customer ID = {0} Company Name = {1} Sum Orders = {2}", currentCustomer.CustomerID, currentCustomer.CompanyName, currentCustomer.Orders.Sum(o => o.Total));
				}

				Console.WriteLine("\r\n");
			}
		}

		[Title("Task 2")]
		public void Linq2()
		{
			//TODO: Check results.

			Dictionary<Customer, IList<Supplier>> customersAndSupplies = new Dictionary<Customer, IList<Supplier>>();
			Dictionary<Customer, IList<IGrouping<string, Supplier>>> customersAndSuppliesGrouped = new Dictionary<Customer, IList<IGrouping<string, Supplier>>>();

			foreach (var currentCustomer in dataSource.Customers)
			{
				customersAndSupplies.Add(currentCustomer, dataSource.Suppliers.Where(s => s.Country.Equals(currentCustomer.Country, StringComparison.OrdinalIgnoreCase) &&
																						  s.City.Equals(currentCustomer.City, StringComparison.OrdinalIgnoreCase)).ToList());

				customersAndSuppliesGrouped.Add(currentCustomer, dataSource.Suppliers.Where(s => s.Country.Equals(currentCustomer.Country, StringComparison.OrdinalIgnoreCase) &&
																						  s.City.Equals(currentCustomer.City, StringComparison.OrdinalIgnoreCase)).GroupBy(s => s.City).ToList());
			}

			Console.WriteLine("Result without grouping by City:\r\n");

			ConsoleHelper.WriteSplitLine('=', DEFAULT_SIZE_SPLIT_LINE);

			foreach (var currentCustomer in customersAndSupplies.Keys)
			{
				if (customersAndSupplies[currentCustomer].Count > 0)
				{
					Console.WriteLine("Customer - {0}, Country - {1}, City - {2}:\r\n", currentCustomer.CompanyName, currentCustomer.Country, currentCustomer.City);

					foreach (var currentSupplier in customersAndSupplies[currentCustomer])
					{
						Console.WriteLine("{0} :: {1}, {2}", currentSupplier.SupplierName, currentSupplier.Country, currentSupplier.City);
					}

					Console.WriteLine("\r\n");
				}
			}

			ConsoleHelper.WriteSplitLine('=', DEFAULT_SIZE_SPLIT_LINE);

			Console.WriteLine("Result with grouping by City:\r\n");

			ConsoleHelper.WriteSplitLine('=', DEFAULT_SIZE_SPLIT_LINE);

			foreach (var currentCustomer in customersAndSuppliesGrouped.Keys)
			{
				if (customersAndSuppliesGrouped[currentCustomer].Count > 0)
				{
					Console.WriteLine("Customer - {0}, Country - {1}, City - {2}:\r\n", currentCustomer.CompanyName, currentCustomer.Country, currentCustomer.City);

					foreach (var currentGroupSupplies in customersAndSuppliesGrouped[currentCustomer])
					{
						foreach (var currentSupplier in currentGroupSupplies)
						{
							Console.WriteLine("{0} :: {1}, {2}", currentSupplier.SupplierName, currentSupplier.Country, currentSupplier.City);
						}
					}

					Console.WriteLine("\r\n");
				}
			}

			ConsoleHelper.WriteSplitLine('=', DEFAULT_SIZE_SPLIT_LINE);
		}

		[Title("Task 3")]
		public void Linq3()
		{
			var price = 3000M;

			var findCustomers = dataSource.Customers.Where(c => c.Orders.Where(o => o.Total > price).Count() > 0);

			foreach (var currentCustomer in findCustomers)
			{
				var findCustomerOrders = currentCustomer.Orders.Where(o => o.Total > price).OrderByDescending(o => o.Total);

				Console.WriteLine("Customer ID - {0}, Company Name - {1}, Count Orders - {2}:", currentCustomer.CustomerID, currentCustomer.CompanyName, findCustomerOrders.Count());

				ConsoleHelper.WriteSplitLine('=', DEFAULT_SIZE_SPLIT_LINE);

				foreach (var currentOrder in findCustomerOrders)
				{
					Console.WriteLine("Order ID - {0}, Total - {1}", currentOrder.OrderID, currentOrder.Total);
				}

				Console.WriteLine();
			}
		}

		[Title("Task 4")]
		public void Linq4()
		{
			foreach (var currentCustomer in dataSource.Customers)
			{
				if (currentCustomer.Orders.Count() > 0)
				{
					var dateFirstOrder = currentCustomer.Orders.Min(o => o.OrderDate);

					Console.WriteLine("Customer ID - {0}, Company Name - {1}, Date - {2}", currentCustomer.CustomerID, currentCustomer.CompanyName, dateFirstOrder.ToShortDateString());
				}
			}
		}
	}
}