CREATE TABLE [dbo].[Publisher]
(
	[PublisherID] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] varchar(50) not null,
	[Address] varchar(50) not null,
	[City] varchar(50) not null,
	[State] varchar(2) not null,
	[Zip] varchar(10) not null
)
