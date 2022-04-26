CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Role] INT FOREIGN KEY REFERENCES [dbo].[Role](RoleID),
	[FirstName] varchar(50) NOT NULL,
	[LastName] varchar(50) NOT NULL,
	[UserName] varchar(50) NOT NULL,
	[Password] varchar(64) NOT NULL,
	[Salt] varchar(64) not null
	
)
