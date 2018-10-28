USE [eProject3DB]
GO


CREATE TABLE [dbo].[Class](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] AS ('CLASS' + CONVERT(varchar(20), ID)) PERSISTED NOT NULL PRIMARY KEY ,
	[ClassName] [nvarchar](50) NULL
 )


