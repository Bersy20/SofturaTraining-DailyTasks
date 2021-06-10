--1. Write using Subquery
--Table Production.Product has a field called DaysToManufacture.
--Find the name of all products that are manufactured with the same numbers of DaysToManufacture of the product - 'Blade'

select Name,DaysToManufacture
from Production.Product
where DaysToManufacture=
(select DaysToManufacture from Production.Product where Name='Blade')

--2.Sub Query
--Table Production.Product has the field weight.
--Find the heaviest product using the weight column and group it using the ProductModelID.
--Find the name of the products in the combination of ANY, ALL and SOME

select ProductModelID,Name,Weight
from Production.Product
where Weight in
	(select MAX(Weight) from Production.Product 
	group by ProductModelID )
order by ProductModelID

--
select ProductModelID,Name,Weight
from Production.Product
where Weight >=All
	(select MAX(Weight) from Production.Product 
	group by ProductModelID )
order by ProductModelID

--3.Sub Query
--Use the following tables:
--Sales.SalesPerson, Sales.SalesTerritory, Person.Person
--FInd the FirstName, Lastname, Territory name, Region of the person doing maximum sales per territory
select * from Sales.SalesPerson
select * from Person.Person
select * from Sales.SalesTerritory

select FirstName,LastName,st.Name ,sp.SalesLastYear
from Sales.SalesPerson sp
join Sales.SalesTerritory st
on sp.TerritoryID=st.TerritoryID
join Person.Person p
on p.BusinessEntityID=sp.BusinessEntityID
where sp.SalesLastYear in
(select max(SalesLastYear) from Sales.SalesPerson group by TerritoryID)

--4. Correlated Subquery
--Use the following tables:
--HumanResources.Employee, Person.Person, Sales.SalesPerson

--inner table - sales.salesPerson.(select the appropriate outer table to do the join)
--Get the field SalesQuota
--Fetch FirstName, Lastname of the salesPerson who has achieved the SalesQuota of 25000

select * from HumanResources.Employee
select * from Person.Person
select * from Sales.SalesPerson


select per.LastName,per.FirstName
from Person.Person per
where 250000 in
	(select SalesQuota
	 from Sales.SalesPerson s
	 where per.BusinessEntityID=s.BusinessEntityID
	)

--5. Correlated Subquery
--SelfJoin using the table Sales.SalesOrderDetail
--Find the ProductID, OrderQty of the product whose UnitPrice is lessthan average UnitPrice

select sod1.ProductID,OrderQty,UnitPrice,AvgUnitPrice
from Sales.SalesOrderDetail sod1
join
(select ProductID,avg(UnitPrice) AvgUnitPrice
from Sales.SalesOrderDetail
group by ProductID) 
as tle
on sod1.ProductID=tle.ProductID
where UnitPrice<AvgUnitPrice
order by ProductID