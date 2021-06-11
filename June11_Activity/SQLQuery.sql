create database BooksDB

use BooksDB

--Books-BookID,Title,AuthorID,Price
--Author-AuthorID,AuthorName

create table tbl_author(
AuthorID int identity(1,1),
AuthorName varchar(20),
constraint pk_auth Primary Key (AuthorID))

--drop table tbl_author

create table tbl_Books
(
BookId int identity(1000,1),
Title varchar(50),
AuthorID int,
Price money,
constraint pk_book Primary key (BookId),
constraint fk_auth Foreign key(AuthorId) 
references tbl_Author(AuthorID)
)


--TASK 2

--Insert book
go
create proc sp_InsertBook
@Title varchar(20),
@AuthorID int,
@Price money
as
Begin
insert into tbl_Books(Title,AuthorID,Price)
values(@Title,@AuthorID,@Price)
End

exec sp_InsertBook 'Angels & Demons',7,550

--Update Book
go
create proc sp_UpdateBook
@BookID int,
@Price money
as
Begin
update tbl_Books set Price=@Price where BookId=@BookID
End

exec  sp_UpdateBook 1000,500

--Delete Book

go
create proc sp_DeleteBook
@BookID int
as
Begin
delete from tbl_Books where BookId=@BookID
End

exec  sp_DeleteBook 1009

--Insert Author

go
create proc sp_InsertAuthor
@AuthorName varchar(20)
as
Begin
insert into tbl_author(AuthorName)
values(@AuthorName)
End

exec sp_InsertAuthor 'Charles Dickens'

--Update Author
go
create proc sp_UpdateAuthor
@AuthorID int,
@AuthorName varchar(20)
as
Begin
update tbl_author set AuthorName=@AuthorName where AuthorID=@AuthorID
End

exec  sp_UpdateAuthor 10,'Ruskin Bond'

--Delete Author

go
create proc sp_DeleteAuthor
@AuthorID int
as
Begin
delete from tbl_author where AuthorID=@AuthorID
End

exec  sp_DeleteAuthor 10

--
select * from tbl_author
select * from tbl_Books