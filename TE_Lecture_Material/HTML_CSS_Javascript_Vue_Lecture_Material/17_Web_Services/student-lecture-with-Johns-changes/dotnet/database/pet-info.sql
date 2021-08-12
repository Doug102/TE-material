
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='pet-info')
DROP DATABASE [pet-info];
GO

-- Create a new Pet Info Database
CREATE DATABASE [pet-info];
GO

-- Switch to the Pet Info Database
USE [pet-info]
GO

-- Begin a TRANSACTION that must complete with no errors
BEGIN TRANSACTION;

GO
CREATE TABLE [pets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](60) NOT NULL,
	[type] [nvarchar](60) NOT NULL,
	[breed] [nvarchar](60) NOT NULL,
	[image] [nvarchar](60) NOT NULL,
	[age] [int] NOT NULL,
	CONSTRAINT pk_pets_id PRIMARY KEY (id)
);

GO
CREATE TABLE [customers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](60) NOT NULL,
	[email] [nvarchar](60) NOT NULL,
	[phone] [nvarchar](60) NOT NULL,
	CONSTRAINT pk_customers_id PRIMARY KEY (id)
);


CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)
	

GO
SET IDENTITY_INSERT [dbo].[pets] ON 
INSERT [dbo].[pets] ([id], [name], [type], [breed], [image], [age]) VALUES (1, N'Bella', N'dog', N'GSD', 'https://photos.app.goo.gl/cGfChNdaT8bdCmi69',4)
INSERT [dbo].[pets] ([id], [name], [type], [breed], [image], [age]) VALUES (2, N'Primrose', N'cat', N'DSH', 'https://www.flickr.com/photos/192624577@N03/shares/8MKE8X',7)
INSERT [dbo].[pets] ([id], [name], [type], [breed], [image], [age]) VALUES (3, N'Gabriel', N'cat', N'DSH', 'https://photos.app.goo.gl/mApSEdJqNiMwnfLGA',7)
INSERT [dbo].[pets] ([id], [name], [type], [breed], [image], [age]) VALUES (4, N'Penelope', N'cat', N'DSH', 'https://photos.app.goo.gl/6YpuvDqFM8zA4Swo7',7)
INSERT [dbo].[pets] ([id], [name], [type], [breed], [image], [age]) VALUES (5, N'Bobo', N'dog', N'American Mixed', 'https://photos.app.goo.gl/cGfChNdaT8bdCmi69',13)
SET IDENTITY_INSERT [dbo].[pets] OFF

GO

SET IDENTITY_INSERT [dbo].[customers] ON 
INSERT [dbo].[customers] ([id], [name], [email], [phone]) VALUES (1, N'John Fulton', N'john@johnfulton.org', N'614-565-8382')
INSERT [dbo].[customers] ([id], [name], [email], [phone]) VALUES (2, N'Lisa Bruegge-Fulton', N'lisa@bruegge-fulton.org', N'614-565-5967')
SET IDENTITY_INSERT [dbo].[customers] OFF


GO
--populate default data
-- user/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
--admin/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO

COMMIT TRANSACTION;
