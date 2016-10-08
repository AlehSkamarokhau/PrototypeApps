USE Northwind;
GO

-- ******************** TASK # 2.1.1 ************************

--SELECT OrderID, ShippedDate, ShipVia FROM Orders WHERE ShippedDate >= '1998-05-06' AND ShipVia >= 2;

-- HELPERS QUERIES

--MAX(ShippedDate) in Orders = 1998-05-06
--SELECT MAX(ShippedDate) FROM Orders;

-- ******************** TASK # 2.1.2 ************************

--SELECT OrderId, "ShippedDate" = CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' END FROM Orders WHERE ShippedDate IS NULL;

-- HELPERS QUERIES

--SELECT * FROM Orders WHERE ShippedDate IS NULL;
--SELECT COUNT(*) FROM Orders;

-- ******************** TASK # 2.1.3 ************************

--SELECT "Order ID" = OrderID, 
--	   "Shipped Date" = CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' END
--FROM Orders WHERE ShippedDate > '1998-05-06' OR ShippedDate IS NULL;

-- ******************** TASK # 2.2.1 ************************

--SELECT ContactName, Country FROM Customers WHERE Country IN ('USA', 'Canada') ORDER BY ContactName, Country;

-- ******************** TASK # 2.2.2 ************************

--SELECT ContactName, Country FROM Customers WHERE Country NOT IN ('USA', 'Canada') ORDER BY ContactName;

-- ******************** TASK # 2.2.3 ************************

--SELECT DISTINCT Country FROM Customers ORDER BY Country DESC;



