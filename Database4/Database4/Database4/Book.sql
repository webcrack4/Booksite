CREATE TABLE [dbo].[Book]
(
	[BId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] VARCHAR(50) NULL, 
    [ISBN] VARCHAR(50) NULL, 
    [Course] VARCHAR(50) NULL, 
    [Level] INT NULL, 
    [Price] INT NULL, 
    [UID] INT NULL, 
    [CommunityID] INT NULL,
	CONSTRAINT [FK_dbo.Book.Community_CommunityID] FOREIGN KEY ([CommunityID]) 
        REFERENCES [dbo].[Community] ([CommunityID]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.Book.UserID] FOREIGN KEY ([UID]) 
        REFERENCES [dbo].[User] ([UID]) ON DELETE CASCADE
)
