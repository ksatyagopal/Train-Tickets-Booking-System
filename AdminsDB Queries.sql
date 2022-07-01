use AdminsDB

CREATE TABLE Admins(
AdminID INT PRIMARY KEY IDENTITY(12345,11),
UserName VARCHAR(50),
AdminName VARCHAR(50),
IsSuperAdmin BIT,
LastLoggedInDate DATETIME,
IsActive BIT,
Password VARCHAR(16),
IsDeleted BIT,
IsLocked BIT,
UnSuccessfulAttempts INT
)

CREATE TABLE Contributions(
CID INT PRIMARY KEY IDENTITY(1,1),
ChangeMadeBy INT FOREIGN KEY REFERENCES Admins(AdminID),
Reference VARCHAR(30),
ChangesMade VARCHAR(30),
ChangedTime DATETIME,
Reason NVARCHAR(MAX)
)

use AdminsDB
select * from Admins
delete from Admins where AdminID=12356