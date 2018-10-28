USE [eProject3DB]
GO


CREATE TABLE [dbo].[Exhibition](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExhibitionID]  AS ('EXHIBITION'+CONVERT([varchar](20),[ID])) PERSISTED NOT NULL,
	[Detail] [nvarchar](200) NOT NULL,
	[Country] [nvarchar](50) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Condition] [nvarchar](200) NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ExhibitionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


