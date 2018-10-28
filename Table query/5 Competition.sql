USE [eProject3DB]
GO



CREATE TABLE [dbo].[Competition](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompetitionID]  AS ('COMPETITION'+CONVERT([varchar](20),[ID])) PERSISTED NOT NULL,
	[Detail] [nvarchar](200) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Condition] [nvarchar](200) NULL,
	[AwardID] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[CompetitionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Competition]  WITH CHECK ADD  CONSTRAINT [FK_Competition_Award] FOREIGN KEY([AwardID])
REFERENCES [dbo].[Award] ([AwardID])
GO

ALTER TABLE [dbo].[Competition] CHECK CONSTRAINT [FK_Competition_Award]
GO


