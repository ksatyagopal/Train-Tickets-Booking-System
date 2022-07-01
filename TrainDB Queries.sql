Create databaSE TrainDB
use TrainDB

CREATE TABLE Stations(
StationCode VARCHAR(10) PRIMARY KEY,
StationName VARCHAR(50),
StationLocation VARCHAR(50),
HaultTime int,
IsDeleted BIT
)

CREATE TABLE Trains(
TrainNumber INT PRIMARY KEY,
TrainName VARCHAR(50),
TrainType VARCHAR(10),
TSource VARCHAR(10) FOREIGN KEY REFERENCES Stations(StationCode),
TDestination VARCHAR(10) FOREIGN KEY REFERENCES Stations(StationCode),
ArrivalTime VARCHAR(10),
DepartureTime VARCHAR(10),
AvailableSeats int,
nAc1Coaches INT,
nAc2Coaches INT,
nAc3Coaches INT,
nSlCoaches INT,
nSsCoaches INT,
nGeneralCoaches INT,
RunsOn VARCHAR(7),
IsDeleted BIT
)

CREATE TABLE Fares(
TypeOfCoach VARCHAR(20) PRIMARY KEY,
Fare MONEY
)
use TrainDB

CREATE TABLE TrainStatus(
TSid int primary key,
DOJ DATE,
TrainNumber INT Foreign KEY references Trains(TrainNumber),
AcSeats1Booked INT,
AcSeats2Booked INT,
AcSeats3Booked INT,
SlSeatsBooked INT,
SsSeatsBooked INT,
AcSeats1Available INT,
AcSeats2Available INT,
AcSeats3Available INT,
SlSeatsAvailable INT,
SsSeatsAvailable INT
)

CREATE TABLE Reaches(
ID INT PRIMARY KEY IDENTITY(1,1),
TrainNumber INT FOREIGN KEY REFERENCES Trains(TrainNumber),
StationCode VARCHAR(10) FOREIGN KEY REFERENCES Stations(StationCode),
ArrivalTime VARCHAR(10) 
)

CREATE TABLE StationDistances(
ID INT PRIMARY KEY IDENTITY(1,1),
StationA VARCHAR(10) FOREIGN KEY REFERENCES Stations(StationCode),
StationB VARCHAR(10) FOREIGN KEY REFERENCES Stations(StationCode),
Distance int
)

use TrainDB
select * from Reaches


insert into trains
values (12712, 'Pinakini',
'MAS','BZA',
'06:00','13:00',
100,1,1,1,1,'1111111',
0,'SF',1,1)