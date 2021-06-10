select * from Posts

------creating view and updating table and view----------
create View vw_Cat
as
select Category 
from Posts 

select * from vw_Cat

insert into Posts values('Hello','Hello')
insert into vw_Cat values('Hello1')

--------Stored Procedure for insert, update and delete---------
create proc proc_Insert(@postText varchar(50),@Category varchar(10)) 
as
begin
	insert into Posts values(@postText,@Category);	
end
exec proc_Insert 'Text','Category'
--------------------

create proc proc_Update(@postText varchar(50),@Id int) 
as
begin
	update Posts 
	set PostText=@postText
	where Id=@Id
end
exec proc_Update 'Post',4 
drop procedure proc_Update
--------------------

create proc proc_Delete(@Id int) 
as
begin
	Delete from Posts where Id=@Id
end
exec proc_Delete 3
--------------------

create function con_INR(@amount money)
returns money
as
begin
return @amount*72
end

select dbo.con_INR(100)
---------------------

create function func_age()
returns date
as
begin
return GETDATE()
end
select dbo.func_age(1999-04-20)

drop function func_age

--age calculation
select DATEDIFF(year,'1999/04/20',GETDATE())
---------------------------------------------------
--returns number of days
select DATEDIFF(day,'2021/04/07',GETDATE())
select DATEDIFF(DY,'2021/04/07',GETDATE())
select DATEDIFF(y,'2021/04/07',GETDATE())

---------replace function
select REPLACE('TN','TN','TamilNadu')

-------------------------list of all procedures
select * from sys.procedures
---returns all objects
select * from sys.objects
where type='FN'---it displays functions

-------count------
select COUNT(PostText) count from Posts where PostText='Text' 

------sum-----------
select sum(id) from Posts where PostText='Text'

------dateadd------------
select Dateadd(YEAR,2,'2021/04/07') as dateAdd
select Dateadd(MONTH,2,'2021/04/07') as dateAdd
select Dateadd(day,34,'2021/04/07') as dateAdd

-------convert--------
select CONVERT(varchar,25.56)
select CONVERT(int,25.56)
select CONVERT(datetime,'2021/04/07')

-----------left---------
select left('Bersy',3)

------------len----------
select len('BersySB')

-------------reverse---------
select REVERSE('Bersy')



create function add_symbol(@amount money)
returns money
as
begin
return  @amount
end

select concat('Rs. ',dbo.add_symbol(100))
drop function add_symbol
