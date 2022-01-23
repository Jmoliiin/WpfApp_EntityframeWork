--DROP TABLE Errands
--DROP TABLE Costumers
DROP TABLE Statuses
--DROP TABLE Admins
--DROP TABLE Addresses

CREATE TABLE Addresses(
	Id int not null identity primary key,
	StreetName nvarchar(50) not null,
	PostalCode char(5) not null,
	City nvarchar(50) not null,
	Country nvarchar(50) not null	
)

CREATE TABLE Admins(
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null
)

CREATE TABLE Statuses(
Id int not null identity primary key,
StatusType nvarchar(50) not null
	
)
GO
CREATE TABLE Costumers(
Id int not null identity primary key,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
Email varchar(100) not null unique,
MobileNumber char(12) not null,
AddressId int not null references Addresses(Id)
	
)
GO
CREATE TABLE Errands(
Id int not null identity primary key,
Heading nvarchar(50) not null,
Descriptions nvarchar(100) not null,
DateCreated DateTime2(7) not null ,
DateChanged DateTime2(7) null ,
CostumerId int not null references Costumers(Id),
AdminsId int not null references Admins(Id),
SatusId int not null references Statuses(Id)
	
)