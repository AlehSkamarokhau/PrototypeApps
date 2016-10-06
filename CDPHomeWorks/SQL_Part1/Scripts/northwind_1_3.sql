USE "Northwind"
GO

IF NOT EXISTS(select * from sysobjects where id = object_id('dbo.Regions') and sysstat & 0xf = 3)
	EXEC sp_rename 'Region', 'Regions';
GO

IF EXISTS(SELECT *
		  FROM sys.columns 
		  WHERE Name = N'FoundedDate'
		  AND Object_ID = Object_ID(N'dbo.Customers'))
	
	ALTER TABLE dbo.Customers DROP COLUMN FoundedDate;

GO

ALTER TABLE dbo.Customers ADD FoundedDate DATETIME NULL;
GO
