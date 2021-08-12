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
	Name nvarchar(30),
	Type  nvarchar(30),
	Breed  nvarchar(30),
	Owner int NULL
);

CREATE TABLE Customer(
	Id int IDENTITY(1000,1) PRIMARY KEY,
	Name nvarchar(30),
	Email nvarchar(30),
	Address nvarchar(30),
	Phone nvarchar(30)
	)

CREATE TABLE Procedures(
	Id int IDENTITY(2000,1) PRIMARY KEY,
	Name nvarchar(30),
	Date datetime,
	Pet int
)


INSERT INTO Pet (Name, Type, Breed)
VALUES ('Bella', 'dog', 'GSD');

INSERT INTO Customer (Name, Email, Address, Phone)
VALUES ('John', 'John@email.com', '123 Any Street', '6145551234');

INSERT INTO Procedures (Name, Date)
VALUES ('Rabies Vaccination', '2021-06-11')
