USE [eProject3DB]
GO

CREATE TABLE [dbo].[Student](
	[ID] [int] NOT NULL,
	[StudentID] AS ('STUDENT' + CONVERT(varchar(20), ID)) PERSISTED NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DOB] [date] NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[ClassID] [varchar](25) NULL,
	[Admission] [nvarchar](100) NULL,
)

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO


