USE [eProject3DB]
GO



CREATE TABLE [dbo].[Student](
	[ID] [int] NOT NULL,
	[StudentID]  AS ('STUDENT'+CONVERT([varchar](20),[ID])) PERSISTED NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DOB] [date] NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[ClassID] [varchar](25) NULL,
	[Admission] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Class]
GO


