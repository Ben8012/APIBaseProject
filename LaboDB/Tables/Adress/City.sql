CREATE TABLE [dbo].[City]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NOT NULL,
    [postCode] NVARCHAR(50) NOT NULL,
    [country_Id] INT NOT NULL, 
    CONSTRAINT [FK_City_Country] FOREIGN KEY ([country_Id]) REFERENCES [Country]([Id]),
)
