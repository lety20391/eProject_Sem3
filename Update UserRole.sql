use ePrj3DB
go
alter table [User]
alter column [Role] nvarchar(30)

go
alter table [User]
add CONSTRAINT UC_Nick UNIQUE (UserNick)

INSERT INTO [dbo].[User]
           ([UserNick]
           ,[UserPass]
           ,[Role])
     VALUES
           ('Admin', 'abc123', 'Admin'),
		   ('Dat Le', 'abc123', 'Staff;Admin'),
		   ('Duy Shit', 'abc123', 'Manager;Admin'),
		   ('Duyen Tran Truong', 'abc123', 'Staff;Admin')
GO

