CREATE TABLE [dbo].[User_Club]
(
	[user_Id] INT NOT NULL,
	[club_Id] INT NOT NULL,
	[validation] Bit NOT NULL,
	[createdAt] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_User_Club_ToUser] FOREIGN KEY ([user_Id]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_User_Club_ToClub] FOREIGN KEY ([club_Id]) REFERENCES [Club]([Id]),
)
