CREATE PROCEDURE [dbo].[spCreateConference]
	@conferenceId INT, 
    @conferenceName VARCHAR(50), 
    @conferenceAbbreviation VARCHAR(15), 
    @shortName VARCHAR(20), 
    @active VARCHAR(10), 
	@conferenceIdentity int OUTPUT
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM tblConference WHERE conferenceId = @conferenceId)
	BEGIN
	  INSERT INTO tblConference(conferenceId, conferenceName, conferenceAbbreviation, shortName, active)
	  VALUES (@conferenceId, @conferenceName, @conferenceAbbreviation, @shortName, @active)
	
	  SET @conferenceIdentity = SCOPE_IDENTITY()
	END
	ELSE
		SET @conferenceIdentity = -100
END


RETURN SELECT SCOPE_IDENTITY()
