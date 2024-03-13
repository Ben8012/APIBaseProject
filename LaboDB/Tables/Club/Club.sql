CREATE TABLE [dbo].[Club]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[name] NVARCHAR(50) NOT NULL,
	[createdAt] DATETIME2 NOT NULL,
	[updatedAt] DATETIME2 NULL,
	[isActive] BIT NOT NULL,
	[adress_Id] INT NULL,
	[creator_Id] INT NOT NULL, 
	[organisation_Id] INT NULL, 
    CONSTRAINT [FK_Club_Adress] FOREIGN KEY ([adress_Id]) REFERENCES [Adress]([Id]), 
    CONSTRAINT [FK_Club_User] FOREIGN KEY ([creator_Id]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Club_Organisation] FOREIGN KEY ([organisation_Id]) REFERENCES [Organisation]([Id]),
)
