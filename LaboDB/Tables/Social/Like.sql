CREATE TABLE [dbo].[Like]
(
	[liker_Id] INT NOT NULL,
	[liked_Id] INT NOT NULL,
	[createdAt] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Liker_ToUser] FOREIGN KEY ([liker_Id]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Liked_ToUser] FOREIGN KEY ([liked_Id]) REFERENCES [User]([Id]),
)
