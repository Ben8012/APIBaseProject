CREATE TABLE [dbo].[User_Diveplace]
(
	[user_Id] INT NOT NULL,
	[diveplace_Id] INT NOT NULL,
	[evaluation] INT NOT NULL,
	[createdAt] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_User_Diveplace_ToUser] FOREIGN KEY ([user_Id]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_User_Diveplace_ToDiveplace] FOREIGN KEY ([diveplace_Id]) REFERENCES [Diveplace]([Id]),

)
