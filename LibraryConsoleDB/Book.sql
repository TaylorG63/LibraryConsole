CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] varchar(50) not null,
	[Description] varchar(250) not null,
	[Price] money not null,
	[IsPaperBack] bit not null,
	[PublishDate] Date,
	[Author] INT FOREIGN KEY REFERENCES [dbo].[Author](AuthorId),
	[Genre] int FOREIGN KEY REFERENCES [dbo].[Genre](GenreId),
	[Publisher] INT FOREIGN KEY REFERENCES [dbo].[Publisher](PublisherID)
)
