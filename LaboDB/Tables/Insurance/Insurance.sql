CREATE TABLE [dbo].[Insurance]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NOT NULL,
    [picture] NVARCHAR(50) NULL,
    [createdAt] DATETIME2 NOT NULL,
    [updatedAt] DATETIME2 NULL,
    [isActive] BIT NOT NULL,
    [adress_Id] INT NOT NULL, 
    CONSTRAINT [FK_Insurance_ToAdress] FOREIGN KEY ([Adress_Id]) REFERENCES [Adress]([Id]),
)
