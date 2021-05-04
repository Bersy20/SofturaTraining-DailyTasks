--1
create proc proc_PrintAuthorNameWithTitle(@fname varchar(10),@lname varchar(10))
as
begin
	select a.au_fname,a.au_lname,t.title from authors a join titleauthor ta on ta.au_id=a.au_id join titles t on t.title_id=ta.title_id 
	where a.au_fname=@fname and a.au_lname =@lname
end
drop proc proc_PrintAuthorNameWithTitle
exec proc_PrintAuthorNameWithTitle 'Ann', 'Dull'

select * from authors

--2
select a.au_fname,a.au_lname,p.pub_name,t.price from authors a join titleauthor ta on ta.au_id=a.au_id join titles t on t.title_id=ta.title_id join publishers p on p.pub_id=t.pub_id

--3
declare @pubname varchar(50),@titles varchar(50)
declare cur_pub cursor for
Select p.pub_name,t.title from titles t join publishers p on p.pub_id=t.pub_id
open cur_pub
fetch next from cur_pub
into @pubname,@titles
print 'Publisher and the Titles published '
while @@FETCH_STATUS=0
begin
	print 'Publisher Name: '+@pubname
	print 'Title : '+@titles
	print '----------------------------'
	declare @aufname varchar(50),@aulname varchar(50),@qty int,@dateofsale date
	declare cur_title cursor for
	select a.au_fname,a.au_lname,s.qty,s.ord_date from authors a join titleauthor ta on ta.au_id=a.au_id join titles t on t.title_id=ta.title_id 
		join sales s on t.title_id=s.title_id where t.title=@titles
	open cur_title
	fetch next from cur_title 
	into @aufname,@aulname,@qty,@dateofsale
	print 'Details Of Title'
	while @@FETCH_STATUS=0
	begin
	
		print 'Author First Name: '+@aufname
		print 'Authors Last Name: '+@aulname
		print 'Quantity: '+Cast(+@qty as varchar(10))
		print 'Date Of Sale: '+cast(+@dateofsale as varchar(20))
		print '************************************'
		fetch next from cur_title 
		into @aufname,@aulname,@qty,@dateofsale	end
	print '//////////////////////////////////////////////'
	close cur_title
	deallocate cur_title
	fetch next from cur_pub
	into @pubname,@titles	
end
close cur_pub
deallocate cur_pub

select * from authors
select * from titles
select * from titleauthor
select * from sales

--4
create table account
(
	acc_num varchar(30) primary key,
	acc_name varchar(40),
	acc_bal int,
	status varchar(10) check (status in('open','blocked')) default 'blocked');
drop table account

create table transacDetails
(
	tran_id int,
	from_acc varchar(30) references account(acc_num),
	to_acc varchar(30) references account(acc_num),
	amount int,
	remarks varchar(200));
drop table transacDetails

insert into account values('a1','Bersy',10000,'open');
insert into account values('a2','Gemsy',2000,'blocked');
insert into account values('a3','Arun',12300,'open');
insert into account values('a4','Ramu',67000,'open');
insert into account values('a5','Kavi',3040,'open');

begin transaction
insert into transacDetails values(100,'a1','a2',200,'Done')
update account set acc_bal = acc_bal-200 where acc_num='a1'
update account set acc_bal = acc_bal+200 where acc_num='a2'
if(select acc_bal from account where acc_num='a1')<1500
	rollback
else
	commit

begin transaction
insert into transacDetails values(101,'a2','a3',200,'Done')
update account set acc_bal = acc_bal-200 where acc_num='a2'
update account set acc_bal = acc_bal+200 where acc_num='a3'
if(select acc_bal from account where acc_num='a2')<1500
	rollback
else
	commit

select * from account
select * from transacDetails

--5
create trigger trg_updateTransac
on transacDetails
after update
as
begin
	if(select remarks from inserted)='void'
	begin
	update account set acc_bal =acc_bal+(select amount from transacDetails where tran_id=(select tran_id from inserted))
		where acc_num=(select from_acc from transacDetails where tran_id=(select tran_id from inserted))
	update account set acc_bal =acc_bal-(select amount from transacDetails where tran_id=(select tran_id from inserted))
		where acc_num=(select from_acc from transacDetails where tran_id=(select tran_id from inserted))
	end
end

update transacDetails set remarks='void' where tran_id=101 
