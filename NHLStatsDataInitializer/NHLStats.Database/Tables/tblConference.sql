CREATE TABLE [dbo].[tblConference]
(
	[Id] INT NOT NULL IDENTITY, 
    [conferenceId] INT NOT NULL, 
    [conferenceName] VARCHAR(50) NOT NULL, 
    [conferenceAbbreviation] VARCHAR(15) NULL, 
    [shortName] VARCHAR(20) NULL, 
    [active] VARCHAR(10) NOT NULL, 
    CONSTRAINT [PK_tblConference] PRIMARY KEY ([conferenceId])
)
