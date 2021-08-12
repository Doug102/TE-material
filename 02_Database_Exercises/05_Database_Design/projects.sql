USE master

GO

DROP DATABASE IF EXISTS ProjectOrganizer 

GO

CREATE DATABASE ProjectOrganizer

GO

USE ProjectOrganizer
GO

BEGIN TRANSACTION;


CREATE TABLE Employee (
employee_number int IDENTITY PRIMARY KEY,
job_title nvarchar(50),
last_name nvarchar(50) NOT NULL,
first_name nvarchar(50) NOT NULL,
gender nvarchar(15),
date_of_birth datetime NOT NULL,
date_of_hire datetime NOT NULL,
department_number int NOT NULL
);

CREATE TABLE Department (
department_number int IDENTITY PRIMARY KEY,
name nvarchar(50) NOT NULL
);

CREATE TABLE Employee_Project (
project_number int NOT NULL,
employee_number int NOT NULL,
CONSTRAINT pk_Employee_Project_project_number_employee_number PRIMARY KEY (project_number, employee_number)
);

CREATE TABLE Project (
project_number int IDENTITY PRIMARY KEY,
name nvarchar(50) NOT NULL,
start_date datetime NOT NULL 
);

SET IDENTITY_INSERT Employee ON;

INSERT INTO Employee (employee_number, job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_number)
VALUES (1, 'General Manager', 'Stew', 'Steve', 'Male', 1960-08-26, 1980-04-12, 1);
INSERT INTO Employee (employee_number, job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_number)
VALUES (2, 'Operations Director', 'Monte', 'Colleen', 'Female', 1985-06-14, 2006-01-30, 1);
INSERT INTO Employee (employee_number, job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_number)
VALUES (3, 'Executive Housekeeper', 'Hardt', 'Jen', 'Female', 1992-10-06, 2011-03-21, 2);
INSERT INTO Employee (employee_number, job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_number)
VALUES (4, 'Room Attendant', 'Roadie', 'Diana', 'Female', 1960-08-26, 1980-04-12, 2);
INSERT INTO Employee (employee_number, job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_number)
VALUES (5, 'Houseman', 'Wa', 'Mike', 'Male', 1994-02-18, 2018-12-06, 2);
INSERT INTO Employee (employee_number, job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_number)
VALUES (6, 'Finance Director', 'Red', 'Eric', 'Male', 1968-02-28, 1990-07-01, 3);
INSERT INTO Employee (employee_number, job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_number)
VALUES (7, 'Assistant Finance Director', 'Ellie', 'George', 'Male', 1972-04-10, 1991-01-08, 3);
INSERT INTO Employee (employee_number, job_title, last_name, first_name, gender, date_of_birth, date_of_hire, department_number)
VALUES (8, 'Finance Clerk', 'Winter', 'Jason', 'Male', 1980-11-06, 1998-02-15, 3);

SET IDENTITY_INSERT Employee OFF;

SET IDENTITY_INSERT Department ON;

INSERT INTO Department (department_number, name)
VALUES (1, 'Leadership Committee');
INSERT INTO Department (department_number, name)
VALUES (2, 'Housekeeping');
INSERT INTO Department (department_number, name)
VALUES (3, 'Finance');

SET IDENTITY_INSERT Department OFF;

SET IDENTITY_INSERT Project ON;

INSERT INTO Project (project_number, name, start_date)
VALUES (1, 'Renovation', 2021-06-05);
INSERT INTO Project (project_number, name, start_date)
VALUES (2, 'Month End', 2021-05-31);
INSERT INTO Project (project_number, name, start_date)
VALUES (3, 'WOH Enrollment', 2021-01-01);
INSERT INTO Project (project_number, name, start_date)
VALUES (4, 'Deep Clean', 2021-04-10);

SET IDENTITY_INSERT Project OFF;

INSERT INTO Employee_Project (project_number, employee_number)
VALUES (1, 1);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (3, 1);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (1, 2);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (2, 2);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (3, 2);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (1, 3);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (4, 3);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (4, 4);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (1, 5);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (4, 5);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (1, 6);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (2, 6);
INSERT INTO Employee_Project (project_number, employee_number)
VALUES (2, 7);

ALTER TABLE Employee
ADD FOREIGN KEY (department_number)
REFERENCES Department(department_number);

ALTER TABLE Employee_Project
ADD FOREIGN KEY (project_number)
REFERENCES Project(project_number);

ALTER TABLE Employee_Project
ADD FOREIGN KEY (employee_number)
REFERENCES Employee(employee_number);

COMMIT;
