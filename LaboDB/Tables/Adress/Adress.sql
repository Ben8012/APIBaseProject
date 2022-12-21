CREATE TABLE [dbo].[Adress]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [street] NVARCHAR(100) NOT NULL,
    [number] INT NOT NULL, 
    [city_Id] INT NOT NULL, 
    CONSTRAINT [FK_Adress_City] FOREIGN KEY ([city_Id]) REFERENCES [City]([Id]),
)
