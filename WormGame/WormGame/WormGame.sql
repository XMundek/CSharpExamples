use WormGame
drop table GameResults
go
create table GameResults(
	Id int not null primary key identity(1,1),
	Player varchar(100) not null,
	Score int not null,
	DT datetime not null
)
select * from GameResults
insert GameResults(Player,Score, DT) values('Jasio', 20,GETDATE())
insert GameResults(Player,Score,DT) values('Zdzisio', 30,GETDATE())
delete GameResults where id =1

update GameResults
	set Score = Score+1,
		DT = GETDATE()
	where id = 2
		
begin tran
select Id,Player,Score,DT from GameResults where Player like 'a' delete GameResults where id>4 select * from GameResults where Player like 'a%' order by Score desc
select * from GameResults
rollback
select * from GameResults