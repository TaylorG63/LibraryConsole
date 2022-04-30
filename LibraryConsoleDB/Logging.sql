CREATE TABLE [dbo].[Logging]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Controller] varchar(50) not null,
	[Method] varchar(50) not null,
	[Log] varchar(MAX) NOT NULL
)
