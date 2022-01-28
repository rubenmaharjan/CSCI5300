Use OrchestraDb
Go

--DROP TABLE Instrument;
--DROP TABLE Musician;
--DROP TABLE Orchestra;

GO
CREATE TABLE Orchestra
(
	Id INT IdENTITY PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	AddressLine1 VARCHAR(50) NOT NULL,
	AddressLine2 VARCHAR(50),
	City VARCHAR(50) NOT NULL,
	State VARCHAR(2) NOT NULL,
	ZipCode VARCHAR(5) NOT NULL,
	WebsiteURL VARCHAR(50)
);

GO
CREATE TABLE Musician
(
	Id INT IdENTITY PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Section VARCHAR(50) NOT NULL,
	SectionLeader BIT NOT NULL,
	OrchestraId INT NOT NULL,
	
	CONSTRAINT FK_Orchestra FOREIGN KEY (OrchestraId) REFERENCES Orchestra (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

GO
CREATE TABLE Instrument
(
	Id INT IdENTITY PRIMARY KEY,
	SerialNumber VARCHAR(50),
	Description VARCHAR(MAX),
	Maintenance_Date DATE,
	Condition VARCHAR(50),
	MusicianId INT NOT NULL,
	
	CONSTRAINT FK_Musician FOREIGN KEY (MusicianId) REFERENCES Musician (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

GO
--Orchestra
INSERT INTO Orchestra (Name, AddressLine1, City, State, ZipCode, WebsiteURL)
	VALUES ('Johnson City Symphony Orchestra', '172 West Springbrook Drive', 'Johnson City','TN','37604','https://www.jcsymphony.com/');
INSERT INTO Orchestra (Name, AddressLine1,AddressLine2, City, State, ZipCode, WebsiteURL)
	VALUES ('Knoxville Symphony Orchestra', '100 South Gay Street', 'Suite 302', 'Knoxville','TN','37902','https://www.knoxvillesymphony.com/');

--Musician
----Johnson City
INSERT INTO Musician (FirstName, LastName, Section, SectionLeader, OrchestraId)
	VALUES ('Helen', 'Bryenton', 'Violin I', 1,1);
INSERT INTO Musician (FirstName, LastName, Section, SectionLeader, OrchestraId)
	VALUES ('Kellie', 'Brown', 'Violin I', 0,1);
INSERT INTO Musician (FirstName, LastName, Section, SectionLeader, OrchestraId)
	VALUES ('Kimberly', 'Maternik-Piret', 'Violin II', 1,1);
INSERT INTO Musician (FirstName, LastName, Section, SectionLeader, OrchestraId)
	VALUES ('Benjamin', 'Dawson', 'Violin II', 0,1);
----Knoxville
INSERT INTO Musician (FirstName, LastName, Section, SectionLeader, OrchestraId)
	VALUES ('William', 'Shaub', 'Violin I', 1,2);
INSERT INTO Musician (FirstName, LastName, Section, SectionLeader, OrchestraId)
	VALUES ('Gordon', 'Tsai', 'Violin I', 0,2);
INSERT INTO Musician (FirstName, LastName, Section, SectionLeader, OrchestraId)
	VALUES ('Edward', 'Pulgar', 'Violin II', 1,2);
INSERT INTO Musician (FirstName, LastName, Section, SectionLeader, OrchestraId)
	VALUES ('Sean', 'Claire', 'Violin II', 0,2);
--Instrument
INSERT INTO Instrument(SerialNumber, Description, Maintenance_Date, Condition, MusicianId)
	VALUES ('A2349-34', 'Violin', GETDATE(), 'New',1);
INSERT INTO Instrument(SerialNumber, Description, Maintenance_Date, Condition, MusicianId)
	VALUES ('I3434-90', 'Violin', GETDATE()-5, 'New',2);
INSERT INTO Instrument(SerialNumber, Description, Maintenance_Date, Condition, MusicianId)
	VALUES ('K3495-45', 'Violin', GETDATE()-35, 'Good',3);
INSERT INTO Instrument(SerialNumber, Description, Maintenance_Date, Condition, MusicianId)
	VALUES ('L3456-34', 'Violin', GETDATE()-945, 'Fair',4);
INSERT INTO Instrument(SerialNumber, Description, Maintenance_Date, Condition, MusicianId)
	VALUES ('B3440-24', 'Violin', GETDATE()-120, 'Good',5);
INSERT INTO Instrument(SerialNumber, Description, Maintenance_Date, Condition, MusicianId)
	VALUES ('A2349-36', 'Violin', GETDATE(), 'New',6);
INSERT INTO Instrument(SerialNumber, Description, Maintenance_Date, Condition, MusicianId)
	VALUES ('A2349-38', 'Violin', GETDATE(), 'New',7);
INSERT INTO Instrument(SerialNumber, Description, Maintenance_Date, Condition, MusicianId)
	VALUES ('A2349-40', 'Violin', GETDATE(), 'New',8);

SELECT
	FirstName + ' ' + LastName AS FullName
	,Section
	,Name AS Orchestra
	,Description
	,Maintenance_Date
	,Condition
FROM
	Orchestra AS Orch
	JOIN Musician AS Musi
	ON Orch.Id = Musi.OrchestraId
	JOIN Instrument AS Inst
	ON Musi.Id  = Inst.MusicianId