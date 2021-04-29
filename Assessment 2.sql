--1.Print the name and the count of the authors from every city
select au_fname,au_lname,city,count(au_id) numOfAuthors from authors group by city,au_fname,au_lname

--2. print the authors who are not from the city in which the publisher " New Moon Books" is from
select a.au_fname,a.au_lname,t.title from authors a join titleauthor ta on a.au_id=ta.au_id join titles t on t.title_id=ta.title_id where a.city not in (select a.city where t.title='New Moon Books')

--3.create a sp that will take the author fname and lname and new price. The sp should update the price of books written by the author with the given name
create proc proc_authorNameAndPrice(@au_fname varchar(30),@au_lname varchar(20),@new_price int)
as
begin
	update t set t.price=@new_price from authors a join titleauthor ta on ta.au_id=a.au_id join titles t on  t.title_id=ta.title_id where a.au_fname=@au_fname and a.au_lname=@au_lname
	select a.au_fname,a.au_lname,t.price from authors a join titleauthor ta on ta.au_id=a.au_id join titles t on  t.title_id=ta.title_id where a.au_fname=@au_fname and a.au_lname=@au_lname
end
exec proc_authorNameAndPrice 'Anne','Ringer',1111
drop proc proc_authorNameAndPrice

--4. create function to calculate tax
create function fn_calculateTax(@titleid varchar(20))
returns float
as
begin
declare
   @qty int,
   @total float,
   @price float,
   @taxPayable float,
   @tax float

   set @qty=(select top 1 qty from sales where title_id in (@titleid))
   set @price=(select top 1 price from titles where title_id in (@titleid) )
   set @total=@price*@qty
   if(@qty<10)
      set @tax=2
   else if(@qty>10 and @qty<20)
      set @tax=5
   else if(@qty>20 and @qty<50)
      set @tax=6
   else
      set @tax=7.5
  set @taxPayable=@total*@tax/100
  return @taxPayable
end

drop function fn_calculateTax
select s.qty,t.title_id,t.title,dbo.fn_calculateTax(t.title_id) 'Tax to be paid ' from titles t join sales s on t.title_id=s.title_id

select * from titles
select * from sales
