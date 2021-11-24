CREATE TABLE [dbo].[UserLogin]
(
	[UserloginId] NUMERIC NOT NULL PRIMARY KEY IDENTITY, 
    [Email] VARCHAR(50) NULL, 
    [Password] VARCHAR(50) NULL, 
    [LastLogin] DATETIME NULL, 
    [Token] VARCHAR(50) NULL
)
