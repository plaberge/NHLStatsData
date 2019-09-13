CREATE PROCEDURE [dbo].[spCreateSchedule]
	@scheduleDate DATE,
	@season VARCHAR(10),
	@totalItems int,
	@totalEvents int,
	@totalGames int,
	@totalMatches int,
	@scheduleID int OUTPUT

AS
BEGIN

	IF NOT EXISTS (SELECT scheduleDate, season FROM tblSchedule WHERE scheduleDate = @scheduleDate AND season = @season)
	BEGIN

		INSERT INTO tblSchedule (scheduleDate, season, totalItems, totalEvents, totalGames, totalMatches)
		VALUES (@scheduleDate, @season, @totalItems, @totalEvents, @totalGames, @totalMatches)
		SET @scheduleID = SCOPE_IDENTITY()
	END
	ELSE
		SET @scheduleID = -100
	

END
RETURN SELECT @scheduleID