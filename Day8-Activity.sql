create table employee(
	id int identity(100,1)	primary key,
	name varchar(50),
	age int check(age>18),
	phone int not null,
	gender varchar(20) check (gender in('Male','Female')));
sp_help employee
drop table employee
drop table EmployeeSalary
drop table Salary

create table Salary(
	id int identity(100,1)	primary key,
	Basic int,
	HRA int,
	DA int);
sp_help Salary

create table EmployeeSalary(
	transaction_number int primary key,
	Employee_id int references employee(id) ,
	Salary_id int references Salary(id) ,
	dates date,
    constraint un_key UNIQUE (Employee_id,Salary_id,dates)
	);
sp_help EmployeeSalary

alter table employee add Email varchar(50);

alter table employee 
alter column phone varchar(50);
alter table Salary 
add  deductions varchar(50);

insert into employee(name,age,phone,gender)values('Bersy',22,7598377137,'Female');
update employee set Email='bersy@gmail.com' where id=100
update employee set Email='gemsy@gmail.com' where id=101

insert into employee(name,age,phone,gender)values('Gemsy',25,9892449829,'Female');
insert into employee(name,age,phone,gender,Email)values('Pooja',22,2345677137,'Female','pooja@gmail.com');
insert into employee(name,age,phone,gender,Email)values('Arun',25,9845649829,'Male','arun@gmail.com');

select* from employee

insert into Salary(Basic,HRA,DA,deductions)values(12323,233,4241,124);
insert into Salary(Basic,HRA,DA,deductions)values(13123,433,4541,144);
insert into Salary(Basic,HRA,DA,deductions)values(33344,213,3341,344);
insert into Salary(Basic,HRA,DA,deductions)values(31323,333,4441,423);

select * from Salary

insert into EmployeeSalary(transaction_number,Employee_id,Salary_id,dates)
	values(1,101,102,'2020-04-02');
insert into EmployeeSalary(transaction_number,Employee_id,Salary_id,dates)
	values(2,102,103,'2019-02-11');
insert into EmployeeSalary(transaction_number,Employee_id,Salary_id,dates)
	values(3,101,102,'2010-05-22');
insert into EmployeeSalary(transaction_number,Employee_id,Salary_id,dates)
	values(4,100,101,'2021-06-12');
select * from EmployeeSalary

create proc proc_TotalSalary (@empid int,@dat date)
as
begin
	select es.Employee_id,es.dates,(s.Basic+s.HRA+s.DA-s.deductions) total_salary from EmployeeSalary es join  Salary s on s.id=es.Employee_id
	where es.Employee_id=@empid and es.dates=@dat
end
exec proc_TotalSalary 101,'2020-04-02'

create proc proc_AvgSalary(@eid int)
as
begin 
	select avg(s.Basic+s.HRA+s.DA-s.deductions) avg_salary from EmployeeSalary es join  Salary s on s.id=es.Employee_id
	--group by es.Employee_id
	where es.Employee_id=@eid
end
exec proc_AvgSalary 100

create proc proc_TaxPayable(@empid int,@tax float out)
as
begin
		declare
	    @total int,
		@taxPayable float
		set @total =(select sum(Basic+HRA+DA-deductions) from EmployeeSalary es join Salary s on es.Employee_id= s.id where es.Employee_id=@empid )
		if(@total=10000)
			set @tax=0
		else if(20000>@total and @total>10000)
			set @tax=5
		else if(35000>@total and @total>20000)
			set @tax=6
		else
			set @tax=7.5
		set @taxPayable=@total*@tax/100
		select concat('Total tax',@taxPayable)
end

drop proc proc_TaxPayable

declare
@myTax float
exec proc_TaxPayable 100, @myTax out
print @myTax

--Scalar function
create function fn_CalSal(@basic float,@hra float,@da float,@ded float)
returns float
as
begin
	declare
	@netSal float
	set @netSal = @basic+@hra+@da-@ded
	return @netSal
end

select basic,hra,da,deductions,dbo.fn_CalSal(basic,hra,da,deductions) 'Net Total' from Salary


---table valued function
create function fn_PrintCompleteSalDetails(@empid int)
returns @EmpSalTax Table
(
Ename varchar(15),
TotalSal float,
Tax float
)
as
begin
declare
   @total float,
   @taxPayable float,
   @tax float,
   @ename varchar(15)
   set @total=(select sum(basic+HRA+DA-deductions) from Salary where id in
   (select id from EmployeeSalary where id=@empid))
   if(@total<100000)
      set @tax=0
   else if(@total>100000 and @total<200000)
      set @tax=5
   else if(@total>200000 and @total<350000)
      set @tax=6
   else
      set @tax=7.5
  set @taxPayable=@total*@tax/100
  set @ename = (select name from employee where id=@empid)
  insert into @EmpSalTax values(@Ename, @total,@taxPayable)
  return
end


drop function fn_PrintCompleteSalDetails

select * from dbo.fn_PrintCompleteSalDetails(100)

--trigger
create table EmployeeNetSal
(transaction_id int,
netSal float
)

create table btblDummy
(f1 int,
f2 varchar(20))

create trigger trgInsertDummy
on btblDummy
after Insert
as
begin
	select 'Hellooo'
end

select * from btblDummy

drop trigger trgInsertDummy
 
insert into btblDummy values(1,'Ramu')

create trigger trgInsertDummy
on btblDummy
after Insert
as
begin
	select concat('Hello there!!',f2) from inserted
end

select * from EmployeeNetSal
select* from Salary
select* from EmployeeSalary
select* from employee
 
create trigger trg_InsertNetSal
on EmployeeSalary
after insert
as
begin
	declare
	@totalSal float
	set @totalSal= (select dbo.fn_CalSal(basic,hra,da,deductions) from Salary where id=(select Salary_id from inserted))
	insert into EmployeeNetSal values((select transaction_number from inserted),@totalSal)

end
insert into EmployeeSalary values(5,101,102,'2018-04-02')

--create a trigger for the employee table which prints the welcome message to the employee
--example
--Welcome Mr.Ramu
 create trigger trg_PrintWelcome
 on employee
 after insert
 as
 begin
		if((select gender from inserted)='male')
			select concat('Welcome Mr. ',name) from inserted
		else
			select concat('Welcome Miss. ',name) from inserted
	
 end
insert into employee(name,age,phone,gender,Email)values('Ramu',25,9845649829,'Male','ramu@gmail.com');
insert into employee(name,age,phone,gender,Email)values('Kavya',55,98456324829,'Female','kavya@gmail.com');

 drop trigger trg_PrintWelcome


 --transaction
 select * from employee
 select * from EmployeeSalary

 
 insert into employee(name,age,phone,gender,Email)values('Somu',25,9845649829,'Male','somu@gmail.com');
 insert into EmployeeSalary values(6,104,103,'2007-11-01')
 
 --does all or does not do it at all
 begin transaction
 insert into employee(name,age,phone,gender,Email)values('Domu',25,9845649829,'Male','somu@gmail.com');
 insert into EmployeeSalary values(6,104,103,'2007-11-01')
  if((select max(transaction_number) from EmployeeSalary)=110)
	commit
  else
	rollback--all dml queries from begin transaction

--CURSORS
select * from employee
select * from Salary
select * from EmployeeSalary
--cursor
--declare, open, fetch, close, deallocate
declare @eid int,@ename varchar(15)
declare cur_employee cursor for
Select id,name from employee
open cur_employee
fetch next from cur_employee
into @eid,@ename
print 'Employee Data'
while @@FETCH_STATUS=0
begin
	print 'Employee Id : '+Cast(+@eid as varchar(10))
	print 'Employee Name : '+@ename
	print '----------------------------'
	fetch next from cur_employee
	into @eid,@ename
end
close cur_employee
deallocate cur_employee


--for every customer
--Print customer Name
--the salary details for every date


declare @eid int,@ename varchar(15)
declare cur_employee cursor for
select id,name from employee
open cur_employee
fetch next from cur_employee 
into @eid,@ename
print 'Employee Data'
while @@FETCH_STATUS =0
begin
  print 'Employee Id : '+Cast(@eid as varchar(10))
  print 'Employee Name : '+@ename
  print '-----------------------------'
  declare
  @sid int,@date date,@Total float
  declare cur_empSal cursor for
  select salary_id,dates from EmployeeSalary where employee_id = @eid
  open cur_empSal
  fetch next from cur_empSal into @sid,@date
  print '##############################'
  print 'Salary Details'
  while @@FETCH_STATUS =0
  begin
      set @Total = (select basic+hra+da-deductions from Salary where id = @sid)
	  print 'Date : '+Cast(@date as varchar(20))
	  print 'Net Salary : '+Cast(@Total as varchar(20))
	  fetch next from cur_empSal into @sid,@date
  end
  print '##############################'
  close cur_empSal
  deallocate cur_empSal
  fetch next from cur_employee 
  into @eid,@ename
end
close cur_employee
deallocate cur_employee


