USE [eProject3DB]
GO



CREATE TABLE [dbo].[Competition](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompetitionID] AS ('COMPETITION' + CONVERT(varchar(20), ID)) PERSISTED NOT NULL PRIMARY KEY,
	[Detail] [nvarchar](200) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Condition] [nvarchar](200) NULL,
	[Award] [nvarchar](10) NULL,
 )


