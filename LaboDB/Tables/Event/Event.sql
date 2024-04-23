CREATE TABLE [dbo].[Event]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[name] NVARCHAR(50) NOT NULL,
	[description] NVARCHAR(1000)  NULL,
	[startDate] DATETIME2 NOT NULL,
	[endDate] DATETIME2 NULL,
	[createdAt] DATETIME2 NOT NULL,
	[updatedAt] DATETIME2 NULL,
	[isActive] BIT NOT NULL,
	[diveplace_Id] INT NOT NULL,
	[creator_Id] INT NOT NULL,
	[training_Id] INT NULL,
	[club_Id] INT NULL, 
    CONSTRAINT [FK_Event_ToDiveplace] FOREIGN KEY ([diveplace_Id]) REFERENCES [Diveplace]([Id]), 
    CONSTRAINT [FK_Event_ToUser] FOREIGN KEY ([creator_Id]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Event_ToTraining] FOREIGN KEY ([training_Id]) REFERENCES [Training]([Id]), 
    CONSTRAINT [FK_Event_ToClub] FOREIGN KEY ([club_Id]) REFERENCES [Club]([Id]),
)
