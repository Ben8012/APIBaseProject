﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [firstname] NVARCHAR(50) NOT NULL,
    [lastname] NVARCHAR(50) NOT NULL,
    [email] NVARCHAR(384) NOT NULL UNIQUE,
    [passwd] NVARCHAR(300) NOT NULL,
    [role] NVARCHAR(50) NOT NULL,
    [birthDate] DATETIME2 NOT NULL,
    [createdAt] DATETIME2 NOT NULL,
    [updatedAt] DATETIME2 NULL,
    [isActive] BIT NOT NULL,
    [insuranceDateValidation] DATETIME2 NULL,
    [medicalDateValidation] DATETIME2 NULL,
    [isLevelValid] BIT NOT NULL,
    [guidImage] VARBINARY(MAX) NULL,
    [guidInsurance] VARBINARY(MAX) NULL,
    [guidLevel] VARBINARY(MAX) NULL,
    [guidCertificat] VARBINARY(MAX) NULL,
    [adress_Id] INT NULL, 
    CONSTRAINT [FK_User_Insurance] FOREIGN KEY ([adress_Id]) REFERENCES Adress([Id]),  
)
