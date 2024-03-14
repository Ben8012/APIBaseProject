CREATE TABLE [dbo].[Diveplace]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NOT NULL,
    [picture] NVARCHAR(50) NOT NULL,
    [map] NVARCHAR(50) NOT NULL,
    [description] NVARCHAR(1000) NULL,
    [createdAt] DATETIME2 NOT NULL,
    [updatedAt] DATETIME2 NULL,
    [isActive] BIT NOT NULL,
    [adress_Id] INT NOT NULL, 
    [gps] NVARCHAR(50) NULL, 
    [url] NVARCHAR(100) NULL,
    [maxDepp] INT NOT NULL,
    [price] INT NOT NULL,
    [compressor] BIT NOT NULL,
    [restoration] bIT NOT NULL
    CONSTRAINT [FK_Diveplace_ToAdress] FOREIGN KEY ([adress_Id]) REFERENCES [Adress]([Id]),
)
