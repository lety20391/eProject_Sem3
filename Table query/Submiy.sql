USE [eProject3DB]
GO



CREATE TABLE [dbo].[Submit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDSubmit] AS ('SUBMIT' + CONVERT(varchar(20), ID)) PERSISTED NOT NULL PRIMARY KEY,
	[Entity1ID] [nvarchar](10) NOT NULL,
	[Entity2ID] [nvarchar](10) NOT NULL,
	[Type] [nvarchar](10) NULL,
	
) 


