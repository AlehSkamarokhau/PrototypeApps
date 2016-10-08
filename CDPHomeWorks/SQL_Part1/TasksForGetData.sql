USE Northwind;
GO

-- ******************** TASK # 2.1.1 ************************

SELECT OrderID, ShippedDate, ShipVia FROM Orders WHERE ShippedDate >= '1998-05-06' AND ShipVia >= 2;

-- HELPERS QUERIES

--MAX(ShippedDate) in Orders = 1998-05-06
--SELECT MAX(ShippedDate) FROM Orders;

-- ******************** TASK # 2.1.2 ************************

SELECT OrderId, "ShippedDate" = CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' END FROM Orders WHERE ShippedDate IS NULL;

-- HELPERS QUERIES

--SELECT * FROM Orders WHERE ShippedDate IS NULL;
--SELECT COUNT(*) FROM Orders;

-- ******************** TASK # 2.1.3 ************************

SELECT "Order ID" = OrderID, 
	   "Shipped Date" = CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' END
FROM Orders WHERE ShippedDate > '1998-05-06' OR ShippedDate IS NULL;

-- ******************** TASK # 2.2.1 ************************

SELECT ContactName, Country FROM Customers WHERE Country IN ('USA', 'Canada') ORDER BY ContactName, Country;

-- ******************** TASK # 2.2.2 ************************

SELECT ContactName, Country FROM Customers WHERE Country NOT IN ('USA', 'Canada') ORDER BY ContactName;

-- ******************** TASK # 2.2.3 ************************

SELECT DISTINCT Country FROM Customers ORDER BY Country DESC;

-- ******************** TASK # 2.3.1 ************************

SELECT DISTINCT OrderID FROM [Order Details] WHERE Quantity BETWEEN 3 AND 10;

-- ******************** TASK # 2.3.2 ************************

SELECT CustomerID, Country FROM Customers WHERE Country BETWEEN 'B' AND 'H' ORDER BY Country;

-- ******************** TASK # 2.3.3 ************************

SELECT CustomerID, Country FROM Customers WHERE SUBSTRING(Country, 1, 1) IN ('B', 'C', 'D', 'E', 'F', 'G') ORDER BY Country;

-- ******************** TASK # 2.4.1 ************************

SELECT ProductID, ProductName FROM Products WHERE LOWER(ProductName) LIKE '%cho_olade%';
