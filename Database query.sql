USE [master]
GO
--tao database ePrj3DB nho chinh lai duong dan
CREATE DATABASE [ePrjNewDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ePrjNewDB', FILENAME = N'E:\Aptech\Project Sem 3\Database\ePrjNewDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ePrjNewDB_log', FILENAME = N'E:\Aptech\Project Sem 3\Database\ePrjNewDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

use ePrjNewDB
go


--tao bang Award
CREATE TABLE [dbo].[Award](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[AwardID]  AS ('AWARD'+CONVERT([varchar](20),[num])) PERSISTED NOT NULL PRIMARY KEY,
	[PriceLevied] [int] NOT NULL,
	[CompetitionID] [nvarchar](10) NULL,
	[Quantity] [int] NOT NULL,
)
GO


--tao bang class
CREATE TABLE [dbo].[Class](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[ClassID]  AS ('CLASS'+CONVERT([varchar](20),[num])) PERSISTED NOT NULL PRIMARY KEY,
	[ClassName] [nvarchar](50) NULL,
)
GO

--tao bang Exhibition
CREATE TABLE [dbo].[Exhibition](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[ExhibitionID]  AS ('EXHIBITION'+CONVERT([varchar](20),[num])) PERSISTED NOT NULL PRIMARY KEY,
	[Detail] [nvarchar](200) NOT NULL,
	[Country] [nvarchar](50) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Condition] [nvarchar](200) NULL,
	[Quantity] [int] NOT NULL,
)
GO

--tao bang submit
CREATE TABLE [dbo].[Submit](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[IDSubmit]  AS ('SUBMIT'+CONVERT([varchar](20),[num])) PERSISTED NOT NULL PRIMARY KEY,
	[Entity1ID] [varchar](40) NULL,
	[Entity2ID] [varchar](40) NULL,
	[Type] [nvarchar](30) NULL,
	[time] [datetime] NULL,
)
GO

--tao bang Competition va Foreign Key
CREATE TABLE [dbo].[Competition](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[CompetitionID]  AS ('COMPETITION'+CONVERT([varchar](20),[num])) PERSISTED NOT NULL PRIMARY KEY,
	[Detail] [nvarchar](200) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Condition] [nvarchar](200) NULL,
	[AwardID] [varchar](25) NULL,
)
GO

ALTER TABLE [dbo].[Competition]  WITH CHECK ADD  CONSTRAINT [FK_Competition_Award] FOREIGN KEY([AwardID])
REFERENCES [dbo].[Award] ([AwardID])
GO

ALTER TABLE [dbo].[Competition] CHECK CONSTRAINT [FK_Competition_Award]
GO

--tao bang Student va foreign key
CREATE TABLE [dbo].[Student](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[StudentID]  AS ('STUDENT'+CONVERT([varchar](20),[num])) PERSISTED NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DOB] [date] NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[ClassID] [varchar](25) NULL,
	[Admission] [nvarchar](100) NULL,
	[Status] bit NOT NULL DEFAULT 1,
)
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Class]
GO

--tao bang Staff va foreign key
CREATE TABLE [dbo].[Staff](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[StaffID]  AS ('STAFF'+CONVERT([varchar](20),[num])) PERSISTED NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DOB] [date] NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[ClassID] [varchar](25) NULL,
	[Subject] [nvarchar](50) NULL,
	[Status] bit NOT NULL DEFAULT 1,
)
GO

ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO

ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Class]
GO


--tao bang User
CREATE TABLE [dbo].[User](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[IDUser]  AS ('USER'+CONVERT([varchar](20),[num])) PERSISTED NOT NULL PRIMARY KEY,
	[UserNick] [nvarchar](20) NOT NULL,
	[UserPass] [nvarchar](20) NOT NULL,
	[Real_ID] [varchar](25) NULL,
	[Role] [nvarchar](10) NOT NULL,
	[Status] bit NOT NULL DEFAULT 1,
)
GO

--tao bang Comment va foreign key
CREATE TABLE [dbo].[Comment](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[CommentID]  AS ('COMMENT'+CONVERT([varchar](20),[num])) PERSISTED NOT NULL PRIMARY KEY,
	[Detail] [nvarchar](200) NULL,
	[UserID] [varchar](24) NOT NULL,
	[MainID] [varchar](40) NULL,
	[Status] bit NOT NULL DEFAULT 1,
)
GO

ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([IDUser])
GO

ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO

--tao bang Exam va Foreign key
CREATE TABLE [dbo].[Exam](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[ExamID]  AS ('EXAM'+CONVERT([varchar](20),[num])) PERSISTED NOT NULL PRIMARY KEY,
	[Path] [nvarchar](50) NOT NULL,
	[Quotation] [nvarchar](100) NULL,
	[Story] [nvarchar](500) NULL,
	[IDStudent] [varchar](27) NOT NULL,
	[IDCompetition] [varchar](31) NULL,
	[IDExhibition] [varchar](30) NULL,
	[Mark] [nvarchar](10) NULL,
	[IDAward] [varchar](25) NULL,
	[ChangeDescription] [nvarchar](100) NOT NULL,
	[Status] [bit] NOT NULL,
	[MoneyReturn] [bit] NULL,
	[Price] [int] NOT NULL,
	[Improvement] [bit] NULL,
)
GO

ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Award] FOREIGN KEY([IDAward])
REFERENCES [dbo].[Award] ([AwardID])
GO

ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [FK_Exam_Award]
GO

ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Competition] FOREIGN KEY([IDCompetition])
REFERENCES [dbo].[Competition] ([CompetitionID])
GO

ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [FK_Exam_Competition]
GO

ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Exhibition] FOREIGN KEY([IDExhibition])
REFERENCES [dbo].[Exhibition] ([ExhibitionID])
GO

ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [FK_Exam_Exhibition]
GO

ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Student] FOREIGN KEY([IDStudent])
REFERENCES [dbo].[Student] ([StudentID])
GO

ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [FK_Exam_Student]
GO

--tao bang Customer va foreign key
CREATE TABLE [dbo].[Customer](
	[num] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID]  AS ('CUSTOMER'+CONVERT([varchar](20),[num])) PERSISTED NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[IDExhibition] [varchar](30) NULL,
	[IDExam] [varchar](24) NULL,
)
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Exam] FOREIGN KEY([IDExam])
REFERENCES [dbo].[Exam] ([ExamID])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Exam]
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Exhibition] FOREIGN KEY([IDExhibition])
REFERENCES [dbo].[Exhibition] ([ExhibitionID])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Exhibition]
GO

alter table [User]
alter column [Role] nvarchar(30)

go
alter table [User]
add CONSTRAINT UC_Nick UNIQUE (UserNick)

INSERT INTO [dbo].[User]
           ([UserNick]
           ,[UserPass]
           ,[Role])
     VALUES
           ('Admin', 'abc123', 'Admin'),
		   ('Dat Le', 'abc123', 'Staff;Admin'),
		   ('Duy Shit', 'abc123', 'Manager;Admin'),
		   ('Duyen Tran Truong', 'abc123', 'Staff;Admin')
GO

