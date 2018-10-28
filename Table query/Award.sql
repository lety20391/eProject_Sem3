USE [eProject3DB]
GO

CREATE TABLE [dbo].[Award](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AwardID] AS ('AWARD' + CONVERT(varchar(20), ID)) PERSISTED NOT NULL PRIMARY KEY ,
	[PriceLevied] [int] NOT NULL,
	[CompetitionID] [nvarchar](10) NULL,
	[Quantity] [int] NOT NULL
 )


