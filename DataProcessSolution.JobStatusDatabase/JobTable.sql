CREATE TABLE [dbo].[JobTable]
(
	[JobId] INT NOT NULL PRIMARY KEY, 
    [ClientId] INT NULL, 
    [LastUpdated] DATETIME NULL, 
    [Status] NCHAR(10) NULL
)
