use pubs
select * from authors
--projection-restriction on columns for display
select au_lname,au_fname from authors
--Giving alias name for columns for display
select au_fname First_Name, au_lname Last_Name from authors
--Selection-filter the rows
select * from authors where state ='CA'
select * from authors where state !='CA'
select * from employee where minit is null
select * from employee where minit is not null
select * from employee where job_id>10
select * from employee where job_id<10

select * from employee where job_id>10 and job_id<15
select * from employee where job_id between 10 and 15

select * from employee where job_id=11 or job_id=14 or job_id=6
select * from employee where job_id in(11,14,6)

select * from employee where job_id!=11 or job_id!=14 or job_id!=6--not the crt way for not in
select * from employee where job_id!=11 and job_id!=14 and job_id!=6
select * from employee where job_id not in(11,14,6)

select *from employee where fname='Maria'
select *from employee where fname !='Maria'
--first 3 char should be Mar then any number of char and any chars
select *from employee where fname like 'Mar%'
--first char can be anything(single char) the second char should be o and then any chars any number of chars
select *from employee where fname like '_o%'

select emp_id from employee where fname like '_o%'
select fname,lname from employee where job_id not in(11,14,6)
select * from employee where fname='Maria'
select * from employee where fname!='Maria'
 --first 3 char should be mar then any number of char and  any chars
 select * from employee where fname like 'Mar%'
 --first char can be anythin the second char should be o and then any char
 select * from employee where fname like '_o%'
 select emp_id from employee where fname like '_o%'

 select fname,lname from employee where job_id  not in(11,14,6)

 select * from titles
 --Unique values of a repeated data column
 select distinct pub_id from titles
 -- aggregate function sum(colname) aliaa_name from table name
select sum (advance) total from titles
select count (advance) count_number from titles
select min (advance) minimum from titles
select max (advance) maximum from titles
select avg (advance) average from titles

select count(*) number_count from titles where pub_id=0877

--group by

select pub_id,count(*) number_count from titles group by pub_id

--average advance for the titles published by every publisher

select pub_id, avg(advance) average from titles group by pub_id

select * from sales
-- print the sum of quantity for every title

select title_id,sum(qty) sum_quantity from sales group by title_id

--print the average royalty paid for titles of every type
 select type,avg(royalty) average_royalty from titles group by type

 --print the number of orders placed  in every store
 select stor_id,count(ord_num) order_placed from sales group by stor_id
 
 --print the number of orders placed  in every store where the number of orders >2
 select stor_id,count(ord_num) order_placed from sales group by stor_id having count(ord_num)>2

 --select the average royality for every type is the average is < 15
 select type,avg(royalty) average_royalty from titles group by type having avg(royalty)<15

 --Sorting
 --aesc order
 select * from authors order by au_lname
 select * from authors order by  state,city
 --desc order
  select * from authors order by city desc

--update authors set au_lname="Paul" where au_id="341-22-1782"

-- order- select, from, where, group by, having, order by
-- order- select, from, where,
-- order- select, from, group by, having, order by
-- order- select, from, where, group by, having
-- order- seleect, from order by


--Sub Query
select * from titles 
select * from sales
--Print the sales of the title' The Gourmet Microwave'
select * from sales where title_id='MC3021'
select title_id from titles where title='The Gourmet Microwave'
--instead
select * from sales where title_id=
(select title_id from titles where title='The Busy Executive''s Database Guide')
 
select * from publishers
--if the Subquery output Has many results then use 'in' instead of '=' because = is used for only one value
select * from sales where title_id in
(select title_id from titles where pub_id=
(select pub_id from publishers where pub_name='New Moon Books'))

select title_id, sum(qty) qty_sum from sales where title_id in
(select title_id from titles where pub_id=
(select pub_id from publishers where pub_name='New Moon Books'))
group by title_id
having sum(qty)<=25
order by sum(qty) desc--can also write order by qty_sum but for having it will show error because having is only for aggregates  

--print the title name and the sale quantity
--title name is in titles table and sale quantity is in sales table
--This can be done using joins
--Inner Join
--inner join will join only related data(ie. that both table have)
select title,qty from titles join sales 
on
titles.title_id=sales.title_id

--can also create instances like t for titles table
select title,qty from titles t join sales s
on
t.title_id=s.title_id

--print the title_id in the sales table
select title_id from sales
--print the uniue title_id in the sales table
select distinct title_id from sales
--Print the title_id in the titles table that are not in sales table
select title_id from titles where title_id not in(
select distinct title_id from sales)

--Join with the title id
select t.title_id,qty from titles t join sales s--both sales and title table have title_id. In order to select from which table we have to pick up the title_id we use t.title_id
on
t.title_id=s.title_id

--I want all the title_id and the title name, If it is sold i want the quantity as well
--left outer join-fetch all the records from the left table
--Even if it does not have a matching record in the right side table
select t.title_id,qty from titles t left outer join sales s
on
t.title_id=s.title_id

--print the publisher name and the title name
select pub_name,title from publishers p join titles t
on 
p.pub_id=t.pub_id

--print all the publisher's name if they have published a titlt the print the title name too
select pub_name,title from publishers p left outer join titles t
on 
p.pub_id=t.pub_id

--1. select the author firstname and lastname...
select au_fname,au_lname from authors 

--2. sort the titles by the title name in descending order and print all the details...
select * from titles order by title desc

--3. print the number of titles published by every author...
select a.au_fname,a.au_lname,count(t.title)num_of_titles from
(titleauthor ta join authors a on ta.au_id=a.au_id) 
join titles t on ta.title_id=t.title_id
group by a.au_fname,a.au_lname

--4. print the author name and title name...
select a.au_fname,a.au_lname,t.title from (authors a  join titleauthor  ta
on ta.au_id=a.au_id )join titles t on ta.title_id=t.title_id


--5. print the publisher name and the average advance for every publisher...
select pub_name,avg(advance) avg_of_advance from publishers p join titles t
on(p.pub_id=t.pub_id)
group by pub_name

--6. print the publisher name, author name, title name and the sale amount(qty*price)...
select p.pub_name,a.au_fname,a.au_lname,t.title,(s.qty*t.price) sale_amount from (((authors a  join titleauthor  ta
on ta.au_id=a.au_id)join titles t on ta.title_id=t.title_id)join sales s on t.title_id=s.title_id)join publishers p on p.pub_id=t.pub_id

--7. print the price of all that titles that have name that ends with s...
select price,title from titles where title like '%s'

--8. print the title names that contain and in it...
select title from titles where title like'%and%'

--9. print the employee name and the publisher name...
select fname,minit,lname,pub_name from employee e join publishers p
on (e.pub_id=p.pub_id)

--10. print the publisher name and number of employees woking in it if the publisher has more than 2 employees...select pub_name,count(emp_id) num_of_emp from employee e join publishers p on e.pub_id=p.pub_id group by pub_namehaving count(emp_id)>2--11 Print the author names who have published using the publisher name 'Algodata Infosystems'...select * from authorsselect * from publishersselect *from employeeselect * from titlesselect a.au_fname,a.au_lname,p.pub_name from((titleauthor ta join authors a on ta.au_id=a.au_id)join titles t on t.title_id=ta.title_id)join publishers p on t.pub_id=p.pub_idwhere p.pub_name='Algodata Infosystems'--12 Print the employees of the publisher 'Algodata Infosystems'...select fname,minit,lname,pub_name from employee e join publishers p
on p.pub_name='Algodata Infosystems'
