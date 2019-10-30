




select * from users
--Users Table
CREATE TABLE Users (
	id int IDENTITY(1,1) PRIMARY KEY,
    userName varchar(255),
	firstName varchar(255),
	surname varchar(255),
	province varchar(255),
	city varchar(255),
	branch varchar(255),
	department varchar(255),
	employeeCode varchar(255),
	jobTitle varchar(255), 
	emailAdd varchar(255),
	phoneNo varchar(255),
	manager varchar(255),
	roles varchar(100),
	active int
);



--Users
insert into users  values('mparak','Mohammed','Parak','Gauteng','JHB','ParkTown','IT Insure','10111','Software Developer','MohammedP@hollard.co.za','27817439703','Iqbal Ibrahim','user',1)
insert into users  values('ThabangMat','Thabang','Matshete','Gauteng','JHB','ParkTown','IT Insure','10125','Software Developer','ThabangMat@hollard.co.za','27825740954','Iqbal Ibrahim','user',1)
insert into users  values('Kakoo','Kairoon','Akoo','Gauteng','JHB','ParkTown','IT Insure','10456','Claim Negociator','KairoonA@hollard.co.za','27822770786','Farouk','user',1)
insert into users  values('Fbhabha','Farouk','Bhabha','Gauteng','JHB','ParkTown','IT Insure','10456','Claim Negociator','Fbhabha@hollard.co.za','27822770785','Thula','user',0)

--
select * from Nominations

sp_helptext EKUNDU_LIB_RatingSectionType




