USE master
GO

DROP DATABASE IF EXISTS PetInfo;
GO

CREATE DATABASE PetInfo;
GO

USE PetInfo;
GO


CREATE TABLE Pet (
Id int IDENTITY PRIMARY KEY,
Name nvarchar(30) NOT NULL,
Type  nvarchar(30) NOT NULL,
Breed  nvarchar(30) NOT NULL,
Owner int NOT NULL
);

CREATE TABLE Customer(
Id int IDENTITY(1000,1) PRIMARY KEY,
Name nvarchar(30) NOT NULL,
Email nvarchar(30) NOT NULL,
Address nvarchar(30) NOT NULL,
Phone nvarchar(30) NOT NULL
);

CREATE TABLE Procedures(
Id int IDENTITY(2000,1) PRIMARY KEY,
Name nvarchar(30) NOT NULL,
Date datetime NOT NULL,
Pet int NOT NULL
);

CREATE TABLE Users (
  Id INT IDENTITY PRIMARY KEY,
  Username VARCHAR(255) NOT NULL UNIQUE, -- Username
  Password VARCHAR(48) NOT NULL, -- Password (hashed, not plain-text)
  Salt VARCHAR(256) NOT NULL -- Password Salt
);



SET IDENTITY_INSERT  Pet ON
INSERT INTO Pet (Id, Name, Type, Breed, Owner) VALUES (1, 'Bella', 'dog', 'GSD', 1000);
INSERT INTO Pet (Id, Name, Type, Breed, Owner) VALUES (2, 'Primrose', 'cat', 'DSH', 1001);
INSERT INTO Pet (Id, Name, Type, Breed, Owner) VALUES (3, 'Gabriel', 'cat', 'DSH', 1001);
INSERT INTO Pet (Id, Name, Type, Breed, Owner) VALUES (4, 'Penny', 'cat', 'DSH', 1001);
INSERT INTO Pet (Id, Name, Type, Breed, Owner) VALUES (5, 'Fish01', 'fish', 'Goldfish', 1000);
INSERT INTO Pet (Id, Name, Type, Breed, Owner) VALUES (6, 'Fish02', 'fish', 'Goldfish', 1000);
SET IDENTITY_INSERT  Pet OFF

SET IDENTITY_INSERT  Customer ON
INSERT INTO Customer (Id, Name, Email, Address, Phone) VALUES (1000, 'John', 'John@email.com', '123 Any Street', '6145551234');
INSERT INTO Customer (Id, Name, Email, Address, Phone) VALUES (1001, 'Lisa', 'Lisa@email.com', '123 Any Street', '6145551234');
SET IDENTITY_INSERT  Customer OFF

SET IDENTITY_INSERT Procedures ON
INSERT INTO Procedures (Id, Name, Date, Pet) VALUES (2000, 'Rabies Vaccination', '2021-06-11', 1)
SET IDENTITY_INSERT Procedures OFF


ALTER TABLE Pet
WITH CHECK ADD CONSTRAINT FK_PetCustomer
FOREIGN KEY (Owner) REFERENCES Customer(Id);

ALTER TABLE Procedures
WITH CHECK ADD CONSTRAINT FK_ProceduresPet
FOREIGN KEY (Pet) REFERENCES Pet(Id);
