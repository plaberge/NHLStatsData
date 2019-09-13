CREATE PROCEDURE [dbo].[spCreateGameEvent]
	@eventId INT,
    @correspondingGameId INT, 
    @eventType VARCHAR(25), 
    @eventCode VARCHAR(15), 
    @eventTypeId VARCHAR(15), 
    @eventDescription VARCHAR(300), 
    @eventSecondaryType VARCHAR(25), 
    @eventIdX VARCHAR(15),
    @period INT, 
    @periodType VARCHAR(50), 
    @periodOrdinalNumber VARCHAR(10), 
    @periodTimeMinutes INT, 
    @periodTimeSeconds INT, 
	@periodTimeRemainingMinutes INT,
	@periodTimeRemainingSeconds INT,
    @eventTimeStamp DATETIME, 
    @goalsAway INT, 
    @goalsHome INT, 
    @xCoordinate DECIMAL(5, 2), 
    @yCoordinate DECIMAL(5, 2), 
    @teamId INT, 
    @gameEventIdentity INT OUTPUT
AS
BEGIN
IF NOT EXISTS (SELECT eventId FROM tblGameEvent WHERE eventId = @eventId AND correspondingGameId = @correspondingGameId)
	BEGIN
		DECLARE @periodId INT

		SET @periodID = (SELECT periodId FROM tblPeriod WHERE gameId = @correspondingGameId AND periodNumOrd = @periodOrdinalNumber)

		INSERT INTO tblGameEvent (
									eventId,
									correspondingGameId, 
									eventType, 
    								eventCode, 
    								eventTypeId, 
    								eventDescription, 
    								eventSecondaryType, 
    								eventIdX,
									periodId,
    								[period], 
    								periodType, 
   								    periodOrdinalNumber, 
    								periodTimeMinutes, 
    								periodTimeSeconds, 
									periodTimeRemainingMinutes,
									periodTimeRemainingSeconds,
    								eventTimeStamp, 
    								goalsAway, 
    								goalsHome, 
    								xCoordinate, 
    								yCoordinate, 
    								teamId
								 )
		VALUES (
				@eventId,
				@correspondingGameId, 
				@eventType, 
				@eventCode, 
				@eventTypeId, 
				@eventDescription, 
				@eventSecondaryType, 
				@eventIdX,
				@periodId,
				@period, 
				@periodType, 
				@periodOrdinalNumber, 
				@periodTimeMinutes, 
				@periodTimeSeconds, 
				@periodTimeRemainingMinutes,
				@periodTimeRemainingSeconds,
				@eventTimeStamp, 
				@goalsAway, 
				@goalsHome, 
				@xCoordinate, 
				@yCoordinate, 
				@teamId
		   )

		   SET @gameEventIdentity = SCOPE_IDENTITY()
	END
	ELSE
		SET @gameEventIdentity = -100
	

END
RETURN SELECT @gameEventIdentity