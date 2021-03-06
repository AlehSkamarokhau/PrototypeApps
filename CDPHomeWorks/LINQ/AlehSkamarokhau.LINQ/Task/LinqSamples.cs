﻿// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using SampleSupport;
using Task.Data;

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{
		private DataSource dataSource = new DataSource();

		[Title("Task 1")]
		[Description("Выдайте список всех клиентов, чей суммарный оборот (сумма всех заказов) превосходит некоторую величину X. Продемонстрируйте выполнение запроса с различными X (подумайте, можно ли обойтись без копирования запроса несколько раз).")]
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
					Console.WriteLine("Customer ID = {0} Company Name = {1} Sum Orders = {2}", currentCustomer.CustomerID, currentCustomer.CompanyName, currentCustomer.Orders.Sum(o => o.Total));
				}

				Console.WriteLine("\r\n");
			}
		}

		[Title("Task 2")]
		[Description("Для каждого клиента составьте список поставщиков, находящихся в той же стране и том же городе. Сделайте задания с использованием группировки и без.")]
		public void Linq2()
		{
			var customersAndSupplies = dataSource.Customers.Select(cst => new { CustomerID = cst.CustomerID,
																				CompanyName = cst.CompanyName,
																				Country = cst.Country,
																				City = cst.City,
																				Supplies = dataSource.Suppliers.Where(spl => spl.Country.Equals(cst.Country, StringComparison.OrdinalIgnoreCase) &&
																															 spl.City.Equals(cst.City, StringComparison.OrdinalIgnoreCase))});

			var customersAndSuppliesGrouped = dataSource.Customers.GroupBy(cst => cst.Country)
																  .Select(cst => new
																  {
																	  Country = cst.Key,
																	  Citys = cst.GroupBy(cstmr => cstmr.City).Select(cas => new
																	  {
																		  City = cas.Key,
																		  Customers = cas.Select(cstmr => new
																		  {
																			  CustomerID = cstmr.CustomerID,
																			  CompanyName = cstmr.CompanyName
																		  }),
																		  Suppliers = dataSource.Suppliers.Where(spl => spl.City.Equals(cas.Key, StringComparison.OrdinalIgnoreCase))
																	  })
																  });

			Console.WriteLine("Result without grouping by City:\r\n");

			ObjectDumper.Write(customersAndSupplies, 3);

			Console.WriteLine("\r\nResult with grouping by City:\r\n");

			ObjectDumper.Write(customersAndSuppliesGrouped, 5);
		}

		[Title("Task 3")]
		[Description("Найдите всех клиентов, у которых были заказы, превосходящие по сумме величину X.")]
		public void Linq3()
		{
			var price = 3000M;

			var findCustomers = dataSource.Customers.Where(c => c.Orders.Where(o => o.Total > price).Count() > 0);

			foreach (var currentCustomer in findCustomers)
			{
				var findCustomerOrders = currentCustomer.Orders.Where(o => o.Total > price).OrderByDescending(o => o.Total);

				Console.WriteLine("Customer ID - {0}, Company Name - {1}, Count Orders - {2}:", currentCustomer.CustomerID, currentCustomer.CompanyName, findCustomerOrders.Count());

				foreach (var currentOrder in findCustomerOrders)
				{
					Console.WriteLine("Order ID - {0}, Total - {1}", currentOrder.OrderID, currentOrder.Total);
				}

				Console.WriteLine();
			}
		}

		[Title("Task 4")]
		[Description("Выдайте список клиентов с указанием, начиная с какого месяца какого года они стали клиентами (принять за таковые месяц и год самого первого заказа).")]
		public void Linq4()
		{
			var customers = dataSource.Customers.Where(c => c.Orders.Count() > 0).Select(c => new
			{
				CustomerID = c.CustomerID,
				CompanyName = c.CompanyName,
				FirstDate = c.Orders.Min(o => o.OrderDate),
				Total = c.Orders.Sum(o => o.Total)
			});

			foreach (var currentCustomer in customers)
			{
				Console.WriteLine("Date - {0}, Total - {1}, Company Name - {2}, Customer ID - {3}", currentCustomer.FirstDate.ToShortDateString(),
																									currentCustomer.Total,
																									currentCustomer.CompanyName,
																									currentCustomer.CustomerID);
			}
		}

		[Title("Task 5")]
		[Description("Сделайте предыдущее задание, но выдайте список отсортированным по году, месяцу, оборотам клиента (от максимального к минимальному) и имени клиента.")]
		public void Linq5()
		{
			var customers = dataSource.Customers.Where(c => c.Orders.Count() > 0).Select(c => new
			{
				CustomerID = c.CustomerID,
				CompanyName = c.CompanyName,
				FirstDate = c.Orders.Min(o => o.OrderDate),
				Total = c.Orders.Sum(o => o.Total)
			})
			.OrderBy(c => c.CompanyName)
			.OrderByDescending(c => c.Total)
			.OrderBy(c => c.FirstDate.Month)
			.OrderBy(c => c.FirstDate.Year);

			foreach (var currentCustomer in customers)
			{
				Console.WriteLine("Date - {0}, Total - {1}, Company Name - {2}, Customer ID - {3}", currentCustomer.FirstDate.ToShortDateString(),
																									currentCustomer.Total,
																									currentCustomer.CompanyName,
																									currentCustomer.CustomerID);
			}
		}

		[Title("Task 6")]
		[Description("Укажите всех клиентов, у которых указан нецифровой код или не заполнен регион или в телефоне не указан код оператора (для простоты считаем, что это равнозначно «нет круглых скобочек в начале»).")]
		public void Linq6()
		{
			var customers = dataSource.Customers.Where(new Func<Customer, bool>((Customer c) =>
			{
				int number;
				return !int.TryParse(c.CustomerID, out number) ||
						string.IsNullOrWhiteSpace(c.Region) ||
						c.Phone[0] != '(';
			}));

			foreach (var currentCustomer in customers)
			{
				Console.WriteLine("Customer ID - {0},\tRegion - {1},\tPhone - {2}", currentCustomer.CustomerID, currentCustomer.Region, currentCustomer.Phone);
			}
		}

		[Title("Task 7")]
		[Description("Сгруппируйте все продукты по категориям, внутри – по наличию на складе, внутри последней группы отсортируйте по стоимости.")]
		public void Linq7()
		{
			var products = dataSource.Products.GroupBy(prd => prd.Category)
											  .Select(ctg => new
											  {
												  Category = ctg.Key,
												  Products = ctg.GroupBy(prd => prd.UnitsInStock > 0)
																.Select(grp => new { InStock = grp.Key, Products = grp.OrderBy(prd => prd.UnitPrice) })
											  });

			ObjectDumper.Write(products, 2);
		}

		[Title("Task 8")]
		[Description("Сгруппируйте товары по группам «дешевые», «средняя цена», «дорогие». Границы каждой группы задайте сами.")]
		public void Linq8()
		{
			var highPrice = 100M;
			var lowPrice = 20M;

			var gruppedProducts = new
			{
				CheapProducts = dataSource.Products.Where(p => p.UnitPrice <= lowPrice),
				AverageProducts = dataSource.Products.Where(p => p.UnitPrice >= lowPrice & p.UnitPrice <= highPrice),
				ExpensiveProducts = dataSource.Products.Where(p => p.UnitPrice >= highPrice)
			};

			Console.WriteLine("Cheap Products:");
			foreach (var currentProduct in gruppedProducts.CheapProducts)
			{
				Console.WriteLine("ID - {0}\tName - {1}\tPrice - {2}", currentProduct.ProductID, currentProduct.ProductName, currentProduct.UnitPrice);
			}

			Console.WriteLine("\r\nAverage Products:");
			foreach (var currentProduct in gruppedProducts.AverageProducts)
			{
				Console.WriteLine("ID - {0}\tName - {1}\tPrice - {2}", currentProduct.ProductID, currentProduct.ProductName, currentProduct.UnitPrice);
			}

			Console.WriteLine("\r\nExpensive Products:");
			foreach (var currentProduct in gruppedProducts.ExpensiveProducts)
			{
				Console.WriteLine("ID - {0}\tName - {1}\tPrice - {2}", currentProduct.ProductID, currentProduct.ProductName, currentProduct.UnitPrice);
			}
		}

		[Title("Task 9")]
		[Description("Рассчитайте среднюю прибыльность каждого города (среднюю сумму заказа по всем клиентам из данного города) и среднюю интенсивность (среднее количество заказов, приходящееся на клиента из каждого города).")]
		public void Linq9()
		{
			var averageCityProfitability = dataSource.Customers.GroupBy(cst => cst.City)
															   .Select(cityProf => new
															   {
																   City = cityProf.Key,
																   CustomersProfitability = Math.Round(cityProf.Where(cst => cst.Orders.Count() > 0).Select(cst => cst.Orders.Select(ord => ord.Total).Average()).Average(), 3)
															   })
															   .OrderByDescending(cityProfit => cityProfit.CustomersProfitability);

			var averageCityOrderCount = dataSource.Customers.GroupBy(cst => cst.City)
															.Select(ordFreq => new
															{
																City = ordFreq.Key,
																AverageOrderCount = Math.Round(ordFreq.Where(cst => cst.Orders.Count() > 0).Select(cst => cst.Orders.Count()).Average(), 1)
															})
															.OrderByDescending(ordFreq => ordFreq.AverageOrderCount);

			Console.WriteLine("Average City Profitability:\r\n");
			ObjectDumper.Write(averageCityProfitability, 2);

			Console.WriteLine("\r\nAverage City Orders Frequency:\r\n");
			ObjectDumper.Write(averageCityOrderCount, 2);
		}

		[Title("Task 10")]
		[Description("Сделайте среднегодовую статистику активности клиентов по месяцам (без учета года), статистику по годам, по годам и месяцам (т.е. когда один месяц в разные годы имеет своё значение).")]
		public void Linq10()
		{
			var monthStatistics = dataSource.Customers.Select(cst => new { CustomerID = cst.CustomerID,
																		  CompanyName = cst.CompanyName,
																		  Statistics = cst.Orders.GroupBy(ord => ord.OrderDate.Month)
																								 .Select(sts => new { Month = sts.Key,
																													  CountOrders = sts.Count(),
																													  TotalProfit = sts.Sum(ord => ord.Total),
																													  AverageOrderPrice = Math.Round(sts.Average(ord => ord.Total), 3)})});

			var yearStatistics = dataSource.Customers.Select(cst => new { CustomerID = cst.CustomerID,
																		  CompanyName = cst.CompanyName,
																		  Statistics = cst.Orders.GroupBy(ord => ord.OrderDate.Year)
																								 .Select(sts => new { Year = sts.Key,
																													  CountOrders = sts.Count(),
																													  TotalProfit = sts.Sum(ord => ord.Total),
																													  AverageOrderPrice = Math.Round(sts.Average(ord => ord.Total), 3)
																								 })
			});

			var yearAndMonthStatistics = dataSource.Customers.Select(cst => new { CustomerID = cst.CustomerID,
																				  CompanyName = cst.CompanyName,
																				  Statistics = cst.Orders.GroupBy(ord => ord.OrderDate.Year)
																								 .Select(sts => new { Year = sts.Key,
																													  CountOrders = sts.Count(),
																													  TotalProfit = sts.Sum(ord => ord.Total),
																													  AverageOrderPrice = Math.Round(sts.Average(ord => ord.Total), 3),
																													  MonthStatistics = sts.GroupBy(ord => ord.OrderDate.Month)
																																		   .Select(msts => new { Month = msts.Key,
																																								 CountOrders = msts.Count(),
																																								 TotalProfit = msts.Sum(ord => ord.Total),
																																								 AverageOrderPrice = Math.Round(msts.Average(ord => ord.Total), 3)})
																								 })
			});

			Console.WriteLine("Statistics by Months:\r\n");
			ObjectDumper.Write(monthStatistics, 3);

			Console.WriteLine("\r\nStatistics by Years:\r\n");
			ObjectDumper.Write(yearStatistics, 3);

			Console.WriteLine("\r\nStatistics by Years and Months:\r\n");
			ObjectDumper.Write(yearAndMonthStatistics, 3);
		}
	}
}
