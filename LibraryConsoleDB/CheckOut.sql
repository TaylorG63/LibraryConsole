CREATE TABLE [dbo].[CheckOut]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UserID] Int Not Null Foreign Key REFERENCES [dbo].[User],
	[BookID] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Book],
	[CheckOut] DateTime Not Null,
	[CheckIn] DateTime Null,
	[DueDate] DateTime Null
)
