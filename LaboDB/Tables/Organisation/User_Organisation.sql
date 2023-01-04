CREATE TABLE [dbo].[User_Organisation]
(
    [user_Id] INT NOT NULL, 
	[organisation_Id] INT NOT NULL,
	[level] NVARCHAR(50) NOT NULL,
	[refNumber] NVARCHAR(50) NOT NULL,
	[createdAt] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_User_Organisation_ToUser] FOREIGN KEY ([user_Id]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_User_Organisation_ToOrganisation] FOREIGN KEY ([organisation_Id]) REFERENCES [Organisation]([Id]),
)
