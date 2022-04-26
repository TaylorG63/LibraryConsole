CREATE TABLE [dbo].[Genre]
(
	[GenreId] INT NOT NULL PRIMARY KEY,
	[Description] VARCHAR(MAX),
	[IsFiction] bit not null,
	[Name] varchar(50) NOT NULL
)
