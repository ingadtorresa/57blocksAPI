CREATE TABLE [dbo].[Pokemon]
(
	[PokemonId] NUMERIC NOT NULL PRIMARY KEY IDENTITY, 
    [UserloginId] NUMERIC NULL,
    [Name] VARCHAR(50) NULL, 
    [TypePrincipal] VARCHAR(30) NULL,
    [TypeAlternate] VARCHAR(30) NULL,
    [Level] INT NULL, 
    [PC] NUMERIC NULL,
    CONSTRAINT [FK_Pokemon_UserLogin] FOREIGN KEY ([UserloginId]) REFERENCES [dbo].[UserLogin], 
)
