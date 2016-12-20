SELECT Product.Name, ProductSubcategory.Name, ProductCategory.Name FROM Production.Product 
	INNER JOIN Production.ProductSubcategory
	ON Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID
	INNER JOIN Production.ProductCategory
	ON ProductSubcategory.ProductSubcategoryID = ProductCategory.ProductCategoryID;

SELECT * FROM Sales.CreditCard;