﻿CREATE TABLE [dbo].[Diveplace]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NOT NULL,
    [guidImage] VARBINARY(MAX) NULL,
    [guidMap] VARBINARY(MAX) NULL,
    [description] NVARCHAR(1000) NULL,
    [createdAt] DATETIME2 NOT NULL,
    [updatedAt] DATETIME2 NULL,
    [isActive] BIT NOT NULL,
    [adress_Id] INT NOT NULL, 
    [gps] NVARCHAR(50) NULL, 
    [url] NVARCHAR(100) NULL,
    [maxDepp] INT NOT NULL,
    [price] FLOAT NOT NULL,
    [compressor] BIT NOT NULL,
    [restoration] BIT NOT NULL,
    [creator_Id] INT NOT NULL,
    CONSTRAINT [FK_User_ToCreator] FOREIGN KEY ([creator_Id]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Diveplace_ToAdress] FOREIGN KEY ([adress_Id]) REFERENCES [Adress]([Id]),
)
