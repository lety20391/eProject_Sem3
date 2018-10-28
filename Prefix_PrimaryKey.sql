use prj3DB
go
CREATE TABLE dbo.Persons 
(
   Id int IDENTITY (1,1) NOT NULL
  ,PersonId AS ('ABCD' + CONVERT(varchar(20), Id)) PERSISTED NOT NULL PRIMARY KEY 
  ,Name varchar(100)
);

INSERT INTO dbo.Persons (Name)
VALUES ('Person1'), ('Person2'), ('Person3');
GO

SELECT PersonId, Name
FROM dbo.Persons;
GO

use prj3DB
go
CREATE TABLE dbo.Persons2
(
   Id int IDENTITY (1,1) NOT NULL
  ,PersonId AS ('ABCD' + CONVERT(varchar(20), Id)) PERSISTED NOT NULL PRIMARY KEY 
  ,Name varchar(100)
  ,Gender varchar(5) constraint ckGender check (Gender in ('Male', 'Female')) 
);

use TestCheck
go
alter table [User]
Add UserID As ('USER' + CONVERT(varchar(20), ID)) PERSISTED NOT NULL PRIMARY KEY