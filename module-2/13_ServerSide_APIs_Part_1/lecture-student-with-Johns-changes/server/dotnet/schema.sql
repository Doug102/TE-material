
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the World Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='HotelReservation')
DROP DATABASE HotelReservation;
GO

-- Create a new World Database
CREATE DATABASE HotelReservation;
GO

-- Switch to the World Database
USE HotelReservation
GO

CREATE TABLE [dbo].[reservation](
	[id] [int] IDENTITY PRIMARY KEY,
	[hotelid] [int] NOT NULL,
	[fullname] [nvarchar](50) NOT NULL,
	[checkindate] [nvarchar](12) NOT NULL,
	[checkoutdate] [nvarchar](12) NOT NULL,
	[guests] [int] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[hotel](
	[id] [int] IDENTITY PRIMARY KEY,
	[name] [nvarchar](50) NOT NULL,
	[streetaddress] [nvarchar](50) NOT NULL,
	[streetaddress2] [nvarchar](50) NOT NULL,
	[city] [nvarchar](50) NOT NULL,
	[state] [nvarchar](50) NOT NULL,
	[zip] [nvarchar](50) NOT NULL,
	[stars] [int] NOT NULL,
	[roomsavailable] [int] NOT NULL,
	[costpernight] [int] NOT NULL,
	[coverimage] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO


SET IDENTITY_INSERT reservation ON
GO
INSERT [dbo].[reservation] ([id], [hotelid], [fullname], [checkindate], [checkoutdate], [guests]) VALUES (1, 1, N'John Smith', N'6/22/2021', N'6/25/2021', 2)
GO
INSERT [dbo].[reservation] ([id], [hotelid], [fullname], [checkindate], [checkoutdate], [guests]) VALUES (2, 1, N'Sam Turner', N'6/22/2021', N'6/27/20201', 4)
GO
INSERT [dbo].[reservation] ([id], [hotelid], [fullname], [checkindate], [checkoutdate], [guests]) VALUES (3, 1, N'MArk Johnson', N'6/29/2021', N'7/3/2021', 2)
GO
INSERT [dbo].[reservation] ([id], [hotelid], [fullname], [checkindate], [checkoutdate], [guests]) VALUES (4, 2, N'Joseph Williams', N'6/24/2021', N'6262021', 2)
GO
SET IDENTITY_INSERT reservation OFF



SET IDENTITY_INSERT hotel ON
INSERT [dbo].[hotel] ([id], [name], [streetaddress], [streetaddress2], [city], [state], [zip], [stars], [roomsavailable], [costpernight], [coverimage]) VALUES (1, N'Aloft Cleveland', N'1111 W 10th St', N' ', N'Cleveland', N'OH', N'44113', 3, 48, 274, N'aloft-cleveland.webp')
GO
INSERT [dbo].[hotel] ([id], [name], [streetaddress], [streetaddress2], [city], [state], [zip], [stars], [roomsavailable], [costpernight], [coverimage]) VALUES (2, N'Hilton Cleveland Downtown', N'100 Lakeside Ave', N' ', N'Cleveland', N'OH', N'44114', 4, 12, 287, N'hilton-cleveland.webp')
GO
INSERT [dbo].[hotel] ([id], [name], [streetaddress], [streetaddress2], [city], [state], [zip], [stars], [roomsavailable], [costpernight], [coverimage]) VALUES (3, N'Metropolitan at the 9', N'2017 E 9th St', N' ', N'Cleveland', N'OH', N'44115', 4, 22, 319, N'metropolitan-cleveland.webp')
GO
INSERT [dbo].[hotel] ([id], [name], [streetaddress], [streetaddress2], [city], [state], [zip], [stars], [roomsavailable], [costpernight], [coverimage]) VALUES (4, N'The Westin Pittsburgh', N'1000 Penn Ave', N'  ', N'Pittsburgh', N'PA', N'15222', 4, 60, 131, N'westin-pittsburgh.webp')
GO
SET IDENTITY_INSERT hotel OFF
