USE [eProject3DB]
GO


CREATE TABLE [dbo].[Award](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AwardID]  AS ('AWARD'+CONVERT([varchar](20),[ID])) PERSISTED NOT NULL,
	[PriceLevied] [int] NOT NULL,
	[CompetitionID] [nvarchar](10) NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AwardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


