-- Switch to the system (aka master) database
USE master;
GO

-- Delete the application database (IF EXISTS)
DROP DATABASE IF EXISTS CompanyForJoins;
GO

-- Create a new application database
CREATE DATABASE CompanyForJoins;
GO

-- Switch to the application database
USE CompanyForJoins
GO

-- DROP TABLE dbo.Employee;

-- DROP TABLE dbo.Position;

-- DROP TABLE dbo.Department;



CREATE TABLE [dbo].[Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE Department
ADD PRIMARY KEY (id);




CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [nvarchar](30) NOT NULL,
	[lastname] [nvarchar](10) NOT NULL,
	[position] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE Employee
ADD PRIMARY KEY (id);



CREATE TABLE [dbo].[Position](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](30) NOT NULL,
	[department] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE Position
ADD PRIMARY KEY (id);


SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([id], [name]) VALUES (1, N'Collections')
GO
INSERT [dbo].[Department] ([id], [name]) VALUES (2, N'Legal')
GO
INSERT [dbo].[Department] ([id], [name]) VALUES (3, N'Adminstration')
GO
INSERT [dbo].[Department] ([id], [name]) VALUES (4, N'Loading Dock')
GO
INSERT [dbo].[Department] ([id], [name]) VALUES (5, N'Receiving')
GO
INSERT [dbo].[Department] ([id], [name]) VALUES (6, N'Accounts Payable')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO


SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([firstname], [lastname], [id], [position]) VALUES (N'George', N'Washington', 1, 4)
GO
INSERT [dbo].[Employee] ([firstname], [lastname], [id], [position]) VALUES (N'Thomas', N'Jefferson ', 2, NULL)
GO
INSERT [dbo].[Employee] ([firstname], [lastname], [id], [position]) VALUES (N'Abraham', N'Lincoln', 3, 3)
GO
INSERT [dbo].[Employee] ([firstname], [lastname], [id], [position]) VALUES (N'Teddy', N'Roosevelt ', 4, NULL)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO


SET IDENTITY_INSERT [dbo].[Position] ON 
GO
INSERT [dbo].[Position] ([id], [title], [department]) VALUES (1, N'Shipping Clerk', NULL)
GO
INSERT [dbo].[Position] ([id], [title], [department]) VALUES (2, N'Collections Agent', NULL)
GO
INSERT [dbo].[Position] ([id], [title], [department]) VALUES (3, N'House Counsel', 2)
GO
INSERT [dbo].[Position] ([id], [title], [department]) VALUES (4, N'CEO', 3)
GO
INSERT [dbo].[Position] ([id], [title], [department]) VALUES (5, N'CIO', NULL)
GO
SET IDENTITY_INSERT [dbo].[Position] OFF
GO


ALTER TABLE Employee
ADD FOREIGN KEY (position) REFERENCES Position(id);

ALTER TABLE Position
ADD FOREIGN KEY (department) REFERENCES Department(id);
