CREATE TABLE [dbo].[Author]
(
	[AuthorId] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] varchar(50) not null,
	[LastName] varchar(50) not null,
	[DateOfBirth] date not null,
	[BirthLocation] varchar(50) not null,
	[Bio] varchar(max) NOT NULL
)
