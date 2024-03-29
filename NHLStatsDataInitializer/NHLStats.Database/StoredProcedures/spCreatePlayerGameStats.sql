﻿CREATE PROCEDURE [dbo].[spCreatePlayerGameStats]
	@gameId INT,
    @playerId INT,
    @position VARCHAR(15),
    @timeOnIce INT,
    @assists INT,
    @goals INT,
    @shots INT,
    @hits INT,
    @powerPlayGoals INT,
    @powerPlayAssists INT,
    @penaltyMinutes INT,
    @faceoffWins INT, 
    @faceoffWinPercentage decimal(18,2),
    @faceoffsTaken INT,
    @takeaways INT,
    @giveaways INT,
    @shorthandedGoals INT,
    @shorthandedAssists INT,
    @blocked INT,
    @plusMinus INT,
    @evenTimeOnIce INT,
    @powerPlayTimeOnIce INT,
    @shorthandedTimeOnIce INT,
    @goalieTimeOnIce INT,
    @shotsFaced INT,
    @shotsSaved INT,
    @powerPlayShotsSaved INT,
    @shorthandedShotsSaved INT,
    @evenSaved INT,
    @shorthandedShotsAgainst INT,
    @evenShotsAgainst INT,
    @powerPlayShotsAgainst INT,
    @decision VARCHAR(10),
    @savePercentage decimal(18,2),
    @evenSavePercentage decimal(18,2),
    @powerPlaySavePercentage decimal(18,2),
    @shorthandedSavePercentage decimal(18,2),
    @playerGameStatsIdentity INT OUTPUT
AS
BEGIN
    IF NOT EXISTS (SELECT playerId FROM tblPlayerGameStats WHERE playerId = @playerId AND gameId = @gameId)
	BEGIN
		INSERT INTO tblPlayerGameStats(
										gameId,
										playerId,
										position,
										timeOnIce,
										assists,
										goals,
										shots,
										hits,
										powerPlayGoals,
										powerPlayAssists,
										penaltyMinutes,
										faceoffWins,
										faceoffWinPercentage,
										faceoffsTaken,
										takeaways,
										giveaways,
										shorthandedGoals,
										shorthandedAssists,
										blocked,
										plusMinus,
										evenTimeOnIce,
										powerPlayTimeOnIce,
										shorthandedTimeOnIce,
										goalieTimeOnIce,
										shotsFaced,
										shotsSaved,
										powerPlayShotsSaved,
										shorthandedShotsSaved,
										evenSaved,
										shorthandedShotsAgainst,
										evenShotsAgainst,
										powerPlayShotsAgainst,
										decision,
										savePercentage,
										evenSavePercentage,
										powerPlaySavePercentage,
										shorthandedSavePercentage
									   )
		VALUES (
				@gameId,
				@playerId,
				@position,
				@timeOnIce,
				@assists,
				@goals,
				@shots,
				@hits,
				@powerPlayGoals,
				@powerPlayAssists,
				@penaltyMinutes,
				@faceoffWins,
				@faceoffWinPercentage,
				@faceoffsTaken,
				@takeaways,
				@giveaways,
				@shorthandedGoals,
				@shorthandedAssists,
				@blocked,
				@plusMinus,
				@evenTimeOnIce,
				@powerPlayTimeOnIce,
				@shorthandedTimeOnIce,
				@goalieTimeOnIce,
				@shotsFaced,
				@shotsSaved,
				@powerPlayShotsSaved,
				@shorthandedShotsSaved,
				@evenSaved,
				@shorthandedShotsAgainst,
				@evenShotsAgainst,
				@powerPlayShotsAgainst,
				@decision,
				@savePercentage,
				@evenSavePercentage,
				@powerPlaySavePercentage,
				@shorthandedSavePercentage
			   )

			   SET @playerGameStatsIdentity = SCOPE_IDENTITY()
	END
	ELSE
		SET @playerGameStatsIdentity = -100
	

END
RETURN SELECT @playerGameStatsIdentity