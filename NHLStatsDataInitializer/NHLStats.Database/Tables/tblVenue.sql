CREATE TABLE [dbo].[tblVenue]
(
	[Id] INT NOT NULL IDENTITY, 
    [venueId] INT NOT NULL, 
    [venueName] VARCHAR(50) NOT NULL,
	[venueCity] [varchar](50) NULL,
	[venueStateProvince] [varchar](50) NULL,
	[venueCountry] [varchar](50) NULL,
	[venueLatitude] [decimal](9, 6) NULL,
	[venueLongitude] [decimal](9, 6) NULL,
    CONSTRAINT [PK_tblVenue] PRIMARY KEY ([venueId])
)
