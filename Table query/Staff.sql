USE [eProject3DB]
GO


CREATE TABLE [dbo].[Staff](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID] AS ('STAFF' + CONVERT(varchar(20), ID)) PERSISTED NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DOB] [date] NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Class] [nvarchar](50) NULL,
	[Subject] [nvarchar](50) NULL,
)

