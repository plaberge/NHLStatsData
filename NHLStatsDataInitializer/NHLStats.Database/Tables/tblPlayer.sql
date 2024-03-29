﻿CREATE TABLE [dbo].[tblPlayer]
(
	[Id] INT NOT NULL IDENTITY, 
    [playerId] INT NOT NULL, 
    [firstName] VARCHAR(100) NOT NULL, 
	[firstNameDemo] VARCHAR(100) NULL,
    [lastName] VARCHAR(100) NOT NULL, 
	[lastNameDemo] VARCHAR(100) NULL,
    [primaryNumber] TINYINT NULL, 
    [birthDate] DATE NULL, 
    [currentAge] TINYINT NULL, 
    [birthCity] VARCHAR(50) NULL, 
    [birthStateProvince] VARCHAR(50) NULL, 
    [birthCountry] VARCHAR(50) NULL, 
    [nationality] VARCHAR(50) NULL, 
    [height] TINYINT NULL, 
    [weight] SMALLINT NULL, 
    [active] VARCHAR(7) NULL, 
    [alternateCaptain] VARCHAR(7) NULL, 
    [captain] VARCHAR(7) NULL, 
    [rookie] VARCHAR(7) NULL, 
    [shootsCatches] VARCHAR(10) NULL, 
    [rosterStatus] VARCHAR(15) NULL, 
    [currentTeamID] INT NULL, 
    [primaryPositionCode] VARCHAR(5) NULL, 
    [primaryPositionName] VARCHAR(15) NULL, 
    [primaryPositionType] VARCHAR(15) NULL, 
    [primaryPositionAbbr] VARCHAR(5) NULL
)
