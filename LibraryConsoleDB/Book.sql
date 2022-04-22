CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Title] varchar(50) not null,
	[Description] varchar(250) not null,
	[Price] money not null
)
