CREATE TABLE [dbo].[Invite]
(
	[inviter_Id] INT NOT NULL,
	[invited_Id] INT NOT NULL,
	[event_Id] INT NOT NULL,
	[createdAt] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Inviter_ToUser] FOREIGN KEY ([inviter_Id]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Invited_ToUser] FOREIGN KEY ([invited_Id]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Invite_ToEvent] FOREIGN KEY ([event_Id]) REFERENCES [Event]([Id]),
)
