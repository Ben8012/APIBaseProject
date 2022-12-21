CREATE TABLE [dbo].[Training]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[name] NVARCHAR(50) NOT NULL,
	[prerequis] NVARCHAR(50) NOT NULL,
	[picture] NVARCHAR(50) NOT NULL,
	[isSpeciality] BIT NOT NULL,
	[createdAt] DATETIME2 NOT NULL,
	[updatedAt] DATETIME2 NULL,
	[isActive] BIT NOT NULL,
	[organisation_Id] INT NOT NULL, 
    CONSTRAINT [FK_Training_ToOrganisation] FOREIGN KEY ([organisation_Id]) REFERENCES [Organisation]([Id]),

)
