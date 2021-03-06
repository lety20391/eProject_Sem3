USE [eProject3DB]
GO

CREATE TABLE [dbo].[Exam](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExamID] AS ('EXAM' + CONVERT(varchar(20), ID)) PERSISTED NOT NULL PRIMARY KEY,
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

ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Award] FOREIGN KEY([IDAward])
REFERENCES [dbo].[Award] ([AwardID])
GO

ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Competition] FOREIGN KEY([IDCompetition])
REFERENCES [dbo].[Competition] ([CompetitionID])
GO



ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Exhibition] FOREIGN KEY([IDExhibition])
REFERENCES [dbo].[Exhibition] ([ExhibitionID])
GO


ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [FK_Exam_Student] FOREIGN KEY([IDStudent])
REFERENCES [dbo].[Student] ([StudentID])
GO


