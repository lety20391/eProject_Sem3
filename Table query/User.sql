USE [eProject3DB]
GO


CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDUser] AS ('USER' + CONVERT(varchar(20), Id)) PERSISTED NOT NULL PRIMARY KEY ,
	[UserNick] [nvarchar](20) NOT NULL,
	[UserPass] [nvarchar](20) NOT NULL,
	[Real_ID] [varchar](25) NULL,
	[Role] [nvarchar](10) NOT NULL,
)

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Staff] FOREIGN KEY([Real_ID])
REFERENCES [dbo].[Staff] ([StaffID])
GO


ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Student] FOREIGN KEY([Real_ID])
REFERENCES [dbo].[Student] ([StudentID])
GO



