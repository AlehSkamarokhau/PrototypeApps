USE Northwind;
GO

-- ******************** TASK # 2.1.1 ************************

--SELECT OrderID, ShippedDate, ShipVia FROM Orders WHERE ShippedDate > '1998-05-06' AND ShipVia >= 2;

-- HELPERS QUERIES

--MAX(ShippedDate) in Orders = 1998-05-06
--SELECT MAX(ShippedDate) FROM Orders;

-- ******************** TASK # 2.1.2 ************************

--SELECT OrderId, "ShippedDate" = CASE WHEN ShippedDate IS NULL THEN 'Not Shipped' END FROM Orders WHERE ShippedDate IS NULL;

-- HELPERS QUERIES

--SELECT * FROM Orders WHERE ShippedDate IS NULL;
--SELECT COUNT(*) FROM Orders;
