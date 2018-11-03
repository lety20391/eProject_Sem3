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
	[UserPass] [nvarchar](20) COLLATE Latin1_General_CS_AS NOT NULL,
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
           ,[Role]
		   ,[Real_ID])
     VALUES
           ('Admin', 'abc123', 'Admin', ''),
		   ('Dat Le', 'abc123', 'Staff;Admin', 'STAFF1'),
		   ('Duy Shit', 'abc123', 'Manager;Admin', 'STAFF2'),
		   ('Duyen Tran Truong', 'abc123', 'Staff;Admin', 'STAFF3'),
		   ('Min', 'abc123', 'Student', 'STUDENT1'),
		   ('Congy', 'abc123', 'Student', 'STUDENT2')
GO

INSERT INTO [DBO].Student ([Name],[Gender],[DOB],[Phone],[Address],[Admission])
values 
	('Vitamin', 1, '1996-10-10 12:00:00.000', '0988888888', 'HCM', 'Paid'),
	('Congy', 0, '1995-1-1 12:00:00.000', '0977777777', 'Q7', 'not Paid')
go

INSERT INTO [DBO].Staff ([Name],[Gender],[DOB],[Phone],[Address],[Status],[Subject])
values 
	('Lo Co Do', 1, '1980-1-1 12:00:00.000', '0988888888', 'HCM', 1, 'Math'),
	('Duy bue due', 1, '1990-1-1 12:00:00.000', '0977777777', 'Q12', 1, 'Literature'),
	('Duyen dep trai', 1, '1990-1-1 12:00:00.000', '0966666666', 'HCM', 1, 'Art')
go

INSERT INTO [dbo].Competition([Detail], [StartDate], [EndDate], [Condition])
values
	('Creative Comp', '2018-12-12 12:00:00.000', '2019-1-1 12:00:00.000', 'Mark'),
	('Art Comp', '2018-12-12 12:00:00.000', '2019-1-1 12:00:00.000', 'Good')

go

INSERT INTO [dbo].Exhibition([Detail],[Country], [StartDate], [EndDate], [Condition], [Quantity])
values 
	('Ex in VN', 'Vietnamese', '2018-12-12 12:00:00.000', '2019-1-1 12:00:00.000', 'Mark', 10),
	('Ex in Lao', 'Lao', '2018-12-12 12:00:00.000', '2019-1-1 12:00:00.000', 'Good', 20)

	go

INSERT INTO [dbo].Exam ([Quotation],[Story],[IDCompetition],[IDStudent],[ChangeDescription],[Price],[Path], [Status], [IDExhibition])
values
	('Quo1', 'Story1', 'COMPETITION1','STUDENT1', 'DES1', 100, '1.jpg' ,1 ,'EXHIBITION1'),
	('Quo2', 'Story2', 'COMPETITION1','STUDENT1', 'DES2', 100, '2.jpg', 1 ,'EXHIBITION1'),
	('Quo3', 'Story3', 'COMPETITION1','STUDENT2', 'DES3', 100, '3.jpg', 1 ,'EXHIBITION1'),
	('Quo4', 'Story4', 'COMPETITION1','STUDENT1', 'DES4', 100, '4.jpg', 1 ,'EXHIBITION1'),
	('Quo5', 'Story5', 'COMPETITION1','STUDENT2', 'DES5', 100, '5.jpg', 1 ,'EXHIBITION1'),
	('Quo6', 'Story6', 'COMPETITION1','STUDENT1', 'DES6', 100, '6.jpg', 1 ,'EXHIBITION1'),
	('Quo7', 'Story7', 'COMPETITION1','STUDENT2', 'DES7', 100, '7.jpg', 1 ,'EXHIBITION1'),
	('Quo8', 'Story8', 'COMPETITION1','STUDENT1', 'DES8', 100, '8.jpg', 1 ,'EXHIBITION1'),
	('Quo9', 'Story9', 'COMPETITION1','STUDENT2', 'DES9', 100, '9.jpg', 1 ,'EXHIBITION1'),
	('Quo10', 'Story10', 'COMPETITION2','STUDENT1', 'DES10', 100, '10.jpg', 1 ,'EXHIBITION2'),
	('Quo11', 'Story11', 'COMPETITION2','STUDENT1', 'DES11', 100, '11.jpg', 1 ,'EXHIBITION2'),
	('Quo12', 'Story12', 'COMPETITION2','STUDENT1', 'DES12', 100, '12.jpg', 1 ,'EXHIBITION2'),
	('Quo13', 'Story13', 'COMPETITION2','STUDENT2', 'DES13', 100, '13.jpg', 1 ,'EXHIBITION2'),
	('Quo14', 'Story14', 'COMPETITION2','STUDENT1', 'DES14', 100, '14.jpg', 1 ,'EXHIBITION2'),
	('Quo15', 'Story15', 'COMPETITION2','STUDENT2', 'DES15', 100, '15.jpg', 1 ,'EXHIBITION2'),
	('Quo16', 'Story16', 'COMPETITION2','STUDENT1', 'DES16', 100, '16.jpg', 1 ,'EXHIBITION2'),
	('Quo17', 'Story17', 'COMPETITION2','STUDENT2', 'DES17', 100, '17.jpg', 1 ,'EXHIBITION2'),
	('Quo18', 'Story18', 'COMPETITION2','STUDENT1', 'DES18', 100, '18.jpg', 1 ,'EXHIBITION2'),
	('Quo19', 'Story19', 'COMPETITION2','STUDENT2', 'DES19', 100, '19.jpg', 1 ,'EXHIBITION2'),
	('Quo20', 'Story20', 'COMPETITION2','STUDENT1', 'DES20', 100, '20.jpg', 1 ,'EXHIBITION2')
go

