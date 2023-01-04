CREATE TABLE [dbo].[Message]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[sender_Id] INT NOT NULL,
	[reciever_Id] INT NOT NULL,
	[content] NVARCHAR(1000) NOT NULL,
	[createdAt] DATETIME2 NOT NULL,
	[updatedAt] DATETIME2 NULL,
	[isActive] BIT NOT NULL, 
    CONSTRAINT [FK_MessageSender_ToUser] FOREIGN KEY ([sender_Id]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_MessageReciever_ToUser] FOREIGN KEY ([reciever_Id]) REFERENCES [User]([Id]),
)
