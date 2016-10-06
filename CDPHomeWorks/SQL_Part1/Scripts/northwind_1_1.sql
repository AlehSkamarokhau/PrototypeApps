USE "Northwind"
GO

if exists (select * from sysobjects where id = object_id('dbo.CreditCards') and sysstat & 0xf = 3)
	drop table "dbo"."CreditCards"
GO

CREATE TABLE "CreditCards" (
	"CreditCardID" INT IDENTITY(1, 1) NOT NULL,
	"CardNumber" NVARCHAR(20) NOT NULL,
	"ExpirationDate" DATETIME NOT NULL,
	"CardHolderName" NVARCHAR(31) NOT NULL,
	"EmployeeID" INT NOT NULL,
	CONSTRAINT "PK_CreditCards" PRIMARY KEY CLUSTERED 
	(
		"CreditCardID"
	),
	CONSTRAINT "FK_CreditCards_Employees" FOREIGN KEY 
	(
		"EmployeeID"
	) REFERENCES "dbo"."Employees" (
		"EmployeeID"
	),
)
GO

CREATE INDEX "CardHolderName" ON "dbo"."CreditCards"("CardHolderName")
GO
