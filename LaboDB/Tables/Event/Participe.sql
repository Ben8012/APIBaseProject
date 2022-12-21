CREATE TABLE [dbo].[Participe]
(
	[user_Id] INT NOT NULL,
	[event_Id] INT NOT NULL,
	[createdAt] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Participe_ToUser] FOREIGN KEY ([user_Id]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Participe_ToEvent] FOREIGN KEY ([event_Id]) REFERENCES [Event]([Id]),
)
