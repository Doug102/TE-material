USE master

GO

DROP DATABASE IF EXISTS PetInfo 

GO

CREATE DATABASE PetInfo

GO

USE PetInfo

CREATE TABLE Pet (
Id int IDENTITY PRIMARY KEY,
Name nvarchar(30),
Type nvarchar(30),
Breed nvarchar(30),
Owner int
);

CREATE TABLE Customer (
Id int IDENTITY(1000, 1) PRIMARY KEY,
Name nvarchar(30),
Email nvarchar(30),
Address nvarchar(30),
Phone nvarchar(30)
)

INSERT INTO Pet (Name, Type, Breed)
VALUES ('Bella', 'Dog', 'GSD') 

INSERT INTO Customer (Name, Email, Address, Phone)
VALUES ('John', 'john@email.com', '123 any street', '6145551234')

