--1.Display firstname,lastname from person.person whose title is not null.
select FirstName,LastName,Title
from Person.Person 
where Title is not null

--2.Display Firstname,lastname from person.person whose firstname and lastname should have atleast one 'a'.
select FirstName,LastName
from Person.Person 
where FirstName like '%a%' and LastName like '%a%'

--3.Display currencycode,name from Sales.Currency and Sales.CountryRegionCurrency without using joins
select * from Sales.Currency
select * from Sales.CountryRegionCurrency

select Coun.CurrencyCode,Name
from Sales.Currency curr,Sales.CountryRegionCurrency Coun
Where Coun.CurrencyCode=curr.CurrencyCode

--4.Copy humanresources.department table to the new table named as 'HR.Dept'
select * into HumanResources.Dept from HumanResources.Department

select * from HumanResources.Department
select * from HumanResources.Dept

--5.Create a table with column named 'SNo' and make that column as identity.insert 20 rows using insert
----into statement(table should contain 5 columns)
create table StudentInfo(
Sno int Identity(1,1),
FirstName varchar(20),
LastName varchar(20),
City varchar(10),
Phone varchar(10)
);
select * from StudentInfo

insert into StudentInfo values ('Bersy','SB','Hosur','7598377137'),
('Gemsy','SB','Hosur','9487794155'),('Priya','K','Chennai','8922345691'),
('kala','SB','Hosur','7598377137'),('Lakshmi','SB','Hosur','7598377137'),
('Ravi','SB','Hosur','9487794155'),('Dheena','K','Chennai','8922345691'),
('Ramu','SB','Hosur','7598377137'),('Varsha','SB','Hosur','7598377137'),
('Somu','SB','Hosur','9487794155'),('Yakshan','K','Chennai','8922345691'),
('Lilly','SB','Hosur','7598377137'),('Giri','SB','Hosur','7598377137'),
('Bruna','SB','Hosur','9487794155'),('Vasu','K','Chennai','8922345691'),
('Hema','SB','Hosur','7598377137'),('Ganga','SB','Hosur','7598377137'),
('Kiran','SB','Hosur','9487794155'),('Ramesh','K','Chennai','8922345691'),
('Kishore','SB','Hosur','7598377137')

--6.Perform inner join operation to display businessentityid,addresstypeid from humanresources.department 
---and Person.BusinessEntityAddress
select * from HumanResources.Department
select * from HumanResources.EmployeeDepartmentHistory
Select * from Person.BusinessEntityAddress

select bea.BusinessEntityID,bea.AddressTypeID 
from HumanResources.EmployeeDepartmentHistory dept 
inner join Person.BusinessEntityAddress bea
on dept.BusinessEntityID=bea.BusinessEntityID

--7.Display distinct values of column named 'Group name' from humanresources.department
select * from HumanResources.Department
select distinct GroupName from HumanResources.Department

--8.Display documentnode,StandardCost,sum of ListPrice & StandardCost from Production.ProductCostHistory and Production.Product
select * from Production.ProductCostHistory
Select * from Production.Product

select p.ProductID,p.StandardCost,p.ListPrice+p.StandardCost SumOfListPriceAndStandardCost 
from Production.ProductCostHistory pch
join Production.Product p
on pch.ProductID=p.ProductID

--9.Use Datediff() fumction to find 'Years on role' using Startdate and enddate from HumanResources.EmployeeDepartmentHistory
select BusinessEntityID,StartDate,EndDate,DATEDIFF(year,StartDate,
coalesce(EndDate,GetDate())) YearsOnRole  from HumanResources.EmployeeDepartmentHistory

--10.Filter the data from Sales.SalesPersonQuotaHistory whose sum of '5000 and SalesQuota' is greater than 100000. 
---Arrange in ascending order with respect to the sum of salesquota and 5000

select *,SalesQuota+5000 sumOfSalesQuotaAnd5000 from Sales.SalesPersonQuotaHistory
where SalesQuota+5000>100000
order by sumOfSalesQuotaAnd5000

--11.find the maximum taxrate as Max_taxrate from sales.salestaxrate
select MAX(TaxRate) MaximumTaxRate from Sales.SalesTaxRate

--12.Perform Join Operation and display DepartmentID,BusinessentityId,ShiftId,BirthDate.Find Age and display.(use getdate() function).
----Note: Use HumanResources.Employee,HumanResources.Department,HumanResources.EmployeeDepartmentHistory.
select * from HumanResources.Department
select * from HumanResources.EmployeeDepartmentHistory
select * from HumanResources.Employee

select dept.DepartmentID,emp.BusinessEntityID,deptHistory.ShiftID,emp.BirthDate,DATEDIFF(YEAR,emp.BirthDate,GetDate()) Age 
from HumanResources.Department dept 
join HumanResources.EmployeeDepartmentHistory deptHistory
on dept.DepartmentID=deptHistory.DepartmentID
join HumanResources.Employee emp
on deptHistory.BusinessEntityID=emp.BusinessEntityID
order by dept.DepartmentID

--13.Create view named 'Name_age' for Task-12
 
create View Name_age 
as
select dept.DepartmentID,emp.BusinessEntityID,deptHistory.ShiftID,emp.BirthDate,DATEDIFF(YEAR,emp.BirthDate,GetDate()) Age 
from HumanResources.Department dept 
join HumanResources.EmployeeDepartmentHistory deptHistory
on dept.DepartmentID=deptHistory.DepartmentID
join HumanResources.Employee emp
on deptHistory.BusinessEntityID=emp.BusinessEntityID

select * from Name_age

--14.Find the total number of rows in the tables starting with schema name 'humanresources'.Display result as No_of_rows_hr
 
SELECT
SUM(dmv.row_count) AS No_of_rows_hr
FROM sys.objects AS obj
  INNER JOIN sys.dm_db_partition_stats AS dmv
  ON obj.object_id = dmv.object_id
WHERE obj.type = 'U'
  AND obj.is_ms_shipped = 0x0
  AND dmv.index_id in (0, 1)
  And schema_id=5


--15.Display maximum rate for each department

select max(pay.Rate) MaxRateInEachDept,his.DepartmentID from HumanResources.EmployeePayHistory pay
join HumanResources.EmployeeDepartmentHistory his
on his.BusinessEntityID=pay.BusinessEntityID
group by his.DepartmentID

select * from HumanResources.EmployeePayHistory
select * from HumanResources.EmployeeDepartmentHistory order by DepartmentID

--16.perform Left join between person.person and person.BusinessEntityAddress and display FirstName,
-----MiddleName,Title,AddressTypeID,businessentityID.Don't display the names whose title is null

select p.FirstName,p.MiddleName,p.Title,bea.AddressTypeID,p.BusinessEntityID 
from Person.Person p
left join Person.BusinessEntityAddress bea
on p.BusinessEntityID=bea.BusinessEntityID
where Title is not null

--17.Display ProductID,LocationID,Shelf from Production.ProductInventory whose ProductID should be between 300-350,
----LocationID should be 50 or Shelf = 'E'

select ProductID,LocationID,Shelf 
from Production.ProductInventory
where ProductID between 300 and 350 and LocationID=50 or Shelf='E'

--18.Display LocationID,Shelf,Name by joining Production.ProductInventory and Production.Location
 
 select p.LocationID,Shelf,Name
 from Production.ProductInventory p
 join Production.Location l
 on p.LocationID=l.LocationID


 --19.Display AddressID,AddressLine1,AddressLine2,StateProvinceID,StateProvinceCode,CountryRegionCode 
 ---from Person.StateProvince and Person.Address
 
 select AddressID,AddressLine1,AddressLine2,a.StateProvinceID,StateProvinceCode,CountryRegionCode
 from Person.StateProvince sp
 join Person.Address a
 on a.StateProvinceID=sp.StateProvinceID

 --20.Display currency code,sum of subtotal and TaxAmt as total using Sales.SalesOrderHeader,
 ----Sales.SalesTerritory and Sales.CountryRegionCurrency

 select CurrencyCode,(SubTotal+TaxAmt) SumOfSubTotalAndTaxAmt
 from Sales.SalesOrderHeader soh
 join Sales.SalesTerritory st
 on soh.TerritoryID=st.TerritoryID
 join Sales.CountryRegionCurrency crc
 on crc.CountryRegionCode=st.CountryRegionCode
