CREATE TABLE [dbo].[Comment]
(
	[CommentID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Context] VARCHAR(50) NULL, 
    [BID] INT NULL,
	CONSTRAINT [FK_dbo.Comment.Book_BookID] FOREIGN KEY ([BID]) 
        REFERENCES [dbo].[Book] ([BID]) ON DELETE CASCADE
)
