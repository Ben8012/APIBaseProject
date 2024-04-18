CREATE TABLE [dbo].[User_Training]
(
    [user_Id] INT NOT NULL, 
	[training_Id] INT NOT NULL,
	[refNumber] NVARCHAR(50) NOT NULL,
	[createdAt] DATETIME2 NOT NULL, 
	[isMostLevel] BIT NOT NULL,
    CONSTRAINT [FK_User_Organisation_ToUser] FOREIGN KEY ([user_Id]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_User_Organisation_ToOrganisation] FOREIGN KEY ([training_Id]) REFERENCES [Training]([Id]),
)
