CREATE TABLE [dbo].[Divelog_Gaz]
(
	[divelog_Id] INT NOT NULL,
	[gaz_Id] INT NOT NULL,
	[duration] INT NOT NULL,
	[deep] INT NOT NULL, 
    CONSTRAINT [FK_Divelog_Gaz_ToDivelog] FOREIGN KEY ([divelog_Id]) REFERENCES [Divelog]([Id]),
    CONSTRAINT [FK_Divelog_Gaz_ToGaz] FOREIGN KEY ([gaz_Id]) REFERENCES [gaz]([Id]),
)
