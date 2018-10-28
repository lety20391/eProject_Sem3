USE [eProject3DB]
GO



CREATE TABLE [dbo].[Staff](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StaffID]  AS ('STAFF'+CONVERT([varchar](20),[ID])) PERSISTED NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DOB] [date] NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[ClassID] [varchar](25) NULL,
	[Subject] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO

ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Class]
GO


