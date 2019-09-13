CREATE FUNCTION [dbo].[fnGetLastGameEvent]
(
	@gameId VARCHAR(15)
)
RETURNS INT
AS
BEGIN
	DECLARE
		@gameEventId INT

	SELECT @gameEventId = eventId 
	FROM tblGameEvent
	WHERE
		correspondingGameId = @gameId AND
		eventTimeStamp in (SELECT MAX(eventTimeStamp) FROM tblGameEvent where correspondingGameId = @gameId)

	RETURN @gameEventId
END
