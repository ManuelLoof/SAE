USE [AdventureWorks2014]

-- Ein einfaches Select 
SELECT * FROM Person.Person;

SELECT Person.FirstName, Person.LastName FROM Person.Person;

SELECT Person.FirstName, Person.LastName FROM Person.Person
	WHERE Person.FirstName like 'F%';

SELECT top 10 * 
	FROM Sales.SalesOrderHeader 
	Order by Sales.SalesOrderHeader.SubTotal desc;

SELECT TOP 10 Person.FirstName, Person.LastName, Sales.SalesOrderHeader.SubTotal
	FROM Person.Person
	INNER JOIN Sales.Customer
	ON Person.Person.BusinessEntityID = Sales.Customer.PersonID
	INNER JOIN Sales.SalesOrderHeader
	ON Sales.Customer.CustomerID = Sales.SalesOrderHeader.CustomerID
	order by Sales.SalesOrderHeader.SubTotal desc;