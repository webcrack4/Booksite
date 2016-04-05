CREATE TABLE [dbo].[User]
(
	[UID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [Address] VARCHAR(50) NULL, 
    [DateofBirth] DATETIME NULL, 
    [Admin] BIT NULL
)
