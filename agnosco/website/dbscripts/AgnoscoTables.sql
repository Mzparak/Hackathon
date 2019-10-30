
--Users Table
CREATE TABLE Users (
	id int IDENTITY(1,1) PRIMARY KEY,
    userName varchar(255),
	firstName varchar(255),
	surname varchar(255),
	age varchar(255),
	dateOfBirth date,
	province varchar(255),
	city varchar(255),
	branch varchar(255),
	department varchar(255),
	employeeCode varchar(255),
	jobTitle varchar(255), 
	emailAdd varchar(255),
	phoneNo varchar(255),
	manager varchar(255),
);
--Nominations table

CREATE TABLE Nominations (
	id int IDENTITY(1,1) PRIMARY KEY,
    nominaterId int,
	nomineeId int,
	nominationDetails nvarchar(max),
	point int
	)
CREATE TABLE NominationVotes (
		id int IDENTITY(1,1) PRIMARY KEY,
		nomId int,
		votersId int
	)
