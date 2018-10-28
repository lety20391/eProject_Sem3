USE [eProject3DB]
GO


CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] AS ('CUSTOMER' + CONVERT(varchar(20), ID)) PERSISTED NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[IDExhibition] [nvarchar](10) NULL,
	[IDExam] [nvarchar](10) NULL,
)

