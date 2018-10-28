USE [eProject3DB]
GO



CREATE TABLE [dbo].[Comment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CommentID] AS ('COMMENT' + CONVERT(varchar(20), ID)) PERSISTED NOT NULL PRIMARY KEY,
	[Detail] [nvarchar](200) NULL,
	[UserID] [varchar](24) NOT NULL,
	[MainID] [varchar](25) NOT NULL,
 )

ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([IDUser])
GO



