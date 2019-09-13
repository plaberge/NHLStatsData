CREATE PROCEDURE [dbo].[spCreateVenue]
	@venueId INT, 
    @venueName VARCHAR(50),
    @venueIdentity INT OUTPUT
AS
BEGIN
    IF NOT EXISTS (SELECT venueId FROM tblVenue WHERE venueId = @venueId)
	BEGIN
		INSERT INTO tblVenue(venueId, venueName)
		VALUES (@venueId, @venueName)

		SET @venueIdentity = SCOPE_IDENTITY()
	END
	ELSE
		SET @venueIdentity = -100
	

END
RETURN SELECT @venueIdentity