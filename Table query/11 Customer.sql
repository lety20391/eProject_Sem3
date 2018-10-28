USE [eProject3DB]
GO



CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID]  AS ('CUSTOMER'+CONVERT([varchar](20),[ID])) PERSISTED NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[IDExhibition] [varchar](30) NULL,
	[IDExam] [varchar](24) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
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


