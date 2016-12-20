USE [AdventureWorks2014]

--https://moidulhassan.files.wordpress.com/2014/07/adventureworks2008_schema.gif
--http://www.w3schools.com/sql/

--Meine Fragen:

-- Angestellten:

--- Liste bitte die Namen aller Mitarbeiter auf.
SELECT LastName, FirstName FROM HumanResources.Employee 
	INNER JOIN Person.Person
	ON HumanResources.Employee.BusinessEntityID = Person.Person.BusinessEntityID;




--- Erstell eine Liste aller JobTitle. Bitte filter die Dubletten heraus.
SELECT DISTINCT JobTitle FROM [HumanResources].[Employee];


--* Erstell Abfrage eine welche angibt, wie viele Mitarbeiten in welchem Department arbeiten.
SELECT HumanResources.Department.Name, Count([HumanResources].[EmployeeDepartmentHistory].DepartmentID) as HumanCount FROM [HumanResources].[Department]
	INNER JOIN [HumanResources].[EmployeeDepartmentHistory]
	ON [HumanResources].[Department].DepartmentID = [HumanResources].[EmployeeDepartmentHistory].DepartmentID
	GROUP BY HumanResources.Department.Name;



Select [HumanResources].[EmployeeDepartmentHistory].DepartmentID as DID,
 Count([HumanResources].[EmployeeDepartmentHistory].DepartmentID) as HumanCount 
 from [HumanResources].[EmployeeDepartmentHistory]
	GROUP BY [HumanResources].[EmployeeDepartmentHistory].DepartmentID




--Production:

--Darauf eingehen was man alles in eine Datenbank ablegen kann. Macht es Sinn Bilder oder so abzulegen?

--- In welchen Farben gibt es unsere Produkte?
SELECT DISTINCT Production.Product.Color FROM Production.Product; 

--- Erstell eine Liste aller Produktname und ihrem Preis, sortiert nach dem Preis. Absteigend.
SELECT Name FROM Production.Product ORDER BY Production.Product.ListPrice desc;


--Sales:

--- Wie viel Umsatz haben wir gemacht?
SELECT SUM(Sales.SalesOrderHeader.SubTotal) as Umsatz FROM Sales.SalesOrderHeader;

--- Wie viel Umsatz haben wir in diesem Jahr gemacht?
SELECT SUM(Sales.SalesOrderHeader.SubTotal) as Umsatz FROM Sales.SalesOrderHeader
	WHERE Sales.SalesOrderHeader.OrderDate > '01.01.2014' ;
	
SELECT * FROM Sales.SalesOrderHeader ORDER BY Sales.SalesOrderHeader.OrderDate desc;


--* Welches Produkt hat den meisten Umsatz gebracht?
SELECT Production.Product.Name FROM [Production].[Product]
	WHERE Production.Product.ProductID IN
	(
		SELECT TOP 1 Sales.SalesOrderDetail.ProductID FROM Sales.SalesOrderDetail
			GROUP BY Sales.SalesOrderDetail.ProductID
			ORDER BY SUM(Sales.SalesOrderDetail.UnitPrice) DESC
	)

--* Welcher Mitarbeiter hat den meisten Bonus erwirtschaftet?
SELECT PERSON.PERSON.LastName from PERSON.PERSON
	where PERSON.PERSON.BusinessEntityID in
	(
		SELECT Top 10 Sales.SalesOrderHeader.SalesPersonID FROM Sales.SalesOrderHeader
			GROUP BY Sales.SalesOrderHeader.SalesPersonID
			ORDER BY SUM(Sales.SalesOrderHeader.SubTotal) desc
	)



--* Welcher Kunde hat den meisten Umsatz erwirtschaftet.


--* Welcher Kunde hat mit eine unterschiedliche Lieferadresse angegeben.

--(Das ganze noch in einem bestimmten Zeitraum.)

