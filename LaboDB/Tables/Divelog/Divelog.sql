CREATE TABLE [dbo].[Divelog]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[diveType] NVARCHAR NOT NULL,
	[description] NVARCHAR NULL,
	[duration] INT NOT NULL,
	[maxDeep] INT NOT NULL,
	[airTemperature] INT NULL,
	[waterTemperature] INT NULL,
	[diveDate] DATETIME2 NOT NULL,
	[createdAt] DATETIME2 NOT NULL,
	[updatedAt] DATETIME2 NULL,
	[isActive] BIT NOT NULL,
	[user_Id] INT NOT NULL,
	[event_Id] INT NULL, 
    CONSTRAINT [FK_Divelog_ToUser] FOREIGN KEY ([user_Id]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Divelog_ToEvent] FOREIGN KEY ([event_Id]) REFERENCES [Event]([Id]),

)
