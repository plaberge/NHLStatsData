CREATE PROCEDURE [dbo].[spCreatePeriod]
	@gameId varchar(50), 
    @periodType VARCHAR(15), 
    @periodTimeStart TIME, 
    @periodTimeEnd TIME, 
    @periodNum VARCHAR(2), 
    @periodNumOrd VARCHAR(15), 
    @homeTeamId INT, 
    @homeGoals INT, 
    @homeShotsOnGoal INT, 
    @homeRinkSide VARCHAR(7), 
    @awayTeamId INT, 
    @awayGoals INT, 
    @awayShotsOnGoal INT, 
    @awayRinkSide VARCHAR(7), 
    @periodIdentity INT OUTPUT
AS
BEGIN
   IF NOT EXISTS (SELECT gameId FROM tblPeriod WHERE gameId = @gameId AND periodNum = @periodNum)
	BEGIN

		INSERT INTO tblPeriod (
								gameId, 
								periodType, 
								periodTimeStart, 
								periodTimeEnd, 
								periodNum, 
								periodNumOrd, 
								homeTeamId, 
								homeGoals, 
								homeShotsOnGoal, 
								homeRinkSide, 
								awayTeamId, 
								awayGoals, 
								awayShotsOnGoal, 
								awayRinkSide
							  )
		VALUES (
				@gameId, 
				@periodType, 
				@periodTimeStart, 
				@periodTimeEnd, 
				@periodNum, 
				@periodNumOrd, 
				@homeTeamId, 
				@homeGoals, 
				@homeShotsOnGoal, 
				@homeRinkSide, 
				@awayTeamId, 
				@awayGoals, 
				@awayShotsOnGoal, 
				@awayRinkSide
			   )

			   SET @periodIdentity = SCOPE_IDENTITY()

	END
	ELSE
		SET @periodIdentity = -100
	

END
RETURN SELECT @periodIdentity
