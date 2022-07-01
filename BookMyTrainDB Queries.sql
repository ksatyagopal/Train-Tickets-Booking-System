USE BookMyTrainDB

CREATE TABLE Users(
UserID INT PRIMARY KEY IDENTITY(1000,1),
FirstName VARCHAR(30),
LastName VARCHAR(30),
AdharNumber VARCHAR(12),
Gender CHAR,
Age INT,
Mobile VARCHAR(10),
MailID VARCHAR(50),
City VARCHAR(40),
State VARCHAR(40),
Pincode VARCHAR(6),
SecurityQuestion VARCHAR(50),
SecQuesAnswer VARCHAR(50),
Password VARCHAR(100),
IsDeleted BIT,
LastLoggedInDate DATETIME
)
CREATE TABLE MasterList(
MID INT PRIMARY KEY IDENTITY(10000,11),
UserID INT FOREIGN KEY REFERENCES Users(UserID),
FirstName VARCHAR(30),
LastName VARCHAR(30),
AdharNumber VARCHAR(12),
Gender CHAR,
Age INT,
IsDeleted BIT
)

CREATE TABLE PNRs(
PNRNumber BIGINT PRIMARY KEY IDENTITY(4131670911,11),
UserID INT FOREIGN KEY REFERENCES Users(UserID),
JourneyDate DATE,
JourneyStartTime varchar(10),
JourneyEndTime varchar(10),
NumberOfPassengers INT,
TotalFare MONEY,
IsDeleted BIT,
TransactionID INT,
FromStation varchar(10),
ToStation varchar(10),
BoardingStation varchar(10),
TrainNumber int,
TypeOfCoach varchar(10)
)

CREATE TABLE Tickets(
TicketID INT PRIMARY KEY IDENTITY(1000,1),
PNRNumber BIGINT FOREIGN KEY REFERENCES PNRs(PNRNumber),
PassengerName VARCHAR(30),
Age INT,
Gender CHAR,
SeatNumber INT,
Coach VARCHAR(5),
ReservationStatus VARCHAR(20),
IsCancelled BIT,
)

use BookMyTrainDB
select * from Users
delete from Users
where UserID=1005
